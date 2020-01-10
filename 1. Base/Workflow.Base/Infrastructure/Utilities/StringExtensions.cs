using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Base.Infrastructure.Utilities
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string st)
        {
            return string.IsNullOrEmpty(st);
        }
    }
}
