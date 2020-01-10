using Workflow.Base.Interface.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Basic.Presentation.Attributes;

namespace Workflow.Web.Forms.App.Views.ApplicationsHR.Shared
{
    public partial class DeductionsFromSalaryMainLayout : System.Web.UI.MasterPage
    {
        #region Query



        #endregion
        #region Command



        #endregion
        #region Dto



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
            //CheckPermissions();



            return new ApplicationActionResult() { Success = true };
        }

        private void InitData()
        {

        }

        #endregion

        #region Page methods

        protected void lnk_Hestia_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ApplicationsHR/DeductionsFromSalary");
        }

        protected void lnk_MedicalCare_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ApplicationsHR/DeductionsMedicalCare");
        }

        protected void lnk_PZUInsurance_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ApplicationsHR/DeductionsPZUInsurance");
        }

        protected void lnk_ZFSS_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ApplicationsHR/DeductionsZFSS");
        }

        protected void lnk_LoansOther_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ApplicationsHR/DeductionsLoansOther");
        }

        protected void lnk_Multisport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ApplicationsHR/DeductionsMultisport");
        }

        protected void lnk_CompanyCar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ApplicationsHR/DeductionsCompanyCar");
        }

        #endregion
        #region Private methods

        private int GetIdFromUrl()
        {
            int id = 0;
            if (Request.QueryString["id"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
            }

            return id;
        }

        private void VisiblePanel()
        {

        }

        #endregion       
    }
}