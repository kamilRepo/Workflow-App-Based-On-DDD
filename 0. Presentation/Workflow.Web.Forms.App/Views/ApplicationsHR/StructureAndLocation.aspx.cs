using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Basic.Presentation.Attributes;
using Workflow.Dashboard.Interface.Application.Abstract;
using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.Dashboard.Interface.Presentation.Criteria;
using Workflow.Dashboard.Interface.Presentation.Dto;
using Workflow.Dashboard.Interface.Presentation.ServicesDto;
using Workflow.HR.Interface.Application.Abstract;
using Workflow.HR.Interface.Presentation.FindersDto;
using Workflow.HR.Interface.Presentation.ServicesDto;
using Workflow.Basic.Presentation.BasicModels;
using Workflow.Basic.Presentation.Helper;
using Workflow.Basic.Presentation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Workflow.Web.Forms.App.Views.ApplicationsHR
{
    public partial class StructureAndLocation : BasePage
    {
        #region Query



        #endregion
        #region Command



        #endregion
        #region Dto

        private EmployeeDto _employeeDto;
        private EmployeeDto _directSupervisorDto;
        private EmployeeMembershipDto _employeeMembershipDto;
        private List<DictionaryDto> _listSectionDto;
        private List<DictionaryDto> _listOrganizationalUnitDto;
        private List<DictionaryDto> _listOrganizationalCellDto;
        private List<DictionaryDto> _listWorksDto;
        private List<DictionaryDto> _listProductSectionDto;
        private List<DictionaryDto> _listPlaceWhereCostsAriseDto;
        private List<DictionaryDto> _listSzpartaDto;
        private List<StructureAndLocationDto> _listStructureAndLocationDto;

        #endregion
        #region Core



        #endregion
        #region Field and properties

        private int _employeeID;
        private int _rowIndex;

        #endregion
        #region View elements

        private GridView _gridView;
        private LinkButton _btn_Edit;
        private LinkButton _btn_Delete;
        private LinkButton _btn_Save;
        private Label _id;
        private DropDownList _ddl_OrganizationalUnit;
        private DropDownList   _ddl_OrganizationalCell;
        private DropDownList   _ddl_Silo;
        private TextBox _tb_Coefficient;

        #endregion
        #region Session



        #endregion

        #region Init

        protected void Page_Load(object sender, EventArgs e)
        {
            InitData(PageNumbers.ApplicationsHRStructureAndLocation, (SessionUser)Session[SessionVariables.user]);

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

            var esc = new EmployeeSearchCriteria() { EmployeeID = _employeeID };
            _employeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(
                WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc)).FirstOrDefault();
            _directSupervisorDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.employee, "?id=" + _employeeDto.DirectSupervisorID).FirstOrDefault();
            _employeeMembershipDto = PageMethodsHelper.InvokeWebAPI<EmployeeMembershipDto>(WebAPIVariables.employeeMembership, "?id=" + _employeeID).FirstOrDefault();

            if (_employeeDto == null || _employeeMembershipDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.ApplicationsHRStructureAndLocationGetData, SessionUser.Id);

            _listSectionDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.sections);
            _listOrganizationalUnitDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.organizationalUnits);
            _listOrganizationalCellDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.organizationalCells);
            _listWorksDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.works);
            _listProductSectionDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.productSection);
            _listPlaceWhereCostsAriseDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.placeWhereCostsArise);
            _listSzpartaDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.szparta);
            _listStructureAndLocationDto = PageMethodsHelper.InvokeWebAPI<StructureAndLocationDto>(
                WebAPIVariables.structureAndLocation, "?employeeId=" + _employeeID);

            if (_listSectionDto == null || _listOrganizationalUnitDto == null || _listOrganizationalCellDto == null ||
                _listWorksDto == null || _listProductSectionDto == null || _listPlaceWhereCostsAriseDto == null || _listSzpartaDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.ApplicationsHRStructureAndLocationGetData, SessionUser.Id);

            var cph = (ContentPlaceHolder)Master.Master.FindControl("MainContent");

            var basic = @"~\Content\ThumbnailEmployee\";
            var employeeImage = _employeeID + ".png";
            var emptyImage = "empty.png";

            var dataFile = Server.MapPath(basic) + employeeImage;

            if (File.Exists(dataFile))
                ((Image)cph.FindControl("btn_Image")).ImageUrl = basic + employeeImage;
            else
                ((Image)cph.FindControl("btn_Image")).ImageUrl = basic + emptyImage;

            return new ApplicationActionResult() { Success = true };
        }

        private void InitData()
        {
            lbl_nameSurname.Text = _employeeDto.LastName + " " + _employeeDto.FirstName;
            lbl_EmployeeNumber.Text = _employeeDto.EmployeeNumber;
            lbl_Position.Text = _employeeMembershipDto.Position;
            tb_PositionTable.Text = _employeeMembershipDto.Position;

            if (_directSupervisorDto != null)
            {
                lbl_DirectSupervisor.Text = _directSupervisorDto.FirstName + " " + _directSupervisorDto.LastName;
                hf_DirectSupervisorId.Value = _employeeDto.DirectSupervisorID.ToString();
            }
            else
                lbl_DirectSupervisor.Text = Translate("Common", "Lack");

            hf_EmployeeMembershipId.Value = _employeeMembershipDto.Id.ToString();
            up_SearchForss.Update();

            PageMethodsHelper.SetDropDownList(ddl_Section, _listSectionDto);
            PageMethodsHelper.SetDropDownList(ddl_OrganizationalUnit, _listOrganizationalUnitDto);
            PageMethodsHelper.SetDropDownList(ddl_OrganizationalCell, _listOrganizationalCellDto);

            var item = _listSectionDto.Where(x => x.Name == _employeeMembershipDto.Section).FirstOrDefault();
            ddl_Section.Text = item == null ? "0" : item.Id.ToString();
            item = _listOrganizationalUnitDto.Where(x => x.Name == _employeeMembershipDto.OrganizationalUnit).FirstOrDefault();
            ddl_OrganizationalUnit.Text = item == null ? "0" : item.Id.ToString();
            item = _listOrganizationalCellDto.Where(x => x.Name == _employeeMembershipDto.OrganizationalCell).FirstOrDefault();
            ddl_OrganizationalCell.Text = item == null ? "0" : item.Id.ToString();

            Session[SessionVariables.listStructureAndLocationCoefficient] = _listStructureAndLocationDto;
            this.gv_Coefficients.DataSource = _listStructureAndLocationDto;
            this.gv_Coefficients.DataBind();
        }

        #endregion

        #region Page methods


        protected void lnk_AllocationDefault_Click(object sender, EventArgs e)
        {
            VisiblePanel();
            pnl_AllocationDefault.Visible = true;
            pnl_SuccessMessage.Visible = false;
        }

        protected void lnk_Coefficients_Click(object sender, EventArgs e)
        {
            VisiblePanel();
            pnl_Coefficients.Visible = true;
            pnl_SuccessMessage.Visible = false;
        }

        [PresentationLayerException]
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            var editAllocationStructureResultDto = new EditAllocationStructureResultDto()
            {
                EmployeeMembershipId = Convert.ToInt32(hf_EmployeeMembershipId.Value),
                Position = tb_PositionTable.Text,
                SectionId = Convert.ToInt32(ddl_Section.SelectedValue ),
                OrganizationalUnitId = Convert.ToInt32(ddl_OrganizationalUnit.SelectedValue),
                OrganizationalCellId = Convert.ToInt32(ddl_OrganizationalCell.SelectedValue),
                DirectSupervisorId = Convert.ToInt32(hf_DirectSupervisorId.Value),
            };

            var result = PageMethodsHelper.InvokeWebAPI<EditAllocationStructureResultDto>(
                WebAPIVariables.editAllocationStructure, PageMethodsHelper.ObjectToUrlParam(editAllocationStructureResultDto)).FirstOrDefault();

            if (result.Success)
            {
                pnl_SuccessMessage.Visible = true;
                pnl_SuccessMessage.Style.Clear();
                pnl_SuccessMessage.Style.Add("display", "inline");
            }
        }

        [PresentationLayerException]
        protected void btn_Restore_Click(object sender, EventArgs e)
        {
            GetData();
            InitData();
            pnl_SuccessMessage.Visible = false;
        }

        [PresentationLayerException]
        protected void btn_AddRow_Click(object sender, EventArgs e)
        {
            _listStructureAndLocationDto = (List<StructureAndLocationDto>)Session[SessionVariables.listStructureAndLocationCoefficient];
            var newValue = new StructureAndLocationDto();
            _listStructureAndLocationDto.Add(newValue);

            this.gv_Coefficients.DataSource = _listStructureAndLocationDto;
            this.gv_Coefficients.DataBind();
        }

        [PresentationLayerException]
        protected void AddRow_Click(object sender, EventArgs e)
        {
            string id = (string)Session[SessionVariables.hf_EmployeeID];
            Session[SessionVariables.hf_EmployeeID] = null;
            if (string.IsNullOrEmpty(id))
                return;

            var esc = new EmployeeSearchCriteria() { EmployeeID = Convert.ToInt32(id) };
            _directSupervisorDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(
                WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc)).FirstOrDefault();

            if (_directSupervisorDto != null)
            {
                lbl_DirectSupervisor.Text = _directSupervisorDto.FirstName + " " + _directSupervisorDto.LastName;
                hf_DirectSupervisorId.Value = _directSupervisorDto.Id.ToString();
            }
            else
                lbl_DirectSupervisor.Text = Translate("Common", "Lack");

            up_SearchForss.Update();
        }

        [PresentationLayerException]
        protected void gv_Coefficients_RowCommand(object sender, GridViewCommandEventArgs e)
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

        #endregion
        #region Private methods

        private void CheckPermissions()
        {
        }

        private void CommandEdit(GridViewCommandEventArgs e)
        {
            _listOrganizationalUnitDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.organizationalUnits);
            _listOrganizationalCellDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.organizationalCells);
            _listSzpartaDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.szparta);

            if (_listOrganizationalUnitDto == null || _listOrganizationalCellDto == null || _listSzpartaDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.ApplicationsHRStructureAndLocationGetData, SessionUser.Id);

            SetDropDownListInGrid(e, 2, _listOrganizationalUnitDto);
            SetDropDownListInGrid(e, 3, _listOrganizationalCellDto);
            SetDropDownListInGrid(e, 4, _listSzpartaDto);

            _rowIndex = int.Parse(e.CommandArgument.ToString());
            _gridView.SelectedIndex = _rowIndex;

            EditGrid(_gridView, _rowIndex, 2);
            EditGrid(_gridView, _rowIndex, 3);
            EditGrid(_gridView, _rowIndex, 4);
            EditGrid(_gridView, _rowIndex, 5);
            SetValueInGrid(_gridView, _rowIndex, 5);

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
                var esc = new StructureAndLocationDto()
                {
                    Id = Convert.ToInt32(_id.Text),
                    UserId = SessionUser.Id
                };
                PageMethodsHelper.InvokeWebAPI<StructureAndLocationResultDto>(
                    WebAPIVariables.deleteCoefficients, PageMethodsHelper.ObjectToUrlParam(esc)).FirstOrDefault();
            }

            _listStructureAndLocationDto = PageMethodsHelper.InvokeWebAPI<StructureAndLocationDto>(
                WebAPIVariables.structureAndLocation, "?employeeId=" + GetIdFromUrl());

            Session[SessionVariables.listStructureAndLocationCoefficient] = _listStructureAndLocationDto;
            this.gv_Coefficients.DataSource = _listStructureAndLocationDto;
            this.gv_Coefficients.DataBind();
        }

        private void CommandSave(GridViewCommandEventArgs e)
        {
            _rowIndex = int.Parse(e.CommandArgument.ToString());
            _gridView.SelectedIndex = _rowIndex;
            _id = (Label)_gridView.Rows[_rowIndex].FindControl("IdLabel");
            _ddl_OrganizationalUnit = (DropDownList)_gridView.Rows[_rowIndex].FindControl("ddl_OrganizationalUnit");
            _ddl_OrganizationalCell = (DropDownList)_gridView.Rows[_rowIndex].FindControl("ddl_OrganizationalCell");
            _ddl_Silo = (DropDownList)_gridView.Rows[_rowIndex].FindControl("ddl_Silo");
            _tb_Coefficient = (TextBox)_gridView.Rows[_rowIndex].FindControl("Coefficient");            

            SaveGridDropDownList(_gridView, _rowIndex, 2);
            SaveGridDropDownList(_gridView, _rowIndex, 3);
            SaveGridDropDownList(_gridView, _rowIndex, 4);
            SaveGridTextBox(_gridView, _rowIndex, 5);

            Save();

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

            _listStructureAndLocationDto = PageMethodsHelper.InvokeWebAPI<StructureAndLocationDto>(
                WebAPIVariables.structureAndLocation, "?employeeId=" + GetIdFromUrl());

            Session[SessionVariables.listStructureAndLocationCoefficient] = _listStructureAndLocationDto;
            this.gv_Coefficients.DataSource = _listStructureAndLocationDto;
            this.gv_Coefficients.DataBind();
        }

        private void SaveNew()
        {
            var value = new StructureAndLocationDto()
            {
                Id = 0,
                EmployeeId = GetIdFromUrl(),
                OrganizationalUnitId = Convert.ToInt32(_ddl_OrganizationalUnit.Text),
                OrganizationalCellId = Convert.ToInt32(_ddl_OrganizationalCell.Text),
                SiloId = Convert.ToInt32(_ddl_Silo.Text),
                Coefficient = Convert.ToDouble(_tb_Coefficient.Text)
            };

            var v = PageMethodsHelper.InvokeWebAPI<StructureAndLocationResultDto>(
                    WebAPIVariables.saveCoefficients, 
                    PageMethodsHelper.ObjectToUrlParam(value)
                ).FirstOrDefault();

            _id.Text = v.Id.ToString();            
        }

        private void SaveOld()
        {
            var value = new StructureAndLocationDto()
            {
                Id = Convert.ToInt32(_id.Text),
                EmployeeId = GetIdFromUrl(),
                OrganizationalUnitId = Convert.ToInt32(_ddl_OrganizationalUnit.Text),
                OrganizationalCellId = Convert.ToInt32(_ddl_OrganizationalCell.Text),
                SiloId = Convert.ToInt32(_ddl_Silo.Text),
                Coefficient = Convert.ToDouble(_tb_Coefficient.Text)
            };

            var v = PageMethodsHelper.InvokeWebAPI<StructureAndLocationResultDto>(
                    WebAPIVariables.saveCoefficients,
                    PageMethodsHelper.ObjectToUrlParam(value)
                ).FirstOrDefault();
        }

        private void EditGrid(GridView gridView, int rowIndex, int columnIndex)
        {
            Control displayControl = gridView.Rows[rowIndex].Cells[columnIndex].Controls[1];
            displayControl.Visible = false;
            Control editControl = gridView.Rows[rowIndex].Cells[columnIndex].Controls[3];
            editControl.Visible = true;
            gridView.Rows[rowIndex].Cells[columnIndex].Attributes.Clear();

            ScriptManager.RegisterStartupScript(this, GetType(), "SetFocus",
                string.Format("document.getElementById('{0}').focus();", editControl.ClientID), true);

            if (editControl is TextBox)
            {
                ((TextBox)editControl).Attributes.Add("onfocus", "this.select()");
            }
        }

        private void SetValueInGrid(GridView gridView, int rowIndex, int columnIndex)
        {
            Label displayControl = (Label)gridView.Rows[rowIndex].Cells[columnIndex].Controls[1];
            displayControl.Visible = false;
            TextBox editControl = (TextBox)gridView.Rows[rowIndex].Cells[columnIndex].Controls[3];
            editControl.Visible = true;
            gridView.Rows[rowIndex].Cells[columnIndex].Attributes.Clear();

            editControl.Text = displayControl.Text;
        }

        private void SaveGridDropDownList(GridView gridView, int rowIndex, int columnIndex)
        {
            Label displayControl = (Label)gridView.Rows[rowIndex].Cells[columnIndex].Controls[1];
            displayControl.Visible = true;
            DropDownList editControl = (DropDownList)gridView.Rows[rowIndex].Cells[columnIndex].Controls[3];
            displayControl.Text = editControl.SelectedItem.Text;
            editControl.Visible = false;
            gridView.Rows[rowIndex].Cells[columnIndex].Attributes.Clear();
        }

        private void SaveGridTextBox(GridView gridView, int rowIndex, int columnIndex)
        {
            Label displayControl = (Label)gridView.Rows[rowIndex].Cells[columnIndex].Controls[1];
            displayControl.Visible = true;
            TextBox editControl = (TextBox)gridView.Rows[rowIndex].Cells[columnIndex].Controls[3];
            displayControl.Text = editControl.Text;
            editControl.Visible = false;
            gridView.Rows[rowIndex].Cells[columnIndex].Attributes.Clear();
        }

        private void VisiblePanel()
        {
            pnl_Coefficients.Visible = false;
            pnl_AllocationDefault.Visible = false;
        }

        private void SetDropDownListInGrid(GridViewCommandEventArgs e, int columnIndex, List<DictionaryDto> list)
        {
            var rowIndex = int.Parse(e.CommandArgument.ToString());
            DropDownList dropDownList = (DropDownList)_gridView.Rows[rowIndex].Cells[columnIndex].Controls[3];
            var label = (Label)_gridView.Rows[rowIndex].Cells[columnIndex].Controls[1];            

            PageMethodsHelper.SetDropDownList(dropDownList, list);
            dropDownList.SelectedValue = list.Where(x => x.Name.Equals(label.Text)).Select(y => y.Id).FirstOrDefault().ToString();
        }

        #endregion
    }
}