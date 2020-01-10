using Workflow.Basic.Presentation.BasicModels;
using Workflow.Basic.Presentation.Infrastructure;
using Workflow.Web.Forms.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Workflow.Base.Infrastructure.Config;
using System.IO;
using Workflow.Base.Infrastructure.Loggers;

namespace Workflow.Web.Forms.App
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            SettingsConfig.ConfigureSettings();
            ContainerInit.RegisterDI();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            Logger.Instance.LogInfo("Application_Start_Forms");
        }

        protected void Application_End()
        {
            Logger.Instance.LogInfo("Application_End_Forms");

            if (ContainerInit._container != null)
            {
                ContainerInit._container.Dispose();
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //var user = new SessionUser(18, "Jan", "Kowalski", "jan.kowalski@workflow.pl", false, false, true, false);
            //Session[SessionVariables.user] = user;
        }
    }
}