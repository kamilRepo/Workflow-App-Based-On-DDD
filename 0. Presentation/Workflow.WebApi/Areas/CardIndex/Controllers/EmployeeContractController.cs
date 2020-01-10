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
    public class EmployeeContractController : BaseApiController
    {
        #region Query

        private IEmployeeContractFinder _employeeContractFinder;

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

        public EmployeeContractController()
        {
            Resolve();
        }

        private void Resolve()
        {
            _employeeContractFinder = ContainerInit._container.Resolve<IEmployeeContractFinder>();
        }

        #endregion

        #region API

        [HttpGet]
        public Root<EmployeeContractDto> EmployeeContract(int id)
        {
            var list = new List<EmployeeContractDto>();

            list.Add(_employeeContractFinder.FindEmployeeContract(id));

            return new Root<EmployeeContractDto> { Items = list };
        }

        #endregion
    }
}