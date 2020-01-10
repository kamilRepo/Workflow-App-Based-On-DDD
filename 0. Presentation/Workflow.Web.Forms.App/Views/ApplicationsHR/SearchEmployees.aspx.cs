using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Basic.Presentation.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.Dashboard.Interface.Presentation.Criteria;
using Workflow.Dashboard.Interface.Presentation.Dto;
using Workflow.Basic.Presentation;
using Workflow.Basic.Presentation.BasicModels;
using Workflow.Basic.Presentation.Infrastructure;
using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Basic.Presentation.Helper;
using System.IO;

namespace Workflow.Web.Forms.App.Views.ApplicationsHR
{
    public partial class SearchEmployees : BasePage
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
            InitData(PageNumbers.ApplicationsHRSearchEmployees, (SessionUser)Session[SessionVariables.user]);

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

            _listSectionDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.sections);
            _listOrganizationalUnitDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.organizationalUnits);
            _listOrganizationalCellDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.organizationalCells);

            if (_listSectionDto == null || _listOrganizationalUnitDto == null || _listOrganizationalCellDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.SearchEmployeesGetData, SessionUser.Id);

            return new ApplicationActionResult() { Success = true };
        }

        private void InitData()
        {
            PageMethodsHelper.SetDropDownList(ddl_Section, _listSectionDto);
            PageMethodsHelper.SetDropDownList(ddl_OrganizationalUnit, _listOrganizationalUnitDto);
            PageMethodsHelper.SetDropDownList(ddl_OrganizationalCell, _listOrganizationalCellDto);
        }

        #endregion

        #region Page methods

        [PresentationLayerException]
        protected void btn_SearchFor_Click(object sender, EventArgs e)
        {
            pnl_SearchResults.Visible = true;
            var esc = new EmployeeSearchCriteria()
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Position = tb_Position.Text,
                Section = ddl_Section.SelectedItem.Value,
                OrganizationalUnit = ddl_OrganizationalUnit.SelectedItem.Value,
                OrganizationalCell = ddl_OrganizationalCell.SelectedItem.Value,
                EmployeeNumber = tb_EmployeeNumber.Text
            };

            _listEmployeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc));

            GridValueTranslate();
            gv_EmployeeList.DataSource = _listEmployeeDto;
            gv_EmployeeList.DataBind();
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            pnl_SearchResults.Visible = false;
            tb_FirstName.Text = string.Empty;
            tb_LastName.Text = string.Empty;
            tb_Position.Text = string.Empty;
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
                Position = tb_Position.Text,
                Section = ddl_Section.SelectedItem.Value,
                OrganizationalUnit = ddl_OrganizationalUnit.SelectedItem.Value,
                OrganizationalCell = ddl_OrganizationalCell.SelectedItem.Value,
                EmployeeNumber = tb_EmployeeNumber.Text
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