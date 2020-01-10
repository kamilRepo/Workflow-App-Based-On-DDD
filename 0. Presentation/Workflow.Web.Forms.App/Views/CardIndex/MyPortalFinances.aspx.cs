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
using Workflow.HR.Interface.Presentation.FindersDto;
using Workflow.Basic.Domain.Domain.Entities.Dictionaries;
using System.IO;

namespace Workflow.Web.Forms.App.Views.CardIndex
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
        private List<SalaryDeductionsDto> _listSalaryDeductionsDto;

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
            if (_employeeID == 0)
            {
                _employeeID = SessionUser.Id;
                lbl_EndDateContractLabel.Visible = false;
                lbl_EndDateContract.Visible = false;
                lbl_DateDismissalLabel.Visible = false;
                lbl_DateDismissal.Visible = false;
            }

            CheckPermissions();

            _employeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.employee, "?id=" + _employeeID).FirstOrDefault();
            _employeeMembershipDto = PageMethodsHelper.InvokeWebAPI<EmployeeMembershipDto>(WebAPIVariables.employeeMembership, "?id=" + _employeeID).FirstOrDefault();

            _employeeSalaryDto = PageMethodsHelper.InvokeWebAPI<EmployeeSalaryDto>(WebAPIVariables.employeeSalary, "?id=" + _employeeID).FirstOrDefault();
            _employeeContractDto = PageMethodsHelper.InvokeWebAPI<EmployeeContractDto>(WebAPIVariables.employeeContract, "?id=" + _employeeID).FirstOrDefault();

            if (_employeeDto == null || _employeeMembershipDto == null || _employeeSalaryDto == null || _employeeContractDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.MyPortalFinancesGetData, SessionUser.Id);

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

        protected void lnk_Hestia_Click(object sender, EventArgs e)
        {
            UpdateDeductionPanel(uc_DeductionsFromSalary, SalaryDeductionsType.Hestia);
        }

        protected void lnk_MedicalCare_Click(object sender, EventArgs e)
        {
            UpdateDeductionPanel(uc_DeductionsFromSalary, SalaryDeductionsType.MedicalCare);
        }

        protected void lnk_PZUInsurance_Click(object sender, EventArgs e)
        {
            UpdateDeductionPanel(uc_DeductionsFromSalary, SalaryDeductionsType.PZUInsurance);
        }

        protected void lnk_ZFSS_Click(object sender, EventArgs e)
        {
            UpdateDeductionPanel(uc_DeductionsZFSS, SalaryDeductionsType.ZFSS);
        }

        protected void lnk_LoansOther_Click(object sender, EventArgs e)
        {
            UpdateDeductionPanel(uc_DeductionsLoansOther, SalaryDeductionsType.LoansOther);
        }

        protected void lnk_Multisport_Click(object sender, EventArgs e)
        {
            UpdateDeductionPanel(uc_DeductionsFromSalary, SalaryDeductionsType.Multisport);
        }

        protected void lnk_CompanyCar_Click(object sender, EventArgs e)
        {
            UpdateDeductionPanel(uc_DeductionsCompanyCar, SalaryDeductionsType.CompanyCar);
        }

        protected void lnk_BasicSalary_Click(object sender, EventArgs e)
        {
            VisiblePanel();
            pnl_BasicSalary.Visible = true;
        }

        protected void lnk_Deductions_Click(object sender, EventArgs e)
        {
            VisiblePanel();
            UpdateDeductionPanel(uc_DeductionsFromSalary, SalaryDeductionsType.Hestia);
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

        private void UpdateDeductionPanel(UserControl userControl, SalaryDeductionsType salaryDeductionsType)
        {
            _employeeID = GetIdFromUrl();
            if (_employeeID == 0)
                _employeeID = SessionUser.Id;

            VisibleUserControl();
            userControl.Visible = true;
            _listSalaryDeductionsDto = PageMethodsHelper.InvokeWebAPI<SalaryDeductionsDto>(
                WebAPIVariables.salaryDeductions, 
                "?SalaryDeductionsType=" + (int)salaryDeductionsType +
                "&employeeId=" + _employeeID);

            var gv_Deductions = (GridView)userControl.FindControl("gv_Deductions");
            var up_Deductions = (UpdatePanel)userControl.FindControl("up_Deductions");

            foreach (var item in _listSalaryDeductionsDto)
            {
                item.SetFromDateST();
                item.SetToDateST();
            }

            gv_Deductions.DataSource = _listSalaryDeductionsDto;
            gv_Deductions.DataBind();
            up_Deductions.Update();
        }

        private void VisibleUserControl()
        {
            uc_DeductionsFromSalary.Visible = false;
            uc_DeductionsZFSS.Visible = false;
            uc_DeductionsLoansOther.Visible = false;
            uc_DeductionsCompanyCar.Visible = false;
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