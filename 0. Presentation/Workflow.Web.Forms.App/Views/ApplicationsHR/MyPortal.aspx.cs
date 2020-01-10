using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Dashboard.Interface.Application.Abstract;
using Workflow.Dashboard.Interface.Presentation.Abstract;
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
using Workflow.Basic.Presentation.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.Web.Forms.App.Views.ApplicationsHR
{
    public partial class MyPortal : BasePage
    {
        #region Query



        #endregion
        #region Command



        #endregion
        #region Dto

        private EmployeeDto _employeeDto;
        private EmployeeMembershipDto _employeeMembershipDto;
        private List<EmployeeAddressDto> _listEmployeeAddressDto;

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
            InitData(PageNumbers.ApplicationsHRMyPortal, (SessionUser)Session[SessionVariables.user]);

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

            _listEmployeeAddressDto = PageMethodsHelper.InvokeWebAPI<EmployeeAddressDto>(WebAPIVariables.employeeAddress, "?id=" + _employeeID);

            if (_employeeDto == null || _employeeMembershipDto == null ||
                _listEmployeeAddressDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.ApplicationsHRMyPortalGetData, SessionUser.Id);

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
            tb_PhoneNumber.Text = _employeeDto.PhoneNumber;
            tb_MobileNumber.Text = _employeeDto.MobilePhoneNumber;
            tb_Email.Text = _employeeDto.Email;

            //pnl_PersonalInformation
            var address = _listEmployeeAddressDto.Where(x => x.IsCorrespondence == false).FirstOrDefault();
            tb_Spot.Text = address.City;
            tb_Community.Text = address.PostOffice;
            tb_PostalCode.Text = address.PostalCode;
            tb_Street.Text = address.Street;
            tb_StreetNo.Text = address.BuildingNo;
            tb_Premises.Text = address.LocalNo;

            address = _listEmployeeAddressDto.Where(x => x.IsCorrespondence == true).FirstOrDefault();
            if (address == null)
                address = _listEmployeeAddressDto.Where(x => x.IsCorrespondence == false).FirstOrDefault();

            tb_SpotCo.Text = address.City;
            tb_CommunityCo.Text = address.PostOffice;
            tb_PostalCodeCo.Text = address.PostalCode;
            tb_StreetCo.Text = address.Street;
            tb_StreetNoCo.Text = address.BuildingNo;
            tb_PremisesCo.Text = address.LocalNo;

            tb_Pesel.Text = _employeeDto.Pesel;
            tb_Education.Text = _employeeDto.Education;

            var value = new List<SalaryDeductionsDto>();
            var v = new SalaryDeductionsDto();
            value.Add(v);

            this.gv_Additions.DataSource = value;
            this.gv_Additions.DataBind();
            this.gv_MedicalExamination.DataSource = value;
            this.gv_MedicalExamination.DataBind();
        }

        #endregion

        #region Page methods


        protected void lnk_PersonalInformation_Click(object sender, EventArgs e)
        {
            VisiblePanel();
            pnl_PersonalInformation.Visible = true;
            pnl_SuccessMessage.Visible = false;
        }

        protected void lnk_MedicalExamination_Click(object sender, EventArgs e)
        {
            VisiblePanel();
            pnl_MedicalExamination.Visible = true;
            pnl_SuccessMessage.Visible = false;
        }

        protected void lnk_Additions_Click(object sender, EventArgs e)
        {
            VisiblePanel();
            pnl_Additions.Visible = true;
            pnl_SuccessMessage.Visible = false;
        }

        [PresentationLayerException]
        protected void btn_Restore_Click(object sender, EventArgs e)
        {
            GetData();
            InitData();
            pnl_SuccessMessage.Visible = false;
        }

        [PresentationLayerException]
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            var editDataPortalResultDto = new EditDataPortalResultDto()
            {
                EmployeeId = GetIdFromUrl(),
                PhoneNumber = tb_PhoneNumber.Text,
                MobilePhoneNumber = tb_MobileNumber.Text,
                Email = tb_Email.Text,
                Pesel = tb_Pesel.Text,
                Education = tb_Education.Text,
                City = tb_Spot.Text,
                PostOffice = tb_Community.Text,
                PostalCode = tb_PostalCode.Text,
                Street = tb_Street.Text,
                BuildingNo = tb_StreetNo.Text,
                LocalNo = tb_Premises.Text,     
                CityCo = tb_SpotCo.Text,
                PostOfficeCo = tb_CommunityCo.Text,
                PostalCodeCo = tb_PostalCodeCo.Text,
                StreetCo = tb_StreetCo.Text,
                BuildingNoCo = tb_StreetNoCo.Text,
                LocalNoCo = tb_PremisesCo.Text               
            };

            var result = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(
                WebAPIVariables.editDataPortal, PageMethodsHelper.ObjectToUrlParam(editDataPortalResultDto)).FirstOrDefault();

            if (result.Success)
            {
                pnl_SuccessMessage.Visible = true;
                pnl_SuccessMessage.Style.Clear();
                pnl_SuccessMessage.Style.Add("display","inline");
            }
        }

        #endregion
        #region Private methods

        private void CheckPermissions()
        {
        }

        private void VisiblePanel()
        {
            pnl_PersonalInformation.Visible = false;
            pnl_MedicalExamination.Visible = false;
            pnl_Additions.Visible = false;
        }

        #endregion
    }
}