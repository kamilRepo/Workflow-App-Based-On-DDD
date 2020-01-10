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
    public class EmployeeSalaryController : BaseApiController
    {
        #region Query

        private IEmployeeSalaryFinder _employeeSalaryFinder;

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

        public EmployeeSalaryController()
        {
            Resolve();
        }

        private void Resolve()
        {
            _employeeSalaryFinder = ContainerInit._container.Resolve<IEmployeeSalaryFinder>();
        }

        #endregion

        #region API

        [HttpGet]
        public Root<EmployeeSalaryDto> EmployeeSalary(int id)
        {
            var list = new List<EmployeeSalaryDto>();

            list.Add(_employeeSalaryFinder.FindEmployeeSalary(id));

            return new Root<EmployeeSalaryDto> { Items = list };
        }

        #endregion
    }
}