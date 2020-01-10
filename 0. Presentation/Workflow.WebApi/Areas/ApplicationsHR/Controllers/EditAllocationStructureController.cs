using Workflow.HR.Interface.Application.Abstract;
using Workflow.HR.Interface.Presentation.ServicesDto;
using Workflow.Basic.Presentation.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workflow.Basic.Presentation.Infrastructure.Base;

namespace Workflow.Web.Api.Areas.ApplicationsHR.Controllers
{
    public class EditAllocationStructureController : BaseApiController
    {
        #region Query



        #endregion 
        #region Command

        private IEditDataPortalService _editDataPortalService;

        #endregion
        #region Dto



        #endregion
        #region Core



        #endregion
        #region Field and properties



        #endregion

        #region Init

        public EditAllocationStructureController()
        {
            Resolve();
        }

        private void Resolve()
        {
            _editDataPortalService = ContainerInit._container.Resolve<IEditDataPortalService>();
        }

        #endregion

        #region API

        [HttpGet]
        public Root<EditAllocationStructureResultDto> EditAllocationStructure([FromUri]EditAllocationStructureResultDto editAllocationStructureResultDto)
        {
            var list = new List<EditAllocationStructureResultDto>();

            var value = _editDataPortalService.EditAllocationStructure(editAllocationStructureResultDto);

            list.Add(value);

            return new Root<EditAllocationStructureResultDto> { Items = list }; 
        }

        #endregion
    }
}