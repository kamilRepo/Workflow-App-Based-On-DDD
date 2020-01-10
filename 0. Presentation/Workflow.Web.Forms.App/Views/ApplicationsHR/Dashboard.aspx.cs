using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Basic.Presentation.BasicModels;
using Workflow.Basic.Presentation.Infrastructure;

namespace Workflow.Web.Forms.App.Views.Applications_HR
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (SessionUser)Session[SessionVariables.user];
            if (user.Id != 1)
                Response.Redirect("~/Views/Shared/LackPermissions.aspx");
        }
    }
}