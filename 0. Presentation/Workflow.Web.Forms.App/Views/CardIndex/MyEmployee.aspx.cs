using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Basic.Presentation.Attributes;
using Workflow.Dashboard.Interface.Application.Abstract;
using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.Dashboard.Interface.Presentation.Criteria;
using Workflow.Dashboard.Interface.Presentation.Dto;
using Workflow.Dashboard.Interface.Presentation.ServicesDto;
using Workflow.Basic.Presentation.BasicModels;
using Workflow.Basic.Presentation.Helper;
using Workflow.Basic.Presentation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Workflow.Web.Forms.App.Views.CardIndex
{
    public partial class MyEmployee : BasePage
    {
        #region Query



        #endregion
        #region Command



        #endregion
        #region Dto

        private List<DictionaryDto> _listSectionDto;
        private List<DictionaryDto> _listOrganizationalUnitDto;
        private List<DictionaryDto> _listOrganizationalCellDto;
        private List<EmployeeDto> _listEmployeeDto;
        private EmployeeDto _employeeDto;
        private EmployeeMembershipDto _employeeMembershipDto;

        #endregion
        #region Core



        #endregion
        #region Field and properties

        private int _employeeID;

        #endregion
        #region View elements



        #endregion
        #region Session



        #endregion

        #region Init

        protected void Page_Load(object sender, EventArgs e)
        {
            InitData(PageNumbers.CardIndexMyEmployee, (SessionUser)Session[SessionVariables.user]);

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
            if (_employeeID == 0)
            {
                _employeeID = SessionUser.Id;
                Session[SessionVariables.interiorID] = _employeeID;
            }else
                Session[SessionVariables.interiorID] = _employeeID;

            CheckPermissions();

            _employeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.employee, "?id=" + _employeeID).FirstOrDefault();
            _employeeMembershipDto = PageMethodsHelper.InvokeWebAPI<EmployeeMembershipDto>(WebAPIVariables.employeeMembership, "?id=" + _employeeID).FirstOrDefault();

            _listSectionDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.sections);
            _listOrganizationalUnitDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.organizationalUnits);
            _listOrganizationalCellDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.organizationalCells);

            if (_listSectionDto == null || _listOrganizationalUnitDto == null || _listOrganizationalCellDto == null ||
                _employeeDto == null || _employeeMembershipDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.MyEmployeeGetData, SessionUser.Id);

            var cph = (ContentPlaceHolder)Master.Master.FindControl("MainContent");

            var basic = @"~\Content\ThumbnailEmployee\";
            var employeeImage = SessionUser.Id + ".png";
            var emptyImage = "empty.png";

            var dataFile = Server.MapPath(basic) + employeeImage;

            if (File.Exists(dataFile))
                ((Image)cph.FindControl("btn_Image")).ImageUrl = basic + employeeImage;
            else
                ((Image)cph.FindControl("btn_Image")).ImageUrl = basic + emptyImage;

            ((Panel)cph.FindControl("pnl_Employee")).Visible = false;
            if (GetIdFromUrl() != 0)
            {
                employeeImage = _employeeID + ".png";
                dataFile = Server.MapPath(basic) + employeeImage;

                if (File.Exists(dataFile))
                    ((Image)cph.FindControl("btn_ImageEmployee")).ImageUrl = basic + employeeImage;
                else
                    ((Image)cph.FindControl("btn_ImageEmployee")).ImageUrl = basic + emptyImage;

                ((Panel)cph.FindControl("pnl_Employee")).Visible = true;
                ((Panel)cph.FindControl("pnl_MainEmployee")).Visible = false;
            }
            else
                ((Panel)cph.FindControl("pnl_MainEmployee")).Visible = true;

            return new ApplicationActionResult() { Success = true };
        }

        private void InitData()
        {
            lbl_nameSurname.Text = _employeeDto.LastName + " " + _employeeDto.FirstName;
            lbl_EmployeeNumber.Text = _employeeDto.EmployeeNumber;
            lbl_Position.Text = _employeeMembershipDto.Position;

            PageMethodsHelper.SetDropDownList(ddl_Section, _listSectionDto);
            PageMethodsHelper.SetDropDownList(ddl_OrganizationalUnit, _listOrganizationalUnitDto);
            PageMethodsHelper.SetDropDownList(ddl_OrganizationalCell, _listOrganizationalCellDto);

            btn_SearchFor_Click(null, null);
        }

        #endregion

        #region Page methods

        [PresentationLayerException]
        protected void btn_SearchFor_Click(object sender, EventArgs e)
        {
            pnl_EmployeeList.Visible = true;

            var esc = new EmployeeSearchCriteria()
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Section = ddl_Section.SelectedItem.Value,
                OrganizationalUnit = ddl_OrganizationalUnit.SelectedItem.Value,
                OrganizationalCell = ddl_OrganizationalCell.SelectedItem.Value,
                EmployeeNumber = tb_EmployeeNumber.Text,
                DirectSupervisorID = (int)Session[SessionVariables.interiorID]
            };

            _listEmployeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc));

            GridValueTranslate();
            gv_EmployeeList.DataSource = _listEmployeeDto;
            gv_EmployeeList.DataBind();
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            pnl_EmployeeList.Visible = false;
            tb_FirstName.Text = string.Empty;
            tb_LastName.Text = string.Empty;
            ddl_Section.SelectedIndex = 0;
            ddl_OrganizationalUnit.SelectedIndex = 0;
            ddl_OrganizationalCell.SelectedIndex = 0;
            tb_EmployeeNumber.Text = string.Empty;

            _listEmployeeDto = new List<EmployeeDto>();

            gv_EmployeeList.DataSource = _listEmployeeDto;
            gv_EmployeeList.DataBind();
        }

        protected void gv_EmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Check")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow gvRow = gv_EmployeeList.Rows[index];

                Response.Redirect("MyPortal.aspx?id=" + gvRow.Cells[0].Text);
            }
        }

        [PresentationLayerException]
        protected void gv_EmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var esc = new EmployeeSearchCriteria()
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Section = ddl_Section.SelectedItem.Value,
                OrganizationalUnit = ddl_OrganizationalUnit.SelectedItem.Value,
                OrganizationalCell = ddl_OrganizationalCell.SelectedItem.Value,
                EmployeeNumber = tb_EmployeeNumber.Text,
                DirectSupervisorID = (int)Session[SessionVariables.interiorID]
            };

            _listEmployeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc));

            GridValueTranslate();
            gv_EmployeeList.PageIndex = e.NewPageIndex;
            gv_EmployeeList.DataSource = _listEmployeeDto;
            gv_EmployeeList.DataBind();
        }

        protected void gv_EmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgDownload = (ImageButton)e.Row.FindControl("btn_Check");
                string id = e.Row.Cells[0].Text;

                var basic = @"~\Content\ThumbnailEmployee\";
                var employeeImage = id + ".png";
                var emptyImage = "empty.png";

                var dataFile = Server.MapPath(basic) + employeeImage;

                if (File.Exists(dataFile))
                    imgDownload.ImageUrl = basic + employeeImage;
                else
                    imgDownload.ImageUrl = basic + emptyImage;
            }
        }

        #endregion
        #region Private methods

        private void CheckPermissions()
        {
            if (SessionUser.Id == _employeeID)
                return;

            var value = new AccessPolicyDto(SessionUser.Id, _employeeID);
            value = PageMethodsHelper.InvokeWebAPI<AccessPolicyDto>(
                        WebAPIVariables.myPortal,
                        PageMethodsHelper.ObjectToUrlParam(value)
                    ).FirstOrDefault();

            if (!value.IsAccess)
                Response.Redirect("~/Views/Shared/LackPermissions.aspx");
        }

        private void GridValueTranslate()
        {
            string temp;

            foreach (var item in _listEmployeeDto)
            {
                temp = item.BuildGridValue();
                temp = temp.Replace("#PhoneNumberLabel#", Translate("Common", "PhoneNumberLabel"));
                temp = temp.Replace("#MobileNumberLabel#", Translate("Common", "MobileNumberLabel"));
                temp = temp.Replace("#EmailLabel#", Translate("Common", "EmailLabel"));
                item.SetGridValue(temp);
            }
        }

        #endregion       
    }
}