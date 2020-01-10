using Workflow.Base.Infrastructure.Utilities;
using Workflow.Basic.Presentation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Workflow.Basic.Presentation.Infrastructure
{
    public static class LogFormatter
    {
        public static string FormatErrorMessage(Controller controller, string message = null, string accountId = null)
        {
            string result;

            try
            {
                var errorMessage = new StringBuilder();
                errorMessage.AppendLine(string.Format("Date: {0}; ", DateTime.Now.ToDateTimeStringSafe()));
                errorMessage.AppendLine(string.Format("Action: {0}; ", controller.RouteData.Action()));
                errorMessage.AppendLine(string.Format("Controller: {0}; ", controller.RouteData.Controller()));
                errorMessage.AppendLine(string.Format("Area: {0}; ", controller.RouteData.Area()));
                errorMessage.AppendLine(string.Format("HttpMethod: {0}; ", controller.Request.HttpMethod));
                errorMessage.AppendLine(string.Format("Url: {0}; ", controller.Request.Url));

                if (!accountId.IsNullOrEmpty())
                {
                    errorMessage.AppendLine(string.Format("UserId: {0}; ", accountId));
                }
                var routeData = controller.RouteData.RouteValues();
                if (routeData.Any())
                {
                    errorMessage.AppendLine(string.Format("Route data:"));
                    foreach (var value in routeData)
                    {
                        errorMessage.AppendLine(string.Format("{0}: {1}", value.Key, value.Value));
                    }
                    errorMessage.AppendLine("; ");
                }
                var model = controller.ViewData.Model();
                if (model.Keys.Any())
                {
                    errorMessage.AppendLine(string.Format("Model data:"));
                    foreach (var key in model.Keys)
                    {
                        var value = model[key] is IEnumerable<string>
                            ? string.Join(", ", model[key] as IEnumerable<string>)
                            : model[key];
                        errorMessage.AppendLine(string.Format("{0}: {1}", key, value));
                    }
                    errorMessage.AppendLine("; ");
                }

                if (!string.IsNullOrEmpty(message))
                {
                    errorMessage.AppendLine(string.Format("Message: {0}; ", message));
                }

                result = errorMessage.ToString();
            }catch
            {
                result = "Format message error";
            }

            return result;
        }
    }
}
