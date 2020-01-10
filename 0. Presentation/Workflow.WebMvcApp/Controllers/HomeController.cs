using Workflow.Dashboard.Interface.Presentation.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workflow.Basic.Presentation.Infrastructure;
using Workflow.Basic.Presentation.Resources.Errors;
using Workflow.Basic.Presentation.Exceptions;
using Workflow.Base.Interface.Domain.Dictionaries;
using Workflow.Basic.Presentation.Attributes;
using Workflow.Basic.Presentation.Dictionaries;
using Workflow.Basic.Presentation.Extensions;
using Workflow.Base.DDD.Domain.Exceptions;
using System.Web.Routing;
using Workflow.Dashboard.Interface.Presentation.Dto;
using Workflow.Base.Infrastructure.Utilities;
using Workflow.Basic.Presentation.Helper;

namespace Workflow.Web.Mvc.App.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
