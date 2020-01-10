using CQRS.Base.DDD.Application.BaseDto;
using CQRS.Base.DDD.Domain.Exceptions;
using Mercedes.BasicCore.Application.Attributes;
using Mercedes.BasicCore.Domain.Entities.Dictionaries;
using Mercedes.CardIndex.Interface.Presentation.Abstract;
using Mercedes.CardIndex.Interface.Presentation.Criteria;
using Mercedes.CardIndex.Interface.Presentation.Dto;
using Mercedes.PresentationCore;
using Mercedes.PresentationCore.BasicModels;
using Mercedes.PresentationCore.Infrastructure;
using Mercedes.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mercedes.WebApp.Views.CardIndex
{
    public partial class EmployeeList : BasePage
    {
        #region Query

        private IEmployeeFinder _employeeFinder;

        #endregion
        #region Command



        #endregion
        #region Dto

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
            Init(PageNumbers.CardIndexEmployeeList, (SessionUser)Session[SessionVariables.user]);

            Resolve();
            if (!IsPostBack)
            {                
                GetData();
                InitData();
            }
        }

        private void Resolve()
        {
            _employeeFinder = ContainerInit._container.Resolve<IEmployeeFinder>();
        }

        [PresentationException]
        private AppActionResult GetData()
        {
            _listEmployeeDto = _employeeFinder.FindEmployees(new EmployeeSearchCriteria());
            if (_listEmployeeDto == null)
                throw new OwnAppException("NoData", (int)ErrorNumbersApp.EmployeeListGetData);

            return new AppActionResult() { Success = true };
        }

        private void InitData()
        {
            gv_EmployeeList.DataSource = _listEmployeeDto;
            gv_EmployeeList.DataBind();
        }

        #endregion

        #region Page methods

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            _listEmployeeDto = _employeeFinder.FindEmployees(
                    new EmployeeSearchCriteria()
                    {
                        ContainsText = tb_Search.Text
                    }
                );
            InitData();
        }

        protected void gv_EmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Check")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow gvRow = gv_EmployeeList.Rows[index];

                Response.Redirect("Employee.aspx?id=" + gvRow.Cells[0].Text);
            }
        }

        protected void gv_EmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            _listEmployeeDto = _employeeFinder.FindEmployees(
                    new EmployeeSearchCriteria()
                    {
                        ContainsText = tb_Search.Text
                    }
                );

            gv_EmployeeList.PageIndex = e.NewPageIndex;
            gv_EmployeeList.DataSource = _listEmployeeDto;
            gv_EmployeeList.DataBind();
        }

        #endregion
        #region Private methods



        #endregion
    }
}