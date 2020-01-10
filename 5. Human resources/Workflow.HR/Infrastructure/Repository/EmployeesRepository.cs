using Workflow.Base.DDD.Domain.Annotations;
using Workflow.Basic.Domain.Domain.Entities;
using Workflow.HR.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.Infrastructure.NHibernate.Repositories;

namespace Workflow.HR.Infrastructure.Repository
{
    [DomainRepositoryImplementation]
    public class EmployeesRepository : GenericRepositoryForBaseEntity<B_Employee>, IEmployeesRepository
    {
    }
}
