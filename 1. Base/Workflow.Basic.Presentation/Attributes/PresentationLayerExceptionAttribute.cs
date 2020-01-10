using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.Interface.Application.BaseDto;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using Conf = System.Configuration;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Base.Infrastructure.Config;

namespace Workflow.Basic.Presentation.Attributes
{
    [Serializable]
    public class PresentationLayerExceptionAttribute : OnExceptionAspect
    {
        Type type;

        private ErrorNumbers _errorNumber;
        private string _message;

        public PresentationLayerExceptionAttribute()
            : this(typeof(Exception))
        {
        }

        public PresentationLayerExceptionAttribute(Type type)
            : base()
        {
            this.type = type;
        }

        public override Type GetExceptionType(MethodBase method)
        {
            return this.type;
        }

        public override void OnException(MethodExecutionArgs args)
        {
            var v = args.Exception.Message;
            if (v.Equals("Trwało przerywanie wątku."))
                throw args.Exception;

            if (!SettingsProvider.BaseSettings.IsProduction)
                throw args.Exception;

            if (args.Exception is ApplicationLayerException)
                OwnApp(args);
            if (args.Exception is UserException)
            {
                OwnUser(args);
                return;
            }

            UnhandledException(args);                        
        }

        private void OwnApp(MethodExecutionArgs args)
        {
            var ex = (ApplicationLayerException)args.Exception;
            _message = ex.Message;
            _errorNumber = (ErrorNumbers)ex.ErrorNumber;

            args.FlowBehavior = FlowBehavior.Continue;
            HttpContext.Current.Response.Redirect(
                "~/Views/Shared/CriticalError?errorNumber=" + (long)_errorNumber + "&message=" + _message);
        }

        private void OwnUser(MethodExecutionArgs args)
        {
            var ex = (UserException)args.Exception;
            _message = ex.Message;
            _errorNumber = ex.ErrorNumber;

            var appActionResult = new ApplicationActionResult()
            {
                Success = false,
                ErrorNumber = _errorNumber,
                ErrorMessage = _message
            };

            args.FlowBehavior = FlowBehavior.Return;
            args.ReturnValue = appActionResult;
        }

        private void UnhandledException(MethodExecutionArgs args)
        {
            args.FlowBehavior = FlowBehavior.Continue;
            HttpContext.Current.Response.Redirect(
                "~/Views/Shared/CriticalError?errorNumber=" + (long)ErrorNumbers.UnhandledException + "&message=" + "Error");
        }
    }
}
