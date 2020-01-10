using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.Dashboard.Interface.Presentation.Dto;
using Workflow.Basic.Presentation;
using Workflow.Basic.Presentation.BasicModels;
using Workflow.Basic.Presentation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workflow.Basic.Presentation.Infrastructure.Base;

namespace Workflow.Web.Api.Areas.CardIndex.Controllers
{
    public class EmployeeMembershipController : BaseApiController
    {
        #region Query

        private IEmployeeFinder _employeeFinder;

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

        public EmployeeMembershipController()
        {
            Resolve();
        }

        private void Resolve()
        {
            _employeeFinder = ContainerInit._container.Resolve<IEmployeeFinder>();
        }

        #endregion

        #region API

        [HttpGet]
        public Root<EmployeeMembershipDto> EmployeeMembership(int id)
        {
            var list = new List<EmployeeMembershipDto>();

            list.Add(_employeeFinder.FindEmployeeMembership(id));

            return new Root<EmployeeMembershipDto> { Items = list };
        }

        #endregion
    }
}