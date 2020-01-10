using System;
using Workflow.Base.DDD.Domain.Annotations;
using Workflow.Base.DDD.Domain;

namespace Workflow.Base.DDD.Domain.Entities
{
    [DomainAggregateRoot]
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot()
        {
            Version = new DateTime(1753, 1, 1); // datetime in Sql Server begins from this date
        }

        public DateTime Version { get; private set; }

        // Second options - timestamp in Sql Server - uncomment the next line and comment DateTime Version property
        //public byte[] Version { get; private set; }

        private IDomainEventPublisher _eventPublisher;
        protected internal virtual IDomainEventPublisher EventPublisher
        {
            get { return _eventPublisher; }
            set
            {
                if (_eventPublisher != null)
                    throw new InvalidOperationException("Publisher is already set. Probably You have logical error in code");
                _eventPublisher = value;
            }
        }
    }
}
