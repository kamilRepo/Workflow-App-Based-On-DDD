using Workflow.Base.DDD.Domain.Annotations;
using Workflow.Base.Infrastructure.NHibernate.Repositories;
using Workflow.Basic.Domain.Domain.Abstract;
using Workflow.Basic.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workflow.Basic.Domain.Infrastructure.Repository
{
    [DomainRepositoryImplementation]
    public class EventsRepository : GenericRepositoryForBaseEntity<B_Events>, IEventsRepository
    {
    }
}
