using Workflow.Base.DDD.Infrastructure.Events;

namespace Workflow.Base.DDD.Infrastructure.Sagas
{
    public interface ISagaEngine : IEventListener<object>
    {
        
    }
}
