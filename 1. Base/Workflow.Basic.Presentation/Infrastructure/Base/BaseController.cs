using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Workflow.Basic.Presentation.Attributes;

namespace Workflow.Basic.Presentation.Infrastructure
{
    [Authorize]
    [PresentationMvcLayerExceptionAttribute]
    public class BaseController : Controller
    {
    }
}
