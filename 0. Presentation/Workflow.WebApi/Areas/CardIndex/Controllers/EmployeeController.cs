using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.Dashboard.Interface.Presentation.Criteria;
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
    public class EmployeeController : BaseApiController
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

        public EmployeeController()
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
        public Root<EmployeeDto> Employee(int id)
        {
            var list = new List<EmployeeDto>();

            list.Add(_employeeFinder.FindEmployee(id));

            return new Root<EmployeeDto> { Items =  list };
        }

        #endregion
    }
}