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
    public class PlaceWhereCostsAriseController : BaseApiController
    {
        #region Query

        private IDictionaryFinder _dictionaryFinder;

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

        public PlaceWhereCostsAriseController()
        {
            Resolve();
        }

        private void Resolve()
        {
            _dictionaryFinder = ContainerInit._container.Resolve<IDictionaryFinder>();
        }

        #endregion

        #region API

        [HttpGet]
        public Root<DictionaryDto> PlaceWhereCostsArise()
        {
            return new Root<DictionaryDto> { Items = _dictionaryFinder.FindSection() };
        }

        #endregion
    }
}