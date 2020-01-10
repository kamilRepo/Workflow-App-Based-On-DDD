using System.Web;
using System.Web.Mvc;
using Workflow.Basic.Presentation.Infrastructure;

namespace Workflow.Web.Mvc.App
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AjaxMessagesFilter());
        }
    }
}