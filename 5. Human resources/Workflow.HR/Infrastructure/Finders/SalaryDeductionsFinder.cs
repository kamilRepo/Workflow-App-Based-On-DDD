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
using Workflow.HR.Interface.Presentation.Abstract;
using Workflow.HR.Interface.Presentation.FindersDto;
using Workflow.Basic.Domain.Domain.Entities.Dictionaries;
using Workflow.Base.Infrastructure.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.HR.Infrastructure.Finders
{
    [Finder]
    public class SalaryDeductionsFinder : ISalaryDeductionsFinder
    {
        public IEntityManager EntityManager { get; set; }

        #region Finders

        [ApplicationLayerException(ErrorNumbers.SalaryDeductionsFinderFindSalaryDeductions, "ErrorDataDownload")]
        public List<SalaryDeductionsDto> FindSalaryDeductions(int SalaryDeductionsType, int employeeId)
        {
            var s = EntityManager.CurrentSession;

            string hql = @"
                SELECT 
                    sd.Id as Id, 
                    e.Id as EmployeeId, 
                    sd.FromDate as FromDate, 
                    sd.ToDate as ToDate, 
                    sd.SalaryDeductionsType as SalaryDeductionsType, 
                    sd.Amount as Amount, 
                    e.FirstName as FirstName, 
                    e.LastName as LastName,
                    e.EmployeeNumber as EmployeeNumber,
                    e.LastName + ' ' + e.FirstName as LastFirstName,
                    sd.ContractNumber as ContractNumber,
                    sd.FirstInstallmentCapital as FirstInstallmentCapital,
                    sd.FirstInstallmentInterest as FirstInstallmentInterest,
                    sd.MonthlyCycle as MonthlyCycle,
                    sd.RegistrationNumber as RegistrationNumber
                FROM B_SalaryDeductions sd
                    LEFT JOIN sd.Employee e
                WHERE
                    sd.Status = :status AND
                    sd.ToDate >= :dateNow AND
                    sd.SalaryDeductionsType = :SalaryDeductionsType";

            if(employeeId != 0)
                hql += " AND  e.id = :employeeId";

            hql += " ORDER BY sd.FromDate ";

            var createQuerys = s.CreateQuery(hql)
                .SetInt32("status", (int)EntityStatus.Active)
                .SetDateTime("dateNow", DateTime.Now)
                .SetInt32("SalaryDeductionsType", SalaryDeductionsType);

            if(employeeId != 0)
                createQuerys.SetInt32("employeeId", employeeId);

            var list = createQuerys
                .SetResultTransformer(Transformers.AliasToBean<SalaryDeductionsDto>())
                .List<SalaryDeductionsDto>();

            return list.ToList();
        }

        #endregion
        #region Criteria



        #endregion
    }
}
