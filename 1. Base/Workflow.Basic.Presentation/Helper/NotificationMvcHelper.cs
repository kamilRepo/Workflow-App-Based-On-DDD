using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Basic.Presentation.Dictionaries;
using Workflow.Basic.Presentation.Resources.Common;
using Workflow.Basic.Presentation.Resources.Errors;

namespace Workflow.Basic.Presentation.Helper
{
    public static class NotificationMvcHelper
    {
        public static void AjaxMessage(HttpResponseBase response, string messageType, string message)
        {
            response.AddHeader("X-Message-Type", messageType);
            response.AddHeader("X-Message", message);
            HttpCookie myCookie = new HttpCookie("NotiMessage");
            myCookie["ErrorNotiMessage"] = message.ToString();
            myCookie.Expires = DateTime.Now.AddMinutes(1);
            response.Cookies.Add(myCookie);
        }

        public static string FormatMessage(ErrorNumbers errorNumber, string messageContent)
        {
            string result;
            try
            {
                result = string.Format(
                        "{0}: {1} - {2}",
                        Common.Error,
                        (long)errorNumber,
                        Errors.ResourceManager.GetString(messageContent)
                    );
            }
            catch
            {
                result = "Format message error";
            }

            return result;
        }
    }
}
