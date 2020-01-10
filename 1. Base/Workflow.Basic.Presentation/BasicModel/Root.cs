using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.Interface.Application.BaseDto;

namespace Workflow.Basic.Presentation.BasicModels
{
    public class Root<T> : ApplicationActionResult
    {
        public List<T> Items { get; set; }
    }
}
