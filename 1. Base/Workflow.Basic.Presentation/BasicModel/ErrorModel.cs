using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Basic.Presentation.BasicModel
{
    public class ErrorModel
    {
        public string Message { set; get; }
        public bool IsProduction { set; get; }
        public string ExceptionMessage { set; get; }
    }
}
