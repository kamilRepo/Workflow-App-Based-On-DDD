using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Basic.Presentation.Attributes;
using Workflow.Basic.Domain.Domain.Entities.Dictionaries;
using Workflow.Dashboard.Interface.Presentation.Criteria;
using Workflow.Dashboard.Interface.Presentation.Dto;
using Workflow.HR.Interface.Presentation.FindersDto;
using Workflow.Basic.Presentation.BasicModels;
using Workflow.Basic.Presentation.Helper;
using Workflow.Basic.Presentation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Workflow.Web.Forms.App.Views.ApplicationsHR
{
    public partial class MyEmployee : BasePage
    {
        #region Query



        #endregion
        #region Command



        #endregion
        #region Dto

        private EmployeeDto _employeeDto;
        private List<SalaryDeductionsDto> _listSalaryDeductionsDto;
        private EmployeeDto _directSupervisorDto;
        private EmployeeMembershipDto _employeeMembershipDto;

        #endregion
        #region Core



        #endregion
        #region Field and properties

        private const int _firstEditCellIndex = 2;
        private int _rowIndex;
        private int _employeeID;

        #endregion
        #region View elements

        private GridView _gridView;
        private LinkButton _btn_Edit;
        private LinkButton _btn_Delete;
        private LinkButton _btn_Save;
        private Label _id;
        private Label _employeeIdLabel;
        private TextBox _fromDateST;
        private TextBox _toDateST;
        private TextBox _amount;
        private TextBox _registrationNumber;

        #endregion
        #region Session



        #endregion

        #region Init

        protected void Page_Load(object sender, EventArgs e)
        {
            InitData(PageNumbers.ApplicationsHRDeductionsCompanyCar, (SessionUser)Session[SessionVariables.user]);

            Resolve();
            if (!IsPostBack)
            {
                GetData();
                InitData();
            }
        }

        private void Resolve()
        {
        }

        [PresentationLayerException]
        private ApplicationActionResult GetData()
        {
            _employeeID = GetIdFromUrl();

            CheckPermissions();

            _listSalaryDeductionsDto = PageMethodsHelper.InvokeWebAPI<SalaryDeductionsDto>(
                WebAPIVariables.salaryDeductions, "?SalaryDeductionsType=" + (int)SalaryDeductionsType.CompanyCar);

            Session[SessionVariables.gvDeductionsElements] = _listSalaryDeductionsDto;

            var esc = new EmployeeSearchCriteria() { EmployeeID = _employeeID };
            _employeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(
                WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc)).FirstOrDefault();
            _directSupervisorDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.employee, "?id=" + _employeeDto.DirectSupervisorID).FirstOrDefault();
            _employeeMembershipDto = PageMethodsHelper.InvokeWebAPI<EmployeeMembershipDto>(WebAPIVariables.employeeMembership, "?id=" + _employeeID).FirstOrDefault();

            if (_employeeDto == null || _employeeMembershipDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.ApplicationsHRMyPortalGetData, SessionUser.Id);

            var cph = (ContentPlaceHolder)Master.Master.FindControl("MainContent");
            ((Image)cph.FindControl("btn_Image")).ImageUrl = @"~\Content\ThumbnailEmployee\" + _employeeID + ".png";

            return new ApplicationActionResult() { Success = true };
        }

        private void InitData()
        {
            lbl_nameSurname.Text = _employeeDto.LastName + " " + _employeeDto.FirstName;
            lbl_EmployeeNumber.Text = _employeeDto.EmployeeNumber;
            lbl_Position.Text = _employeeMembershipDto.Position;

            foreach (var item in _listSalaryDeductionsDto)
            {
                item.SetFromDateST();
                item.SetToDateST();
            }

            this.gv_Deductions.DataSource = _listSalaryDeductionsDto;
            this.gv_Deductions.DataBind();

            if (this.gv_Deductions.SelectedIndex > -1)
            {
                this.gv_Deductions.UpdateRow(this.gv_Deductions.SelectedIndex, false);
            }
        }

        #endregion

        #region Page methods

        [PresentationLayerException]
        protected void gv_Deductions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            _gridView = (GridView)sender;

            switch (e.CommandName)
            {
                case ("CommandEdit"):
                    CommandEdit(e);
                    break;
                case ("CommandDelete"):
                    CommandDelete(e);
                    break;
                case ("CommandSave"):
                    CommandSave(e);
                    break;
            }
        }

        [PresentationLayerException]
        protected void AddRow_Click(object sender, EventArgs e)
        {
            string id = (string)Session[SessionVariables.hf_EmployeeID];
            Session[SessionVariables.hf_EmployeeID] = null;
            if (string.IsNullOrEmpty(id))
                return;

            var _listSalaryDeductionsDto = (List<SalaryDeductionsDto>)Session[SessionVariables.gvDeductionsElements];

            var esc = new EmployeeSearchCriteria() { EmployeeID = Convert.ToInt32(id) };
            _employeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(
                WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc)).FirstOrDefault();

            var value = new SalaryDeductionsDto()
            {
                LastFirstName = _employeeDto.LastName + " " + _employeeDto.FirstName,
                EmployeeNumber = _employeeDto.EmployeeNumber,
                EmployeeId = Convert.ToInt32(id)
            };

            _listSalaryDeductionsDto.Add(value);

            foreach (var item in _listSalaryDeductionsDto)
            {
                item.SetFromDateST();
                item.SetToDateST();
            }

            this.gv_Deductions.DataSource = _listSalaryDeductionsDto;
            this.gv_Deductions.DataBind();
        }

        #endregion
        #region Private methods

        private void CheckPermissions()
        {

        }

        private void CommandEdit(GridViewCommandEventArgs e)
        {
            _rowIndex = int.Parse(e.CommandArgument.ToString());
            _gridView.SelectedIndex = _rowIndex;

            EditGrid(_gridView, _rowIndex, 4);
            EditGrid(_gridView, _rowIndex, 5);
            EditGrid(_gridView, _rowIndex, 6);
            EditGrid(_gridView, _rowIndex, 7);

            _btn_Edit = (LinkButton)_gridView.Rows[_rowIndex].FindControl("btn_Edit");
            _btn_Delete = (LinkButton)_gridView.Rows[_rowIndex].FindControl("btn_Delete");
            _btn_Save = (LinkButton)_gridView.Rows[_rowIndex].FindControl("btn_Save");
            _btn_Edit.Visible = false;
            _btn_Delete.Visible = false;
            _btn_Save.Visible = true;
        }

        private void CommandDelete(GridViewCommandEventArgs e)
        {
            _rowIndex = int.Parse(e.CommandArgument.ToString());
            _gridView.SelectedIndex = _rowIndex;
            _id = (Label)_gridView.Rows[_rowIndex].FindControl("IdLabel");

            if (!(string.IsNullOrEmpty(_id.Text) || _id.Text.Equals("0")))
            {
                var esc = new SalaryDeductionsDto()
                {
                    Id = Convert.ToInt32(_id.Text),
                    UserId = SessionUser.Id
                };

                PageMethodsHelper.InvokeWebAPI<SalaryDeductionsDto>(
                    WebAPIVariables.deleteSalaryDeductions, PageMethodsHelper.ObjectToUrlParam(esc)).FirstOrDefault();
            }

            _listSalaryDeductionsDto = PageMethodsHelper.InvokeWebAPI<SalaryDeductionsDto>(
                WebAPIVariables.salaryDeductions, "?SalaryDeductionsType=" + (int)SalaryDeductionsType.CompanyCar);
            Session[SessionVariables.gvDeductionsElements] = _listSalaryDeductionsDto;

            foreach (var item in _listSalaryDeductionsDto)
            {
                item.SetFromDateST();
                item.SetToDateST();
            }

            this.gv_Deductions.DataSource = _listSalaryDeductionsDto;
            this.gv_Deductions.DataBind();
        }

        private void CommandSave(GridViewCommandEventArgs e)
        {
            _rowIndex = int.Parse(e.CommandArgument.ToString());
            _gridView.SelectedIndex = _rowIndex;
            _id = (Label)_gridView.Rows[_rowIndex].FindControl("IdLabel");
            _employeeIdLabel = (Label)_gridView.Rows[_rowIndex].FindControl("EmployeeIdLabel");
            _fromDateST = (TextBox)_gridView.Rows[_rowIndex].FindControl("FromDateST");
            _toDateST = (TextBox)_gridView.Rows[_rowIndex].FindControl("ToDateST");
            _amount = (TextBox)_gridView.Rows[_rowIndex].FindControl("Amount");
            _registrationNumber = (TextBox)_gridView.Rows[_rowIndex].FindControl("RegistrationNumber");

            Save();

            SaveGrid(_gridView, _rowIndex, 4);
            SaveGrid(_gridView, _rowIndex, 5);
            SaveGrid(_gridView, _rowIndex, 6);
            SaveGrid(_gridView, _rowIndex, 7);

            _btn_Edit = (LinkButton)_gridView.Rows[_rowIndex].FindControl("btn_Edit");
            _btn_Delete = (LinkButton)_gridView.Rows[_rowIndex].FindControl("btn_Delete");
            _btn_Save = (LinkButton)_gridView.Rows[_rowIndex].FindControl("btn_Save");
            _btn_Edit.Visible = true;
            _btn_Delete.Visible = true;
            _btn_Save.Visible = false;
        }

        private void Save()
        {
            if (string.IsNullOrEmpty(_id.Text) || _id.Text.Equals("0"))
                SaveNew();
            else
                SaveOld();
        }

        private void SaveNew()
        {
            var value = new SalaryDeductionsDto()
            {
                EmployeeId = Convert.ToInt32(_employeeIdLabel.Text),
                Amount = Convert.ToDouble(_amount.Text),
                FromDateST = _fromDateST.Text,
                ToDateST = _toDateST.Text,
                SalaryDeductionsType = (int)SalaryDeductionsType.CompanyCar,
                RegistrationNumber = _registrationNumber.Text
            };

            var v = PageMethodsHelper.InvokeWebAPI<SalaryDeductionsDto>(WebAPIVariables.addSalaryDeductions, PageMethodsHelper.ObjectToUrlParam(value)).FirstOrDefault();

            _id.Text = v.Id.ToString();
        }

        private void SaveOld()
        {
            var value = new SalaryDeductionsDto()
            {
                Id = Convert.ToInt32(_id.Text),
                EmployeeId = Convert.ToInt32(_employeeIdLabel.Text),
                Amount = Convert.ToDouble(_amount.Text),
                FromDateST = _fromDateST.Text,
                ToDateST = _toDateST.Text,
                SalaryDeductionsType = (int)SalaryDeductionsType.CompanyCar,
                RegistrationNumber = _registrationNumber.Text
            };

            PageMethodsHelper.InvokeWebAPI<SalaryDeductionsDto>(WebAPIVariables.addSalaryDeductions, PageMethodsHelper.ObjectToUrlParam(value)).FirstOrDefault();
        }

        private void EditGrid(GridView gridView, int rowIndex, int columnIndex)
        {
            Control displayControl = gridView.Rows[rowIndex].Cells[columnIndex].Controls[1];
            displayControl.Visible = false;
            Control editControl = gridView.Rows[rowIndex].Cells[columnIndex].Controls[3];
            editControl.Visible = true;
            gridView.Rows[rowIndex].Cells[columnIndex].Attributes.Clear();

            ScriptManager.RegisterStartupScript(this, GetType(), "SetFocus",
                "document.getElementById('" + editControl.ClientID + "').focus();", true);

            if (editControl is TextBox)
            {
                ((TextBox)editControl).Attributes.Add("onfocus", "this.select()");
            }
        }

        private void SaveGrid(GridView gridView, int rowIndex, int columnIndex)
        {
            Label displayControl = (Label)gridView.Rows[rowIndex].Cells[columnIndex].Controls[1];
            displayControl.Visible = true;
            TextBox editControl = (TextBox)gridView.Rows[rowIndex].Cells[columnIndex].Controls[3];
            displayControl.Text = editControl.Text;
            editControl.Visible = false;
            gridView.Rows[rowIndex].Cells[columnIndex].Attributes.Clear();
        }

        #endregion
    }
}