using Workflow.Base.Interface.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Interface.Presentation.Dto
{
    public class EmployeeContractDto  : ApplicationActionResult
    {
        public float DimensionTime { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime DismissDate { get; set; }

        public string TypeContract { get; set; }

        public EmployeeContractDto() { }

        public EmployeeContractDto(float dimensionTime, DateTime fromDate, DateTime toDate,
            DateTime dismissDate, string typeContract)
        {
            DimensionTime = dimensionTime;
            FromDate = fromDate;
            ToDate = toDate;
            DismissDate = dismissDate;
            TypeContract = typeContract;
        }
    }
}
