using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.CQRS.Query.Attributes;
using Workflow.HR.Interface.Presentation.Abstract;
using NHibernate.Linq;
using NHibernate.Transform;
using Workflow.Base.Infrastructure.NHibernate;
using Workflow.Basic.Domain.Domain.Entities.Dictionaries;
using Workflow.HR.Interface.Presentation.FindersDto;
using Workflow.Base.Infrastructure.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.HR.Infrastructure.Finders
{
    [Finder]
    public class StructureAndLocationFinder : IStructureAndLocationFinder
    {
        public IEntityManager EntityManager { get; set; }

        #region Finders

        [ApplicationLayerException(ErrorNumbers.StructureAndLocationFinderFindStructureEmployee, "ErrorDataDownload")]
        public List<StructureAndLocationDto> FindStructureEmployee(int employeeId)
        {
            var s = EntityManager.CurrentSession;

            string hql = @"
                SELECT 
                    emc.Id as Id, 
                    emc.Coefficient as Coefficient,
                    ou.Id as OrganizationalUnitId,
                    ou.Name as OrganizationalUnit,
                    oc.Id as OrganizationalCellId,
                    oc.Name as OrganizationalCell,
                    s.Id as SiloId,
                    s.Name as Silo,
                    ou.Code + '-' + oc.Code + '-' + s.Code as Code
                FROM B_EmployeeMembershipCoefficients emc
                    LEFT JOIN emc.OrganizationalUnit ou
                    LEFT JOIN emc.OrganizationalCell oc
                    LEFT JOIN emc.Silo s
                WHERE
                    emc.Status = :status AND
                    emc.Employee = :employeeId
                ORDER BY 
                    emc.FromDate ";

            var createQuerys = s.CreateQuery(hql)
                .SetInt32("status", (int)EntityStatus.Active)
                .SetInt32("employeeId", employeeId);

            var list = createQuerys
                .SetResultTransformer(Transformers.AliasToBean<StructureAndLocationDto>())
                .List<StructureAndLocationDto>();

            return list.ToList();
        }

        #endregion
        #region Criteria



        #endregion        
    }
}
