using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Basic.Presentation.Attributes;
using Workflow.Dashboard.Interface.Presentation.Criteria;
using Workflow.Dashboard.Interface.Presentation.Dto;
using Workflow.Basic.Presentation.Helper;
using Workflow.Basic.Presentation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Basic.Presentation.BasicModels;

namespace Workflow.Web.Forms.App.Views.Shared.Partials
{
    public partial class WUC_SearchEmployees : System.Web.UI.UserControl
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

        private SessionUser _sessionUser;

        #endregion

        #region Init

        protected void Page_Load(object sender, EventArgs e)
        {
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
            _sessionUser = (SessionUser)Session[SessionVariables.user];
            CheckPermissions();

            _listSectionDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.sections);
            _listOrganizationalUnitDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.organizationalUnits);
            _listOrganizationalCellDto = PageMethodsHelper.InvokeWebAPI<DictionaryDto>(WebAPIVariables.organizationalCells);

            if (_listSectionDto == null || _listOrganizationalUnitDto == null || _listOrganizationalCellDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.WUC_SearchEmployeesGetData, _sessionUser.Id);

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

            var esc = new EmployeeSearchCriteria()
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Section = ddl_Section.SelectedItem.Value,
                OrganizationalUnit = ddl_OrganizationalUnit.SelectedItem.Value,
                OrganizationalCell = ddl_OrganizationalCell.SelectedItem.Value,
                EmployeeNumber = tb_EmployeeNumber.Text
            };

            _listEmployeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc));
            if (_listEmployeeDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.WUC_SearchEmployeesbtn_SearchFor_Click, _sessionUser.Id);

            GridValueTranslate();
            gv_EmployeeList.DataSource = _listEmployeeDto;
            gv_EmployeeList.DataBind();

            up_SearchFor.Update();
        }

        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            tb_FirstName.Text = string.Empty;
            tb_LastName.Text = string.Empty;
            ddl_Section.SelectedIndex = 0;
            ddl_OrganizationalUnit.SelectedIndex = 0;
            ddl_OrganizationalCell.SelectedIndex = 0;
            tb_EmployeeNumber.Text = string.Empty;

            _listEmployeeDto = new List<EmployeeDto>();

            gv_EmployeeList.DataSource = _listEmployeeDto;
            gv_EmployeeList.DataBind();

            up_SearchFor.Update();
        }

        protected void gv_EmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Check")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow gvRow = gv_EmployeeList.Rows[index];

                //Page page = HttpContext.Current.Handler as Page;
                HiddenField employeeID = (HiddenField)Parent.FindControl("hf_EmployeeID");
                employeeID.Value = gvRow.Cells[0].Text;

                Session[SessionVariables.hf_EmployeeID] = gvRow.Cells[0].Text;

                UpdatePanel pdatePanel = (UpdatePanel)Parent.FindControl("up_SearchForss");
                pdatePanel.Update();
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
                EmployeeNumber = tb_EmployeeNumber.Text
            };

            _listEmployeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.searchEmployee, PageMethodsHelper.ObjectToUrlParam(esc));
            if (_listEmployeeDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.WUC_SearchEmployeesGv_EmployeeList_PageIndexChanging, _sessionUser.Id);

            GridValueTranslate();
            gv_EmployeeList.PageIndex = e.NewPageIndex;
            gv_EmployeeList.DataSource = _listEmployeeDto;
            gv_EmployeeList.DataBind();

            up_SearchFor.Update();
        }

        protected void gv_EmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgDownload = (ImageButton)e.Row.FindControl("btn_Check");
                string id = e.Row.Cells[0].Text;

                imgDownload.ImageUrl = @"~\Content\ThumbnailEmployee\" + id + ".png";
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
                temp = item.BuildGridValueTwo();
                temp = temp.Replace("#EmployeeNumberLabel#", Translate("Common", "EmployeeNumberLabel"));
                temp = temp.Replace("#EmailLabel#", Translate("Common", "EmailLabel"));
                item.SetGridValue(temp);
            }
        }

        protected string Translate(string classKey, string resourceKey)
        {
            return HttpContext.GetGlobalResourceObject(classKey, resourceKey, CultureInfo.CurrentCulture).ToString();
        }    

        #endregion       
    }
}