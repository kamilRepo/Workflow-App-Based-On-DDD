using Workflow.Base.Interface.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.HR.Interface.Presentation.ServicesDto
{
    public class SalaryDeductionsResultDto : ApplicationActionResult
    {
        public int Id { get; set; }

        public SalaryDeductionsResultDto(int id)
        {
            Id = id;
        }
    }
}
