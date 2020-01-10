using Workflow.Base.DDD.Domain.Exceptions;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Base.Infrastructure.Loggers;

namespace Workflow.Base.Infrastructure.Attributes
{
    [Serializable]
    public class ApplicationLayerExceptionAttribute : OnExceptionAspect
    {
        Type _type;

        private ErrorNumbers _errorNumber;
        private string _messageContent;

        public ApplicationLayerExceptionAttribute(ErrorNumbers errorNumber, string messageContent)
            : this(typeof(Exception), errorNumber, messageContent)
        {
        }

        public ApplicationLayerExceptionAttribute(Type type, ErrorNumbers errorNumber, string messageContent)
            : base()
        {
            AspectPriority = 10;
            this._type = type;
            _errorNumber = errorNumber;
            _messageContent = messageContent;
        }

        public override Type GetExceptionType(MethodBase method)
        {
            return this._type;
        }

        public override void OnException(MethodExecutionArgs args)
        {
            args.FlowBehavior = FlowBehavior.Continue;

            if (args.Exception is ApplicationLayerException)
                DBLogger.OwnApp(args.Exception as ApplicationLayerException);

            if (args.Exception is UserException)
                DBLogger.OwnUser(args.Exception as UserException);

            DBLogger.UnhandledException(args.Exception as Exception, _errorNumber, _messageContent, null);        
        }
    }
}
