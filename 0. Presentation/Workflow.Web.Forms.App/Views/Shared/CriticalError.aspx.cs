using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.Web.Forms.App.Views.Shared
{
    public partial class CriticalError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            long errorNumber = 0;
            string message = string.Empty;

            if (Request.QueryString["errorNumber"] != null)
                errorNumber = Convert.ToInt64(Request.QueryString["errorNumber"]);
            else
                errorNumber = (long)ErrorNumbers.UnhandledException;

            if (Request.QueryString["message"] != null)
                message = Request.QueryString["message"];
            else
                message = "Error";

            lbl_Message.Text = 
                errorNumber + " - " + 
                HttpContext.GetGlobalResourceObject(
                    "Errors", message, new System.Globalization.CultureInfo(Request.UserLanguages[0])
                ).ToString();
        }
    }
}