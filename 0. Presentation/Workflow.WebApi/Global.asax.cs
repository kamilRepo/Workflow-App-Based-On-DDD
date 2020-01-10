using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Workflow.Base.Infrastructure.Config;
using Workflow.Base.Infrastructure.Loggers;
using Workflow.Basic.Presentation.BasicModel;

namespace Workflow.Web.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private WindsorContainer _windsorContainer;

        protected void Application_Start()
        {
            SettingsConfig.ConfigureSettings();
            AreaRegistration.RegisterAllAreas();
            InitializeWindsor();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));
            Logger.Instance.LogInfo("Application_Start_API");
        }

        protected void Application_End()
        {
            Logger.Instance.LogInfo("Application_End_API");

            if (_windsorContainer != null)
            {
                _windsorContainer.Dispose();
            }

            this.PostAuthenticateRequest -= MvcApplication_PostAuthenticateRequest;
        }

        public override void Init()
        {
            this.PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void InitializeWindsor()
        {
            _windsorContainer = ContainerInit._container;
            _windsorContainer.Install(FromAssembly.Containing<ControllersInstaller>());
            _windsorContainer.Install(FromAssembly.This());

            ContainerInit.RegisterDI();

            //ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_windsorContainer.Kernel));
        }

        void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                string encTicket = authCookie.Value;
                if (!String.IsNullOrEmpty(encTicket))
                {
                    var ticket = FormsAuthentication.Decrypt(encTicket);
                    var id = new UserIdentity(ticket);
                    var userRoles = Roles.GetRolesForUser(id.Name);
                    var prin = new GenericPrincipal(id, userRoles);
                    HttpContext.Current.User = prin;
                }
            }
        }
    }
}
