using System;
using System.Web;
using System.Web.Mvc;
using Workflow.Base.Infrastructure.Utilities;
using Workflow.Basic.Presentation.Dictionaries;
using Workflow.Basic.Presentation.Helper;
using Workflow.Basic.Presentation.Infrastructure;
using Workflow.Basic.Presentation.Resources.Errors;

namespace Workflow.Basic.Presentation.Extensions
{
	public static class HtmlHelperExtensions
	{
		/// <summary>
		/// Render all messages that have been set during execution of the controller action.
		/// </summary>
		/// <param name="htmlHelper"></param>
		/// <returns></returns>
		public static HtmlString RenderMessages(this HtmlHelper htmlHelper)
		{
			var messages = String.Empty;
			foreach (var messageType in Enum.GetNames(typeof(NotificationMessageType)))
			{
                var mt = messageType + "Resources";
				var message = htmlHelper.ViewContext.ViewData.ContainsKey(messageType)
								? htmlHelper.ViewContext.ViewData[messageType]
								: htmlHelper.ViewContext.TempData.ContainsKey(messageType)
									? htmlHelper.ViewContext.TempData[messageType]
									: null;

                var messageResources = htmlHelper.ViewContext.ViewData.ContainsKey(mt)
                                ? htmlHelper.ViewContext.ViewData[mt]
                                : htmlHelper.ViewContext.TempData.ContainsKey(mt)
                                    ? htmlHelper.ViewContext.TempData[mt]
                                    : null;

                if (NotificationMessageType.Error.ToString().Equals(messageType) &&
                    (HttpContext.Current.Session[SessionVariables.messageTypeKey] as string).IsNullOrEmpty() == false)
                {
                    message = HttpContext.Current.Session[SessionVariables.messageTypeKey].ToString();
                    HttpContext.Current.Session[SessionVariables.messageTypeKey] = null;
                }

				if (message != null)
				{
                    if ((messageResources as string).IsNullOrEmpty() == false)
                        message = Errors.ResourceManager.GetString((string)messageResources);

					var messageBoxBuilder = new TagBuilder("div");
					messageBoxBuilder.AddCssClass(String.Format("messagebox {0}", messageType.ToLowerInvariant()));
					messageBoxBuilder.SetInnerText(message.ToString());
					messages += messageBoxBuilder.ToString();
                    htmlHelper.ViewContext.ViewData[mt] = null;
                    htmlHelper.ViewContext.TempData[mt] = null;
				}
			}
			return MvcHtmlString.Create(messages);
		}
	}
}