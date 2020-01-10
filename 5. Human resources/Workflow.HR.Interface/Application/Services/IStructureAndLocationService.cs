using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.HR.Interface.Presentation.FindersDto;
using Workflow.HR.Interface.Presentation.ServicesDto;

namespace Workflow.HR.Interface.Application.Abstract
{
    public interface IStructureAndLocationService
    {
        StructureAndLocationResultDto DeleteCoefficients(StructureAndLocationDto structureAndLocationDto);
        StructureAndLocationResultDto SaveCoefficients(StructureAndLocationDto structureAndLocationDto);
    }
}
