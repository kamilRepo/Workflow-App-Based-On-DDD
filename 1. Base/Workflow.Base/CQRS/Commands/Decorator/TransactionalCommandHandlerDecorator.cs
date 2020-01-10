using System.Transactions;
using Workflow.Base.CQRS.Commands.Handler;

namespace Workflow.Base.CQRS.Commands.Decorator
{
    public class TransactionalCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> _inner;

        public TransactionalCommandHandlerDecorator(ICommandHandler<TCommand> inner)
        {
            _inner = inner;
        }

        public void Handle(TCommand command)
        {
            using (var t = new TransactionScope(TransactionScopeOption.Required, 
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                _inner.Handle(command);
                t.Complete();
            }
        }
    }
}