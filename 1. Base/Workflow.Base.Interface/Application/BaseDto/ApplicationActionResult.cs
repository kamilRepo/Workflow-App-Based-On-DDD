using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.Base.Interface.Application.BaseDto
{
    public class ApplicationActionResult
    {
        public int UserId { get; set; }

        public bool Success { get; set; }

        public ErrorNumbers ErrorNumber { get; set; }

        public string ErrorMessage { get; set; }
    }
}
