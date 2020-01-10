using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Workflow.Basic.Presentation.Attributes;

namespace Workflow.Basic.Presentation.Infrastructure.Base
{
    [ApiAuthorize]
    public class BaseApiController : ApiController
    {
    }
}
