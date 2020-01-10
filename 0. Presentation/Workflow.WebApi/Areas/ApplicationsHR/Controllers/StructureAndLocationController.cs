using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workflow.Basic.Presentation.BasicModels;
using Workflow.HR.Interface.Presentation.Abstract;
using Workflow.HR.Interface.Presentation.FindersDto;
using Workflow.Basic.Presentation.Infrastructure.Base;

namespace Workflow.Web.Api.Areas.ApplicationsHR.Controllers
{
    public class StructureAndLocationController : BaseApiController
    {
        #region Query

        private IStructureAndLocationFinder _structureAndLocationFinder;

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

        public StructureAndLocationController()
        {
            Resolve();
        }

        private void Resolve()
        {
            _structureAndLocationFinder = ContainerInit._container.Resolve<IStructureAndLocationFinder>();
        }

        #endregion

        #region API

        [HttpGet]
        public Root<StructureAndLocationDto> FindStructureEmployee(int employeeId)
        {
            return new Root<StructureAndLocationDto> { Items = _structureAndLocationFinder.FindStructureEmployee(employeeId) };
        }

        #endregion
    }
}