using Workflow.Base.CQRS.Commands.Handler;
using Workflow.Base.Infrastructure.Attributes;

namespace Workflow.Base.CQRS.Commands
{
    [Component]
    public class RunEnvironment
    {
        public ICommandHandlerFactory Factory { get; set; }

        public void Run<T>(T command)
        {
            // Transaction\Commit\Container CommadnHandler decorators are loaded by default
            ICommandHandler<T> handler = Factory.Create<T>();

            //You can add Your own capabilities here: dependency injection, security, transaction management, logging, profiling, spying, storing commands, etc

            handler.Handle(command);

            //You can add Your own capabilities here
        }
    }
}