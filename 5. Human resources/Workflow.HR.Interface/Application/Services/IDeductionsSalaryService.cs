using Workflow.HR.Interface.Presentation.FindersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.HR.Interface.Application.Abstract
{
    public interface IDeductionsSalaryService
    {
        int AddDeductionsSalary(SalaryDeductionsDto salaryDeductionsDto);
        void UpdateDeductionsSalary(SalaryDeductionsDto salaryDeductionsDto);
        void DeleteDeductionsSalary(SalaryDeductionsDto salaryDeductionsDto);
    }
}
