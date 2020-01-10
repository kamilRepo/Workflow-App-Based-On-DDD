using System.Web.Mvc;
using System.Web.Http;

namespace Workflow.Web.Api.Areas.CardIndex
{
    public class CardIndexAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CardIndex";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapHttpRoute(
                "CardIndex_default2",
                "api/CardIndex/{controller}/{id}",
                new { id = UrlParameter.Optional }
            );

            context.MapRoute(
                "CardIndex_default",
                "CardIndex/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}