using System.Web.Mvc;
using Workflow.Basic.Presentation.Dictionaries;

namespace Workflow.Basic.Presentation.Extensions
{
	public static class ControllerExtensions
	{
        public static void ShowMessage(this Controller controller, NotificationMessageType messageType,
            string message, bool showAfterRedirect = false)
		{
			var messageTypeKey = messageType.ToString();
			if (showAfterRedirect)
			{
				controller.TempData[messageTypeKey] = message;
			}
			else
			{
				controller.ViewData[messageTypeKey] = message;
			}
		}

        public static void ShowMessage(this Controller controller, NotificationMessageType messageType,
            string message, string messageResources, bool showAfterRedirect = false)
        {
            var messageTypeKey = messageType.ToString();
            if (showAfterRedirect)
            {
                controller.TempData[messageTypeKey] = message;
                controller.TempData[messageTypeKey + "Resources"] = messageResources;
            }
            else
            {
                controller.ViewData[messageTypeKey] = message;
                controller.ViewData[messageTypeKey + "Resources"] = messageResources;
            }
        }
	}
}