using Workflow.Basic.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.Base.DDD.Domain.Entities;

namespace Workflow.Basic.Domain.Domain.Entities
{
    public class B_Vacations : Entity
    {
        public B_Employee Employee { get; set; }

        public int HolidaysDue { get; set; }

        public int HolidaysCalculated { get; set; }

        public int HolidaysUnderpaid { get; set; }

        public int HolidaysUsed { get; set; }

        public int HolidaysRehabilitation { get; set; }

        public int RemainedUnused { get; set; }
        
        public int Art188KP { get; set; }
    }
}
