using Workflow.Base.DDD.Domain;
using Workflow.Base.DDD.Domain.Entities;
using Workflow.Base.Infrastructure.Attributes;

namespace Workflow.Base.DDD.Domain.Support
{
    [Component]
    public class InjectorHelper
    {
        public IDomainEventPublisher EventPublisher { get; set; }

        public void InjectDependencies(AggregateRoot aggregateRoot)
        {
            if (aggregateRoot != null)
            {
                aggregateRoot.EventPublisher = EventPublisher;
            }
        }
    }
}