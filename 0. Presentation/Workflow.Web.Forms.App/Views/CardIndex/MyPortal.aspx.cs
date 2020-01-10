using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Basic.Presentation.Attributes;
using Workflow.Dashboard.Interface.Application.Abstract;
using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.Dashboard.Interface.Presentation.Dto;
using Workflow.Dashboard.Interface.Presentation.ServicesDto;
using Workflow.HR.Interface.Presentation.FindersDto;
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

namespace Workflow.Web.Forms.App.Views.CardIndex
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
        private VacationsDto _vacationsDto;
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
            InitData(PageNumbers.CardIndexMyPortal, (SessionUser)Session[SessionVariables.user]);

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
                _employeeID = SessionUser.Id;

            CheckPermissions();

            _employeeDto = PageMethodsHelper.InvokeWebAPI<EmployeeDto>(WebAPIVariables.employee, "?id=" + _employeeID).FirstOrDefault();
            _employeeMembershipDto = PageMethodsHelper.InvokeWebAPI<EmployeeMembershipDto>(WebAPIVariables.employeeMembership, "?id=" + _employeeID).FirstOrDefault();

            _vacationsDto = PageMethodsHelper.InvokeWebAPI<VacationsDto>(WebAPIVariables.vacation, "?id=" + _employeeID).FirstOrDefault();
            _listEmployeeAddressDto = PageMethodsHelper.InvokeWebAPI<EmployeeAddressDto>(WebAPIVariables.employeeAddress, "?id=" + _employeeID);

            if (_employeeDto == null || _employeeMembershipDto == null ||
                _vacationsDto == null || _listEmployeeAddressDto == null)
                throw new ApplicationLayerException("NoData", ErrorNumbers.MyPortalGetData, SessionUser.Id);

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
            lbl_PhoneNumber.Text = _employeeDto.PhoneNumber;
            lbl_MobileNumber.Text = _employeeDto.MobilePhoneNumber;
            lbl_Email.Text = _employeeDto.Email;

            //pnl_PersonalInformation
            var address = _listEmployeeAddressDto.Where(x => x.IsCorrespondence == false).FirstOrDefault();
            lbl_Spot.Text = address.City;
            lbl_Community.Text = address.PostOffice;
            lbl_PostalCode.Text = address.PostalCode;
            lbl_Street.Text = address.Street;
            lbl_StreetNo.Text = address.BuildingNo;
            lbl_Premises.Text = address.LocalNo;

            address = _listEmployeeAddressDto.Where(x => x.IsCorrespondence == true).FirstOrDefault();
            if(address == null)
                address = _listEmployeeAddressDto.Where(x => x.IsCorrespondence == false).FirstOrDefault();

            lbl_SpotCo.Text = address.City;
            lbl_CommunityCo.Text = address.PostOffice;
            lbl_PostalCodeCo.Text = address.PostalCode;
            lbl_StreetCo.Text = address.Street;
            lbl_StreetNoCo.Text = address.BuildingNo;
            lbl_PremisesCo.Text = address.LocalNo;

            lbl_Pesel.Text = _employeeDto.Pesel;
            lbl_Education.Text = _employeeDto.Education;

            //pnl_HolidaysDue
            lbl_ReportForDay.Text = DateTime.Now.ToShortDateString();
            lbl_HolidaysDue.Text = _vacationsDto.HolidaysDue.ToString();
            lbl_HolidaysCalculated.Text = _vacationsDto.HolidaysCalculated.ToString();
            lbl_HolidaysUnderpaid.Text = _vacationsDto.HolidaysUnderpaid.ToString();
            lbl_HolidaysRehabilitation.Text = _vacationsDto.HolidaysRehabilitation.ToString();
            lbl_HolidaysUsed.Text = _vacationsDto.HolidaysUsed.ToString();
            lbl_Art188KP.Text = _vacationsDto.Art188KP.ToString();
            lbl_RemainedUnused.Text = _vacationsDto.RemainedUnused.ToString();

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
        }

        protected void lnk_HolidaysDue_Click(object sender, EventArgs e)
        {
            VisiblePanel();
            pnl_HolidaysDue.Visible = true;
        }

        protected void lnk_MedicalExamination_Click(object sender, EventArgs e)
        {
            VisiblePanel();
            pnl_MedicalExamination.Visible = true;
        }

        protected void lnk_Additions_Click(object sender, EventArgs e)
        {
            VisiblePanel();
            pnl_Additions.Visible = true;
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

        private void VisiblePanel()
        {
            pnl_HolidaysDue.Visible = false;
            pnl_PersonalInformation.Visible = false;
            pnl_MedicalExamination.Visible = false;
            pnl_Additions.Visible = false;
        }

        #endregion
    }
}