using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.Dashboard.Interface.Presentation.Dto;
using Workflow.Basic.Presentation.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workflow.Basic.Presentation.Infrastructure.Base;

namespace Workflow.Web.Api.Areas.CardIndex.Controllers
{
    public class VacationController : BaseApiController
    {
        #region Query

        private IVacationsFinder _vacationsFinder;

        #endregion 
        #region Command



        #endregion
        #region Dto



        #endregion
        #region Core



        #endregion
        #region Field and properties



        #endregion

        #region Init

        public VacationController()
        {
            Resolve();
        }

        private void Resolve()
        {
            _vacationsFinder = ContainerInit._container.Resolve<IVacationsFinder>();
        }

        #endregion

        #region API

        [HttpGet]
        public Root<VacationsDto> Vacation(int id)
        {
            var list = new List<VacationsDto>();

            list.Add(_vacationsFinder.FindVacation(id, DateTime.Now));

            return new Root<VacationsDto> { Items = list };
        }

        #endregion
    }
}