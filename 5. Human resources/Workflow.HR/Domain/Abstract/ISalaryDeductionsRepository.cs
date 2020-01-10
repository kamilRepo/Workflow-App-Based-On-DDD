using Workflow.Basic.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.HR.Domain.Abstract
{
    public interface ISalaryDeductionsRepository
    {
        void Save(B_SalaryDeductions salaryDeductions, int userId);
        void SaveAndFlush(B_SalaryDeductions salaryDeductions, int userId);
        B_SalaryDeductions Load(int salaryDeductionsId);
        void Delete(int salaryDeductionsId, int userId);
    }
}
