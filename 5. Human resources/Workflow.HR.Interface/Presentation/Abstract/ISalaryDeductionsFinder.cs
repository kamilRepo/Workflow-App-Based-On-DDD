using Workflow.HR.Interface.Presentation.FindersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.HR.Interface.Presentation.Abstract
{
    public interface ISalaryDeductionsFinder
    {
        List<SalaryDeductionsDto> FindSalaryDeductions(int SalaryDeductionsType, int employeeId);
    }
}
