using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Basic.Presentation.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Dashboard.Interface.Application.Abstract;
using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.Dashboard.Interface.Presentation.Criteria;
using Workflow.Dashboard.Interface.Presentation.Dto;
using Workflow.Basic.Presentation;
using Workflow.Basic.Presentation.BasicModels;
using Workflow.Basic.Presentation.Infrastructure;
using Workflow.Web.Forms.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Basic.Presentation.Helper;
using System.IO;

namespace Workflow.Web.Forms.App
{
    public partial class Employee : BasePage
    {        
        #region Query



        #endregion
        #region Command



        #endregion
        #region Dto

        private EmployeeDto _employeeDto;
        private EmployeeMembershipDto _employeeMembershipDto;
        private List<EmployeeDto> _listDirectReportsDto;
        private List<EmployeeDto> _listReportsToDto;

        #endregion
        #region Core



        #endregion
        #region Field and properties



        #endregion        
        #region View elements



        #endregion
        #region Session

        

        #endregion               

        #region Init

        protected void Page_Load(object sender, EventArgs e)
        {
            InitData(PageNumbers.CardIndexEmployee, (SessionUser)Session[SessionVariables.user]);

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

            CheckPermissions();

            var esc = new EmployeeSearchCriteria() { EmployeeID = GetIdFromUrl() };
            _employeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc)).FirstOrDefault();

            _employeeMembershipDto = PageMethodsHelper.InvokeWebAPI<EmployeeMembershipDto>(WebAPIVariables.employeeMembership, "?id=" + GetIdFromUrl()).FirstOrDefault();
            
            esc = new EmployeeSearchCriteria() { EmployeeID = _employeeDto.DirectSupervisorID };
            _listDirectReportsDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc));

            esc = new EmployeeSearchCriteria() { DirectSupervisorID = _employeeDto.Id };
            _listReportsToDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc));            

            var basic = @"~\Content\ThumbnailEmployee\";
            var employeeImage = GetIdFromUrl() + ".png";
            var emptyImage = "empty.png";

            var dataFile = Server.MapPath(basic) + employeeImage;

            if (File.Exists(dataFile))
                btn_Image.ImageUrl = basic + employeeImage;
            else
                btn_Image.ImageUrl = basic + emptyImage;

            if (_employeeDto == null || _employeeMembershipDto == null || 
                _listDirectReportsDto == null || _listReportsToDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.EmployeeGetData, SessionUser.Id);

            SetGridView(gv_ReportsTo, _listDirectReportsDto);
            SetGridView(gv_DirectReports, _listReportsToDto);

            return new ApplicationActionResult() { Success = true };
        }

        private void InitData()
        {
            lbl_nameSurname.Text = _employeeDto.LastName + " " + _employeeDto.FirstName;
            lbl_EmployeeNumber.Text = _employeeDto.EmployeeNumber;
            lbl_Position.Text = _employeeMembershipDto.Position;
            lbl_PhoneNumber.Text = _employeeDto.PhoneNumber;
            lbl_MobileNumber.Text = _employeeDto.MobilePhoneNumber;
            lbl_Email.Text = _employeeDto.Email;

            lbl_Section.Text = _employeeMembershipDto.Section;
            lbl_OrganizationalUnit.Text = _employeeMembershipDto.OrganizationalUnit;
            lbl_OrganizationalCell.Text = _employeeMembershipDto.OrganizationalCell;
            lbl_Room.Text = _employeeMembershipDto.Room;
            lbl_ManagerOfBranch.Text = _employeeMembershipDto.ManagerBranchSurName + " " + _employeeMembershipDto.ManagerBranchName;
        }

        #endregion

        #region Page methods

        protected void gv_ReportsTo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgDownload = (ImageButton)e.Row.FindControl("btn_ReportsTo");
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

        [PresentationLayerException]
        protected void gv_ReportsTo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var esc = new EmployeeSearchCriteria() { EmployeeID = GetIdFromUrl() };
            _employeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc)).FirstOrDefault();

            esc = new EmployeeSearchCriteria() { DirectSupervisorID = _employeeDto.Id };
            _listReportsToDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc));

            if (_listReportsToDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.EmployeeGetData, SessionUser.Id);

            gv_ReportsTo.PageIndex = e.NewPageIndex;
            SetGridView(gv_ReportsTo, _listReportsToDto);
        }

        protected void gv_ReportsTo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Check")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow gvRow = gv_ReportsTo.Rows[index];

                Response.Redirect("Employee.aspx?id=" + gvRow.Cells[0].Text);
            }
        }

        protected void gv_DirectReports_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgDownload = (ImageButton)e.Row.FindControl("btn_DirectReports");
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

        [PresentationLayerException]
        protected void gv_DirectReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var esc = new EmployeeSearchCriteria() { EmployeeID = GetIdFromUrl() };
            _employeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc)).FirstOrDefault();

            esc = new EmployeeSearchCriteria() { DirectSupervisorID = _employeeDto.Id };
            _listDirectReportsDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc));

            if (_listDirectReportsDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.EmployeeGetData, SessionUser.Id);

            gv_DirectReports.PageIndex = e.NewPageIndex;
            SetGridView(gv_DirectReports, _listDirectReportsDto);
        }

        protected void gv_DirectReports_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Check")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow gvRow = gv_DirectReports.Rows[index];

                Response.Redirect("Employee.aspx?id=" + gvRow.Cells[0].Text);
            }
        }

        #endregion
        #region Private methods

        private void CheckPermissions()
        {

        }

        private void SetGridView(GridView gridView, List<EmployeeDto> listEmployeeDto)
        {
            GridValueTranslate(listEmployeeDto);

            gridView.DataSource = listEmployeeDto;
            gridView.DataBind();
        }

        private void GridValueTranslate(List<EmployeeDto> listEmployeeDto)
        {
            string temp;

            foreach (var item in listEmployeeDto)
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