using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor.Installer;
using Workflow.Web.Mvc.App;
using Workflow.Base.Infrastructure.Config;
using System.IO;
using System.Web.Security;
using System.Security.Principal;
using Workflow.Basic.Presentation.BasicModel;
using Workflow.Base.Infrastructure.Loggers;
using Workflow.Basic.Presentation.Infrastructure;
using WebMatrix.WebData;

namespace Workflow.Web.Mvc.App
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private WindsorContainer _windsorContainer;

        protected void Application_Start()
        {
            SettingsConfig.ConfigureSettings();
            AreaRegistration.RegisterAllAreas();
            InitializeWindsor();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            Logger.Instance.LogInfo("Application_Start_MVC");
        }

        public override void Init()
        {
            this.PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        protected void Application_End()
        {
            Logger.Instance.LogInfo("Application_End_MVC");

            if (_windsorContainer != null)
            {
                _windsorContainer.Dispose();
            }

            this.PostAuthenticateRequest -= MvcApplication_PostAuthenticateRequest;
        }

        private void InitializeWindsor()
        {
            _windsorContainer = ContainerInit._container;
            _windsorContainer.Install(FromAssembly.Containing<ControllersInstaller>());
            _windsorContainer.Install(FromAssembly.This());

            ContainerInit.RegisterDI();

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_windsorContainer.Kernel));
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

                    //Response.Cookies[SessionVariables.tokenLive].Domain = SettingsProvider.WebSettings.WebFormUrl;
                    HttpContext.Current.Response.Cookies[SessionVariables.externalTokenLive].Value = authCookie.Value;
                    HttpContext.Current.Response.Cookies[SessionVariables.externalTokenLive].Expires = DateTime.Now.AddDays(1);
                    HttpContext.Current.Response.Cookies[SessionVariables.externalTokenLive].HttpOnly = true;
                    HttpContext.Current.Response.Cookies[SessionVariables.externalTokenLive].Shareable = true;

                    //TODO po wywaleniu web forms do wyrzucenia
                    string userId = string.Empty;
                    try
                    {
                        var value = HttpContext.Current.Request.Cookies[SessionVariables.sessionUserId].Value;
                        if (string.IsNullOrEmpty(value))
                            userId = WebSecurity.GetUserId(prin.Identity.Name).ToString();
                        else
                            userId = value;
                    }
                    finally
                    {
                        HttpContext.Current.Response.Cookies[SessionVariables.sessionUserId].Value = userId;
                        HttpContext.Current.Response.Cookies[SessionVariables.sessionUserId].Expires = DateTime.Now.AddDays(1);
                        HttpContext.Current.Response.Cookies[SessionVariables.sessionUserId].HttpOnly = true;
                        HttpContext.Current.Response.Cookies[SessionVariables.sessionUserId].Shareable = true;
                    }
                }
            }
            else
            {
                //TODO po wywaleniu web forms do wyrzucenia
                HttpContext.Current.Response.Cookies[SessionVariables.sessionUserId].Value = string.Empty;
                HttpContext.Current.Response.Cookies[SessionVariables.externalTokenLive].Value = string.Empty;
            }
        }
    }
}