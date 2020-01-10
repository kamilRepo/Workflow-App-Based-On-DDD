using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.Basic.Presentation.Exceptions
{
    public class WebException : Exception
    {
        public WebException(String message, string messageContent, ErrorNumbers errorNumber,
            int? userId, RedirectToRouteResult redirectToRouteResult)
            : base(message)
        {
            ErrorNumber = errorNumber;
            MessageContent = messageContent;
            UserId = userId;
            RedirectToRouteResult = redirectToRouteResult;
        }

        public WebException(String message, string messageContent, ErrorNumbers errorNumber, int? userId)
            : base(message)
        {
            ErrorNumber = errorNumber;
            MessageContent = messageContent;
            UserId = userId;
        }

        public WebException(String messageContent, ErrorNumbers errorNumber,
            int? userId, RedirectToRouteResult redirectToRouteResult)
            : base(messageContent)
        {
            ErrorNumber = errorNumber;
            MessageContent = messageContent;
            UserId = userId;
            RedirectToRouteResult = redirectToRouteResult;
        }

        public WebException(String messageContent, ErrorNumbers errorNumber, int? userId)
            : base(messageContent)
        {
            ErrorNumber = errorNumber;
            MessageContent = messageContent;
            UserId = userId;
        }

        public ErrorNumbers ErrorNumber { get; private set; }
        public string MessageContent { get; private set; }
        public int? UserId { get; private set; }
        public RedirectToRouteResult RedirectToRouteResult { get; set; }
    }
}