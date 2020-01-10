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
    public class EmployeeSalaryFinder : IEmployeeSalaryFinder
    {
        public IEntityManager EntityManager { get; set; }

        #region Finders

        [ApplicationLayerException(ErrorNumbers.EmployeeSalaryFinderFindEmployeeSalary, "ErrorDataDownload")]
        public EmployeeSalaryDto FindEmployeeSalary(int id)
        {
            var s = EntityManager.CurrentSession;

            string hql = @"
                SELECT 
                    s.BaseSalary as BaseSalary,
                    s.DiscretionaryBonus as DiscretionaryBonus,
                    s.MasterBonus as MasterBonus,
                    s.Bonus as Bonus,
                    'brak' as EquivalentVacation
                FROM B_Salary s
                WHERE
                    s.Employee = :id AND
                    s.Status = :status AND
                    s.Date <= :date
            ";

            var list = s.CreateQuery(hql)
                .SetInt32("id", id)
                .SetInt32("status", (int)EntityStatus.Active)
                .SetDateTime("date", DateTime.Now)
                .SetResultTransformer(Transformers.AliasToBean<EmployeeSalaryDto>())
                .List<EmployeeSalaryDto>();

            return list.FirstOrDefault();
        }

        #endregion
        #region Criteria

        
        
        #endregion
    }
}
