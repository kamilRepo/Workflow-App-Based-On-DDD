using Workflow.Base.CQRS.Query.Attributes;
using Workflow.Base.Infrastructure.NHibernate;
using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.Dashboard.Interface.Presentation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using Workflow.Dashboard.Interface.Presentation.Criteria;
using NHibernate.Transform;
using Workflow.Basic.Domain.Domain.Entities;
using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Basic.Domain.Domain.Entities.Dictionaries;
using Workflow.Base.Infrastructure.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.Dashboard.Infrastructure.Finders
{
    [Finder]
    public class EmployeeMembershipFinder : IEmployeeMembershipFinder
    {
        public IEntityManager EntityManager { get; set; }

        #region Finders

        [ApplicationLayerException(ErrorNumbers.EmployeeMembershipFinderFindDirectSupervisorId, "ErrorDataDownload")]
        public int FindDirectSupervisorId(int id)
        {
            var s = EntityManager.CurrentSession;

            return (
                from
                    e in s.Query<B_EmployeeMembership>()
                where
                    e.Id == id
                select
                    e.DirectSupervisor.Id
           ).FirstOrDefault();
        }

        [ApplicationLayerException(ErrorNumbers.EmployeeMembershipFinderFindBranchOrganizationalCellId, "ErrorDataDownload")]
        public int FindBranchOrganizationalCellId(int branchId, int organizationalCellId)
        {
            var s = EntityManager.CurrentSession;

            string hql = @"
                SELECT 
                    bd.Id
                FROM 
                    B_BranchOrganizationalCell bd
                WHERE
                    bd.Branch = :branchId AND
                    bd.OrganizationalCell = :organizationalCellId AND
                    bd.Status = :status
            ";

            var list = s.CreateQuery(hql)
                .SetInt32("branchId", branchId)
                .SetInt32("organizationalCellId", organizationalCellId)
                .SetInt32("status", (int)EntityStatus.Active)
                .List<int>();

            return list.FirstOrDefault();
        }

        #endregion
        #region Criteria



        #endregion
    }
}
