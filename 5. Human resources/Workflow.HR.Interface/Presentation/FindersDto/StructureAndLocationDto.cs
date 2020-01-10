using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.Interface.Application.BaseDto;

namespace Workflow.HR.Interface.Presentation.FindersDto
{
    public class StructureAndLocationDto : ApplicationActionResult
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public double Coefficient { get; set; }

        public string CoefficientDecimal { get { return Coefficient.ToString("0.00"); } }

        public int OrganizationalUnitId { get; set; }

        public int OrganizationalCellId { get; set; }

        public int SiloId { get; set; }

        public string OrganizationalUnit { get; set; }

        public string OrganizationalCell { get; set; }

        public string Silo { get; set; }

        public string Code { get; set; }

        public StructureAndLocationDto() { }
    }
}
