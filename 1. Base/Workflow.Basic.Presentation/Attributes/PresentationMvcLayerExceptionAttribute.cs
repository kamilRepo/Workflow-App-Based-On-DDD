using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.Infrastructure.Config;
using Workflow.Base.Infrastructure.Loggers;
using Workflow.Base.Infrastructure.Utilities;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Basic.Presentation.Exceptions;
using Workflow.Basic.Presentation.Infrastructure;
using Workflow.Basic.Presentation.Resources.Common;
using Workflow.Basic.Presentation.Resources.Errors;
using Workflow.Basic.Presentation.Extensions;
using System.Web;
using Workflow.Basic.Presentation.Dictionaries;
using Workflow.Basic.Presentation.Helper;
using Workflow.Basic.Presentation.BasicModel;

namespace Workflow.Basic.Presentation.Attributes
{
    public class PresentationMvcLayerExceptionAttribute : HandleErrorAttribute
    {
        #region Field and properties

        private Logger _logger;
        private string _message;
        private Controller _controller;
        private RouteValueDictionary _routeValueDictionary = new RouteValueDictionary();
        private ExceptionContext _filterContext;
        private bool _isRedirect;

        public string IdParamName { get; set; }
        private string ActionName { get; set; }
        private string ControllerName { get; set; }
        private string AreaName { get; set; }

        #endregion
        #region Constructor

        public PresentationMvcLayerExceptionAttribute(string actionName, string controllerName, string areaName)
            : this(actionName, controllerName)
        {
            _routeValueDictionary.Add("area", areaName);
            AreaName = areaName;
        }

        public PresentationMvcLayerExceptionAttribute(string actionName, string controllerName)
            : this(actionName)
        {
            _routeValueDictionary.Add("controller", controllerName);
            ControllerName = controllerName;
        }

        public PresentationMvcLayerExceptionAttribute(string actionName)
            : this()
        {
            _routeValueDictionary.Add("action", actionName);
            ActionName = actionName;
        }

        public PresentationMvcLayerExceptionAttribute()
        {
            _logger = Logger.Instance;
            _message = "Error";
        }

        #endregion
        #region OnException

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                base.OnException(filterContext);
                return;
            }

            OnExceptionBase(filterContext);

            if (filterContext.Exception is UserException)
                UserException(filterContext.Exception as UserException);
            else if (filterContext.Exception is ApplicationLayerException)
                ApplicationLayerException(filterContext.Exception as ApplicationLayerException);
            else if (filterContext.Exception is WebException)
                WebException(filterContext.Exception as WebException);
            else if (filterContext.Exception is Exception)
                UnhandledException();
            else
                base.OnException(filterContext);
        }

        #endregion
        #region Private method

        private void OnExceptionBase(ExceptionContext filterContext)
        {
            _filterContext = filterContext;
            _controller = filterContext.Controller as Controller;

            if (_controller != null)
                _message = LogFormatter.FormatErrorMessage(_controller, filterContext.Exception.Message);

            _logger.LogError(_message, filterContext.Exception);
        }

        private void IsAjaxRequest(string message, bool isRedirect)
        {
            _isRedirect = isRedirect;

            _filterContext.Result = new JsonResult
            {
                Data = new { success = false, error = message },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            NotificationMvcHelper.AjaxMessage(_filterContext.RequestContext.HttpContext.Response, 
                NotificationMessageType.Error.ToString(), message);
        }

        private void GlobalError(string message)
        {
            _isRedirect = false;

            var model = new ErrorModel()
            {
                Message = message,
                IsProduction = SettingsProvider.BaseSettings.IsProduction,
                ExceptionMessage = LogFormatter.FormatErrorMessage(_controller, _filterContext.Exception.Message)
            };

            _filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Error/Error.cshtml",
                ViewData = new ViewDataDictionary<ErrorModel>(model)
            };
        }

        private void UserException(UserException userException)
        {
            _isRedirect = true;
            var message = NotificationMvcHelper.FormatMessage(userException.ErrorNumber, userException.MessageContent);

            if (_filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                IsAjaxRequest(message, false);
            else if (!ActionName.IsNullOrEmpty())
                _filterContext.Result = new RedirectToRouteResult(_routeValueDictionary);
            else
                GlobalError(message);

            _controller.ShowMessage(NotificationMessageType.Error, message, _isRedirect);

            _filterContext.ExceptionHandled = true;
        }

        private void ApplicationLayerException(ApplicationLayerException applicationLayerException)
        {
            var message = NotificationMvcHelper.FormatMessage(
                applicationLayerException.ErrorNumber, applicationLayerException.MessageContent);

            if (_filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                IsAjaxRequest(message, false);
            else
                GlobalError(message);

            _controller.ShowMessage(NotificationMessageType.Error, message, _isRedirect);

            _filterContext.ExceptionHandled = true;
        }

        private void WebException(WebException webException)
        {
            _isRedirect = true;
            var message = NotificationMvcHelper.FormatMessage(webException.ErrorNumber, webException.MessageContent);

            if (_filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                IsAjaxRequest(message, false);
            else if (webException.RedirectToRouteResult != null)
                _filterContext.Result = webException.RedirectToRouteResult;
            else if (!ActionName.IsNullOrEmpty())
                _filterContext.Result = new RedirectToRouteResult(_routeValueDictionary);
            else
                GlobalError(message);

            _controller.ShowMessage(NotificationMessageType.Error, message, _isRedirect);

            _filterContext.ExceptionHandled = true;
        }

        private void UnhandledException()
        {
            var message = NotificationMvcHelper.FormatMessage(
                ErrorNumbers.ErrorView, "ErrorView");

            if (_filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                IsAjaxRequest(message, false);
            else
                GlobalError(message);

            _controller.ShowMessage(NotificationMessageType.Error, message, _isRedirect);

            _filterContext.ExceptionHandled = true;
        }        

        #endregion
    }
}