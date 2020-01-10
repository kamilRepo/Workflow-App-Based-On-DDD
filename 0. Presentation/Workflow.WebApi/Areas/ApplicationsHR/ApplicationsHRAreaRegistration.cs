using System.Web.Mvc;
using System.Web.Http;

namespace Workflow.Web.Api.Areas.ApplicationsHR
{
    public class ApplicationsHRAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ApplicationsHR";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapHttpRoute(
                "ApplicationsHR_default2",
                "api/ApplicationsHR/{controller}/{id}",
                new { id = UrlParameter.Optional }
            );

            context.MapRoute(
                "ApplicationsHR_default",
                "ApplicationsHR/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}