using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.DDD.Domain.Annotations;
using Workflow.Base.Infrastructure.NHibernate.Repositories;
using Workflow.Basic.Domain.Domain.Entities;
using Workflow.HR.Domain.Abstract;

namespace Workflow.HR.Infrastructure.Repository
{
    [DomainRepositoryImplementation]
    public class EmployeeMembershipCoefficientsRepository : GenericRepositoryForBaseEntity<B_EmployeeMembershipCoefficients>, IEmployeeMembershipCoefficientsRepository
    {
    }
}
