using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.Interface.Application.BaseDto;

namespace Workflow.Permissions.Interface.Presentation.FindersDto
{
    public class RoleDto : ApplicationActionResult
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public RoleDto() { }

        public RoleDto(int id, string roleName)
        {
            Id = id;
            RoleName = roleName;
        }
    }
}
