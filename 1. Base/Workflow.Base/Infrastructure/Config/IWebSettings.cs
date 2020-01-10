using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Base.Infrastructure.Config
{
    public interface IWebSettings
    {
        string WebApiUrl { get; }

        string WebFormUrl { get; }

        string WebMvcUrl { get; }
    }
}
