using Workflow.Base.Interface.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Interface.Presentation.Dto
{
    public class DictionaryDto : ApplicationActionResult
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public DictionaryDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
