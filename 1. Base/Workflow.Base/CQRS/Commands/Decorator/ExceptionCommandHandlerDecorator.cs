using System;
using System.Transactions;
using Workflow.Base.CQRS.Commands.Handler;
using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.Infrastructure.Loggers;
using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.Base.CQRS.Commands.Decorator
{
    public class ExceptionCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> _inner;

        public ExceptionCommandHandlerDecorator(ICommandHandler<TCommand> inner)
        {
            _inner = inner;
        }

        public void Handle(TCommand command)
        {
            try
            {
                _inner.Handle(command);
            }
            catch (UserException ex)
            {
                DBLogger.OwnUser(ex);
            }
            catch (ApplicationLayerException ex)
            {
                DBLogger.OwnApp(ex);
            }
            catch (Exception ex)
            {
                var appActionResult = command as ApplicationActionResult;
                int? userId = null;

                DBLogger.UnhandledException(ex, (ErrorNumbers)appActionResult.ErrorNumber,
                    appActionResult.ErrorMessage, appActionResult.UserId == 0 ? userId : appActionResult.UserId); 
            }
        }
    }
}
