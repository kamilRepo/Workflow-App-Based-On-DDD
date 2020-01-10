using Workflow.Base.CQRS.Commands.Attributes;
using Workflow.Base.Interface.Application.BaseDto;
using Workflow.Basic.Domain.Domain.Entities;
using Workflow.Basic.Domain.Domain.Entities.Dictionaries;
using Workflow.HR.Domain.Abstract;
using Workflow.HR.Interface.Application.Abstract;
using Workflow.HR.Interface.Presentation.FindersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Base.Infrastructure.Attributes;
using Workflow.Base.CQRS.Commands;
using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.DDD.Application.Metadata;

namespace Workflow.HR.Application.Services
{
    [ApplicationService]
    public class DeductionsSalaryService : IDeductionsSalaryService
    {
        #region Finders



        #endregion
        #region DomainServices



        #endregion
        #region AppServices


        #endregion
        #region Repositories

        public ISalaryDeductionsRepository SalaryDeductionsRepository { get; set; }

        #endregion

        #region IMyPortalService members

        [RunInTransactionAspect(IsolationLevel.ReadCommitted)]
        [ApplicationLayerException(ErrorNumbers.DeductionsSalaryServiceAddDeductionsSalary, "AddDeductionsSalary")]        
        public int AddDeductionsSalary(SalaryDeductionsDto salaryDeductionsDto)
        {
            var employee = new B_Employee();
            employee.SetId(salaryDeductionsDto.EmployeeId);

            var value = new B_SalaryDeductions(){
                Employee = employee,
                Amount = salaryDeductionsDto.Amount,
                FromDate = salaryDeductionsDto.FromDate,
                ToDate = salaryDeductionsDto.ToDate,
                SalaryDeductionsType = (SalaryDeductionsType)salaryDeductionsDto.SalaryDeductionsType,
                ContractNumber = salaryDeductionsDto.ContractNumber,
                FirstInstallmentCapital = salaryDeductionsDto.FirstInstallmentCapital,
                FirstInstallmentInterest = salaryDeductionsDto.FirstInstallmentInterest,
                MonthlyCycle = salaryDeductionsDto.MonthlyCycle,
                RegistrationNumber = salaryDeductionsDto.RegistrationNumber
            };

            SalaryDeductionsRepository.SaveAndFlush(value, salaryDeductionsDto.UserId);

            return value.Id;
        }

        [RunInTransactionAspect(IsolationLevel.ReadCommitted)]
        [ApplicationLayerException(ErrorNumbers.DeductionsSalaryServiceUpdateDeductionsSalary, "UpdateDeductionsSalary")]
        public void UpdateDeductionsSalary(SalaryDeductionsDto salaryDeductionsDto)
        {
            var value = SalaryDeductionsRepository.Load(salaryDeductionsDto.Id);

            value.Amount = salaryDeductionsDto.Amount;
            value.FromDate = salaryDeductionsDto.FromDate;
            value.ToDate = salaryDeductionsDto.ToDate;
            value.ContractNumber = salaryDeductionsDto.ContractNumber;
            value.FirstInstallmentCapital = salaryDeductionsDto.FirstInstallmentCapital;
            value.FirstInstallmentInterest = salaryDeductionsDto.FirstInstallmentInterest;
            value.MonthlyCycle = salaryDeductionsDto.MonthlyCycle;
            value.RegistrationNumber = salaryDeductionsDto.RegistrationNumber;

            SalaryDeductionsRepository.SaveAndFlush(value, salaryDeductionsDto.UserId);
        }

        [RunInTransactionAspect(IsolationLevel.ReadCommitted)]
        [ApplicationLayerException(ErrorNumbers.DeductionsSalaryServiceDeleteDeductionsSalary, "DeleteDeductionsSalary")]
        public void DeleteDeductionsSalary(SalaryDeductionsDto salaryDeductionsDto)
        {
            SalaryDeductionsRepository.Delete(salaryDeductionsDto.Id, salaryDeductionsDto.UserId);
        }

        #endregion
    }
}
