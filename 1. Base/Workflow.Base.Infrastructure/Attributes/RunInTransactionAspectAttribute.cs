using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Workflow.Base.Infrastructure.Attributes
{
    [Serializable]
    public class RunInTransactionAspectAttribute : OnMethodBoundaryAspect
    {
        [NonSerialized]
        TransactionScope _transactionScope;
        IsolationLevel _isolationLevel;

        public RunInTransactionAspectAttribute(IsolationLevel isolationLevel)
        {
            _isolationLevel = isolationLevel;
            AspectPriority = 20;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            _transactionScope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = _isolationLevel });
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _transactionScope.Complete();
        }

        public override void OnException(MethodExecutionArgs args)
        {
            args.FlowBehavior = FlowBehavior.Continue;
            Transaction.Current.Rollback();
            throw args.Exception;
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            _transactionScope.Dispose();
        }
    }
}
