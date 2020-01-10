using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Basic.Presentation.BasicModel;


namespace Workflow.Basic.Presentation.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            bool result = false;

            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                string encTicket = authCookie.Value;
                if (!String.IsNullOrEmpty(encTicket))
                {
                    var ticket = FormsAuthentication.Decrypt(encTicket);
                    var id = new UserIdentity(ticket);
                    var userRoles = System.Web.Security.Roles.GetRolesForUser(id.Name);
                    if (!userRoles.Contains(RoleName.ApiUser))
                        return false;
                    var prin = new GenericPrincipal(id, userRoles);
                    HttpContext.Current.User = prin;
                    result = true;
                }
            }
            return result;
        }
    }
}