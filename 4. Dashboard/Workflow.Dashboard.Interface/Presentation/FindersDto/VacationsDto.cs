using Workflow.Base.Interface.Application.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Dashboard.Interface.Presentation.Dto
{
    public class VacationsDto : ApplicationActionResult
    {
        public int HolidaysDue { get; set; }

        public int HolidaysCalculated { get; set; }

        public int HolidaysUnderpaid { get; set; }

        public int HolidaysUsed { get; set; }

        public int HolidaysRehabilitation { get; set; }

        public int RemainedUnused { get; set; }

        public int Art188KP { get; set; }

        public VacationsDto(int holidaysDue, int holidaysCalculated, int holidaysUnderpaid,
            int holidaysUsed, int holidaysRehabilitation, int remainedUnused, int art188KP)
        {
            HolidaysDue = holidaysDue;
            HolidaysCalculated = holidaysCalculated;
            HolidaysUnderpaid = holidaysUnderpaid;
            HolidaysUsed = holidaysUsed;
            HolidaysRehabilitation = holidaysRehabilitation;
            RemainedUnused = remainedUnused;
            Art188KP = art188KP;
        }
    }
}
