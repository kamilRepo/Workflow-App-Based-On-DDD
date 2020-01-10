using System;
using System.Web;
using System.Web.Mvc;
using Workflow.Base.Infrastructure.Utilities;
using Workflow.Basic.Presentation.Dictionaries;
using Workflow.Basic.Presentation.Helper;
using Workflow.Basic.Presentation.Resources.Errors;

namespace Workflow.Basic.Presentation.Infrastructure
{
	/// <summary>
	/// If we're dealing with ajax requests, any message that is in the view data goes to
	/// the http header.
	/// </summary>
	public class AjaxMessagesFilter : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			if (filterContext.HttpContext.Request.IsAjaxRequest())
			{
				var viewData = filterContext.Controller.ViewData;
				var response = filterContext.HttpContext.Response;

				foreach (var messageType in Enum.GetNames(typeof(NotificationMessageType)))
				{
                    var mt = messageType + "Resources";

					var message = viewData.ContainsKey(messageType)
									? viewData[messageType]
									: null;

                    var messageResources = viewData.ContainsKey(mt)
                                    ? viewData[mt]
                                    : null;

					if (message != null) // We store only one message in the http header. First message that comes wins.
					{
                        if ((messageResources as string).IsNullOrEmpty() == false)
                            message = Errors.ResourceManager.GetString((string)messageResources);

						NotificationMvcHelper.AjaxMessage(response, messageType, message.ToString());
                        viewData[mt] = null;

						return;
					}
				}
			}
		}
	}
}