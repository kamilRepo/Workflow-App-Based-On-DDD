using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Base.Infrastructure.Config
{
    public interface IBaseSettings
    {
        string TempPath { get; }
        bool IsProduction { get; }
        bool GenerateSchema { get; }
    }
}
