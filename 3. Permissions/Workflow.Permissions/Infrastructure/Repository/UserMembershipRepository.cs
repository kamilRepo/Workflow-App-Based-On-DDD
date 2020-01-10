using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.DDD.Domain.Annotations;
using Workflow.Base.DDD.Domain.Entities;
using Workflow.Base.Infrastructure.NHibernate.Repositories;
using Workflow.Permissions.Domain.Abstract;

namespace Workflow.Permissions.Infrastructure.Repository
{
    [DomainRepositoryImplementation]
    public class UserMembershipRepository : GenericRepositoryForBaseEntity<B_UserMembership>, IUserMembershipRepository
    {
        public IList<B_UserMembership> GetUserMembershipForUser(B_User user)
        {
            return EntityManager.CurrentSession.QueryOver<B_UserMembership>()
                .Where(x => x.User == user).List();
        }
    }
}
