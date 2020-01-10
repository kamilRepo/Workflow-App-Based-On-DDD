using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.CQRS.Commands.Handler;
using Workflow.Basic.Domain.Domain.Entities;
using Workflow.Basic.Domain.Domain.Entities.Dictionaries;
using Workflow.HR.Domain.Abstract;
using Workflow.HR.Interface.Application.Commands;

namespace Workflow.HR.Application.Commands.Handlers
{
    public class AddDeductionsSalaryHandler : ICommandHandler<AddDeductionsSalaryCommand>
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

        #region Handle

        public void Handle(AddDeductionsSalaryCommand command)
        {
            var employee = new B_Employee();
            employee.SetId(command.SalaryDeductionsDto.EmployeeId);

            var value = new B_SalaryDeductions()
            {
                Employee = employee,
                Amount = command.SalaryDeductionsDto.Amount,
                FromDate = command.SalaryDeductionsDto.FromDate,
                ToDate = command.SalaryDeductionsDto.ToDate,
                SalaryDeductionsType = (SalaryDeductionsType)command.SalaryDeductionsDto.SalaryDeductionsType,
                ContractNumber = command.SalaryDeductionsDto.ContractNumber,
                FirstInstallmentCapital = command.SalaryDeductionsDto.FirstInstallmentCapital,
                FirstInstallmentInterest = command.SalaryDeductionsDto.FirstInstallmentInterest,
                MonthlyCycle = command.SalaryDeductionsDto.MonthlyCycle,
                RegistrationNumber = command.SalaryDeductionsDto.RegistrationNumber
            };

            SalaryDeductionsRepository.Save(value, command.SalaryDeductionsDto.UserId);
            
            command.ReturnValue = value.Id;
            command.Success = true;
        }

        #endregion
    }
}
