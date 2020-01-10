using Workflow.HR.Interface.Presentation.ServicesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.HR.Interface.Application.Abstract
{
    public interface IEditDataPortalService
    {
        EditDataPortalResultDto EditDataPortal(EditDataPortalResultDto editDataPortalResultDto);
        EditAllocationStructureResultDto EditAllocationStructure(EditAllocationStructureResultDto editAllocationStructureResultDto);
    }
}
