using Workflow.Base.DDD.Domain.Annotations;
using Workflow.Base.Infrastructure.NHibernate.Repositories;
using Workflow.Basic.Domain.Domain.Entities;
using Workflow.Dashboard.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Infrastructure.Repository
{
    [DomainRepositoryImplementation]
    public class EmployeeRepository : GenericRepositoryForBaseEntity<B_Employee>, IEmployeeRepository
    {
    }
}
