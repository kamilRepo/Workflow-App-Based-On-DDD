using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.Interface.Application.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Base.Interface.Application.BaseDto;
using Workflow.HR.Interface.Presentation.FindersDto;

namespace Workflow.HR.Interface.Application.Commands
{
    public class AddDeductionsSalaryCommand : ApplicationActionResult
    {
        public SalaryDeductionsDto SalaryDeductionsDto { get; private set; }

        [OutputCommandParameter]
        public int ReturnValue { get; set; }

        public AddDeductionsSalaryCommand(SalaryDeductionsDto salaryDeductionsDto)
        {
            SalaryDeductionsDto = salaryDeductionsDto;
            SalaryDeductionsDto.Success = false;
            SalaryDeductionsDto.ErrorNumber = ErrorNumbers.AddDeductionsSalaryCommand;
            SalaryDeductionsDto.ErrorMessage = "AddDeductionsSalary";
            Success = false;
            ErrorNumber = ErrorNumbers.AddDeductionsSalaryCommand;
            ErrorMessage = "AddDeductionsSalary";
            UserId = salaryDeductionsDto.UserId;
        }
    }
}
