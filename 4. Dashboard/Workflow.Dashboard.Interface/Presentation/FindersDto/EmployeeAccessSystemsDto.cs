using Workflow.Base.Interface.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Interface.Presentation.Dto
{
    public class EmployeeAccessSystemsDto : ApplicationActionResult
    {
        public int IdMigrationSystem { get; private set; }

        public string Name { get; private set; }

        public EmployeeAccessSystemsDto(int idMigrationSystem, string name)
        {
            IdMigrationSystem = idMigrationSystem;
            Name = name;
        }
    }
}
