using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.Interface.Application.BaseDto;

namespace Workflow.Permissions.Interface.Presentation.ServicesDto
{
    public class LoginDto : ApplicationActionResult
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
