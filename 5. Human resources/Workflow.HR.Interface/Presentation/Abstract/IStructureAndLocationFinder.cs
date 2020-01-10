using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.HR.Interface.Presentation.FindersDto;

namespace Workflow.HR.Interface.Presentation.Abstract
{
    public interface IStructureAndLocationFinder
    {
        List<StructureAndLocationDto> FindStructureEmployee(int employeeId);
    }
}
