using Workflow.Base.CQRS.Query.Attributes;
using Workflow.Base.Infrastructure.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using NHibernate.Transform;
using Workflow.Basic.Domain.Domain.Entities;
using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.Infrastructure.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Permissions.Interface.Presentation.Abstract;
using Workflow.Permissions.Interface.Presentation.FindersDto;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Permissions.Infrastructure.Finders
{
    [Finder]
    public class RolesFinder : IRolesFinder
    {
        public IEntityManager EntityManager { get; set; }

        #region Finders

        [ApplicationLayerException(ErrorNumbers.RolesFinderFindRoles, "ErrorDataDownload")]
        public List<RoleDto> FindRoles()
        {
            var s = EntityManager.CurrentSession;

            return (
                from
                    e in s.Query<B_Role>()
                select
                    new RoleDto(e.Id, e.RoleName)
           ).ToList();
        }

        [ApplicationLayerException(ErrorNumbers.RolesFinderFindUserRoles, "ErrorDataDownload")]
        public IList<RoleDto> FindUserRoles(string userName)
        {
            var s = EntityManager.CurrentSession;

            string hql = @"
                SELECT 
                    r.Id as Id,
                    r.RoleName as RoleName
                FROM B_UserInRoles uir
                    JOIN uir.Role r
                WHERE
                    uir.User.Login = :userName AND
                    uir.Status = :status
            ";

            var list = s.CreateQuery(hql)
                .SetString("userName", userName)
                .SetInt32("status", (int)EntityStatus.Active)
                .SetResultTransformer(Transformers.AliasToBean<RoleDto>())
                .List<RoleDto>();

            return list;
        }

        #endregion
        #region Criteria



        #endregion
    }
}
