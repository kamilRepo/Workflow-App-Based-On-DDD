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
    public class UserRepository : GenericRepositoryForBaseEntity<B_User>, IUserRepository
    {
        public B_User GetUserByLogin(string login)
        {
            return EntityManager.CurrentSession.QueryOver<B_User>().Where(x => x.Login == login).SingleOrDefault();
        }
    }
}
