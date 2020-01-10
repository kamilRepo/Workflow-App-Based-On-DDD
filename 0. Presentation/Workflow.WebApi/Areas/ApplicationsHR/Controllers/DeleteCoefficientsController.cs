using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workflow.Basic.Presentation.BasicModels;
using Workflow.HR.Interface.Application.Abstract;
using Workflow.HR.Interface.Presentation.FindersDto;
using Workflow.HR.Interface.Presentation.ServicesDto;
using Workflow.Basic.Presentation.Infrastructure.Base;

namespace Workflow.Web.Api.Areas.ApplicationsHR.Controllers
{
    public class DeleteCoefficientsController : BaseApiController
    {
        #region Query



        #endregion 
        #region Command

        private IStructureAndLocationService _structureAndLocationService;

        #endregion
        #region Dto



        #endregion
        #region Core



        #endregion
        #region Field and properties



        #endregion

        #region Init

        public DeleteCoefficientsController()
        {
            Resolve();
        }

        private void Resolve()
        {
            _structureAndLocationService = ContainerInit._container.Resolve<IStructureAndLocationService>();
        }

        #endregion

        #region API

        [HttpGet]
        public Root<StructureAndLocationResultDto> DeleteCoefficients([FromUri]StructureAndLocationDto structureAndLocationDto)
        {
            var list = new List<StructureAndLocationResultDto>();

            var result = _structureAndLocationService.DeleteCoefficients(structureAndLocationDto);

            list.Add(result);

            return new Root<StructureAndLocationResultDto> { Items = list }; 
        }

        #endregion
    }
}