using Workflow.Base.Interface.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.HR.Interface.Presentation.ServicesDto
{
    public class EditAllocationStructureResultDto : ApplicationActionResult
    {
        public int EmployeeMembershipId { get; set; }

        public string Position { get; set; }

        public int SectionId { get; set; }

        public int OrganizationalUnitId { get; set; }

        public int OrganizationalCellId { get; set; }

        public int WorksId { get; set; }

        public int DirectSupervisorId { get; set; }

        public int ProductSectionId { get; set; }

        public int PlaceWhereCostsAriseId { get; set; }
    }
}
