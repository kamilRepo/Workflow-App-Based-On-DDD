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
    public class EmployeeContractFinder : IEmployeeContractFinder
    {
        public IEntityManager EntityManager { get; set; }

        #region Finders

        [ApplicationLayerException(ErrorNumbers.EmployeeContractFinderFindEmployeeContract, "ErrorDataDownload")]
        public EmployeeContractDto FindEmployeeContract(int id)
        {
            var s = EntityManager.CurrentSession;

            string hql = @"
                SELECT 
                    c.DimensionTime as DimensionTime,
                    c.FromDate as FromDate,
                    c.ToDate as ToDate,
                    c.DismissDate as DismissDate,
                    c.TypeContract as TypeContract
                FROM 
                    B_Contract c
                WHERE
                    c.Employee = :id AND
                    c.Status = :status AND
                    c.FromDate <= :date
            ";

            var list = s.CreateQuery(hql)
                .SetInt32("id", id)
                .SetInt32("status", (int)EntityStatus.Active)
                .SetDateTime("date", DateTime.Now)
                .SetResultTransformer(Transformers.AliasToBean<EmployeeContractDto>())
                .List<EmployeeContractDto>();

            return list.FirstOrDefault();
        }

        #endregion
        #region Criteria



        #endregion
    }
}

