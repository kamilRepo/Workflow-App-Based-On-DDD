using Workflow.Base.CQRS.Query.Attributes;
using Workflow.Base.Infrastructure.NHibernate;
using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.Dashboard.Interface.Presentation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using Workflow.Dashboard.Interface.Presentation.Criteria;
using NHibernate.Transform;
using Workflow.Basic.Domain.Domain.Entities;
using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.Infrastructure.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.Dashboard.Infrastructure.Finders
{
    [Finder]
    public class VacationsFinder : IVacationsFinder
    {
        public IEntityManager EntityManager { get; set; }

        #region Finders

        [ApplicationLayerException(ErrorNumbers.VacationsFinderFindVacation, "ErrorDataDownload")]
        public VacationsDto FindVacation(int employeeId, DateTime date)
        {
            var s = EntityManager.CurrentSession;

            return (
                from
                    e in s.Query<B_Vacations>()
                where
                    (e.Employee.Id == employeeId)
                select
                    new VacationsDto(e.HolidaysDue, e.HolidaysCalculated, e.HolidaysUnderpaid, e.HolidaysUsed, e.HolidaysRehabilitation, e.RemainedUnused, e.Art188KP)
           ).FirstOrDefault();
        }

        #endregion
        #region Criteria



        #endregion
    }
}
