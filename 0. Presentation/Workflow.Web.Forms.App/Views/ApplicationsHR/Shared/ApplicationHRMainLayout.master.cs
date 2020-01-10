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
    public partial class ApplicationHRMainLayout : System.Web.UI.MasterPage
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

        protected void lnk_PersonalInformation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ApplicationsHR/MyPortal?id=" + GetIdFromUrl());
        }

        protected void lnk_StructureAndLocation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ApplicationsHR/StructureAndLocation?id=" + GetIdFromUrl());
        }

        protected void lnk_Accesses_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ApplicationsHR/MyPortal?id=" + GetIdFromUrl());
        }

        protected void lnk_Employees_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ApplicationsHR/MyEmployee?id=" + GetIdFromUrl());
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