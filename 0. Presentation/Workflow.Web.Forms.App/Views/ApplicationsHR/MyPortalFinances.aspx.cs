using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Basic.Presentation.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.Dashboard.Interface.Presentation.Dto;
using Workflow.Basic.Presentation;
using Workflow.Basic.Presentation.BasicModels;
using Workflow.Basic.Presentation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Basic.Presentation.Helper;
using Workflow.Dashboard.Interface.Application.Abstract;
using Workflow.Dashboard.Interface.Presentation.ServicesDto;

namespace Workflow.Web.Forms.App.Views.ApplicationsHR
{
    public partial class MyPortalFinances : BasePage
    {
        #region Query



        #endregion
        #region Command



        #endregion
        #region Dto

        private EmployeeDto _employeeDto;
        private EmployeeMembershipDto _employeeMembershipDto;
        private EmployeeSalaryDto _employeeSalaryDto;
        private EmployeeContractDto _employeeContractDto;

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
            InitData(PageNumbers.CardIndexMyPortalFinances, (SessionUser)Session[SessionVariables.user]);

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

            _employeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.employee, "?id=" + _employeeID).FirstOrDefault();
            _employeeMembershipDto = PageMethodsHelper.InvokeWebAPI<EmployeeMembershipDto>(WebAPIVariables.employeeMembership, "?id=" + _employeeID).FirstOrDefault();

            _employeeSalaryDto = PageMethodsHelper.InvokeWebAPI<EmployeeSalaryDto>(WebAPIVariables.employeeSalary, "?id=" + _employeeID).FirstOrDefault();
            _employeeContractDto = PageMethodsHelper.InvokeWebAPI<EmployeeContractDto>(WebAPIVariables.employeeContract, "?id=" + _employeeID).FirstOrDefault();

            if (_employeeDto == null || _employeeMembershipDto == null || _employeeSalaryDto == null || _employeeContractDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.MyPortalFinancesGetData, SessionUser.Id);

            var cph = (ContentPlaceHolder)Master.Master.FindControl("MainContent");
            ((Image)cph.FindControl("btn_Image")).ImageUrl = @"~\Content\ThumbnailEmployee\" + _employeeID + ".png";

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

            //pnl_BasicSalary
            lbl_BaseSalary.Text = _employeeSalaryDto.BaseSalary.ToString("0.00");
            lbl_DiscretionaryBonus.Text = _employeeSalaryDto.DiscretionaryBonus.ToString("0.00");
            lbl_MasterBonus.Text = _employeeSalaryDto.MasterBonus.ToString("0.00");
            lbl_Bonus.Text = _employeeSalaryDto.Bonus.ToString("0.00");
            lbl_EquivalentVacation.Text = _employeeSalaryDto.EquivalentVacation.ToString();

            //pnl_Deductions


            //pnl_Contracts
            lbl_DimensionTime.Text = _employeeContractDto.DimensionTime.ToString("0.00");
            lbl_DateAgreement.Text = _employeeContractDto.FromDate.ToShortDateString();
            lbl_EndDateContract.Text = _employeeContractDto.ToDate.Year == 1 ? string.Empty : _employeeContractDto.ToDate.ToShortDateString();
            lbl_DateDismissal.Text = _employeeContractDto.DismissDate.Year == 1 ? string.Empty : _employeeContractDto.DismissDate.ToShortDateString();
            lbl_TypeEmploymentContract.Text = _employeeContractDto.TypeContract;
        }

        #endregion

        #region Page methods

        protected void lnk_BasicSalary_Click(object sender, EventArgs e)
        {
            VisiblePanel();
            pnl_BasicSalary.Visible = true;
        }

        protected void lnk_Deductions_Click(object sender, EventArgs e)
        {
            VisiblePanel();
            pnl_Deductions.Visible = true;
        }

        protected void lnk_Contracts_Click(object sender, EventArgs e)
        {
            VisiblePanel();
            pnl_Contracts.Visible = true;
        }

        #endregion
        #region Private methods

        private void CheckPermissions()
        {

        }

        private void VisiblePanel()
        {
            pnl_BasicSalary.Visible = false;
            pnl_Deductions.Visible = false;
            pnl_Contracts.Visible = false;
        }

        #endregion
    }
}