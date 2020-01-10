using Workflow.Dashboard.Interface.Application.Abstract;
using Workflow.Dashboard.Interface.Presentation.ServicesDto;
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
    public class MyPortalController : BaseApiController
    {
        #region Query

        private IMyPortalService _myPortalService;

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

        public MyPortalController()
        {
            Resolve();
        }

        private void Resolve()
        {
            _myPortalService = ContainerInit._container.Resolve<IMyPortalService>();
        }

        #endregion

        #region API

        [HttpGet]
        public Root<AccessPolicyDto> MyPortalAccess([FromUri]AccessPolicyDto accessPolicyDto)
        {
            var list = new List<AccessPolicyDto>();

            list.Add(_myPortalService.CheckAccessPolicy(accessPolicyDto));

            return new Root<AccessPolicyDto> { Items = list };
        }

        #endregion
    }
}