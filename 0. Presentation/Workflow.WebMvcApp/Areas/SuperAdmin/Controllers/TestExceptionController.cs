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

namespace Workflow.Web.Mvc.App.Areas.SuperAdmin.Controllers
{
    [Authorize(Roles = RoleName.SuperAdmin)]
    [PresentationMvcLayerExceptionAttribute("Index", "TestException", "SuperAdmin")]
    public class TestExceptionController : BaseController
    {
        public IEmployeeFinder EmployeeFinder { get; set; }

        public void Divide()
        {
            int a = 5;
            int b = 0;
            a = a / b;
        }
        public void TestEx()
        {
            RouteValueDictionary route = new RouteValueDictionary();
            route.Add("area", "SuperAdmin");
            route.Add("controller", "TestException");
            route.Add("action", "Index2");            
            var redirect = new RedirectToRouteResult(route);

            EmployeeDto em;
            var bo = false;
            if(bo)
                em = EmployeeFinder.FindEmployee(1);
            if (bo)
                throw new UserException("CheckingPermissions", ErrorNumbers.MyPortalServiceCheckAccessPolicy, 18);
            if (bo)
                throw new ApplicationLayerException("NoData", ErrorNumbers.ApplicationsHRMyPortalGetData, 18);
            if (bo)
                throw new WebException("EditDataPortal", ErrorNumbers.MyPortalGetData, 18);
            if (bo)
                throw new WebException("AddDeductionsSalary", ErrorNumbers.DeductionsSalaryServiceAddDeductionsSalary, 18, redirect);
            if (bo)
                throw new Exception("Fuck error");
            if (bo)
                Divide();
        }

        [PresentationMvcLayerExceptionAttribute("Index2", "TestException", "SuperAdmin")]
        public ActionResult Index()
        {
            var user = User;//.Identity.Name;

            var pass = "kamil";
            var hash = PasswordHash.CreateHash(pass);

            var var = PasswordHash.ValidatePassword(pass, hash);
            //this.ShowMessage(NotificationMessageType.Error, Errors.EditDataPortal);
            var v = false;
            if (v)
                TestEx();
            return View();
        }

        public ActionResult Index2()
        {
            var v = false;
            if (v)
                TestEx();
            return View("Index");
        }

        [PresentationMvcLayerExceptionAttribute("Index2", "TestException", "SuperAdmin")]
        [HttpPost]
        public ActionResult Index(string message)
        {
            this.ShowMessage(NotificationMessageType.Success, message);
            TestEx();
            
            return View();
        }

        [PresentationMvcLayerExceptionAttribute("Index2", "TestException", "SuperAdmin")]
        public ActionResult RedirectWithWarning()
        {
            this.ShowMessage(NotificationMessageType.Warning, Errors.Error, "AddDeductionsSalary", true);
            TestEx();
            return RedirectToAction("Index");
        }

        [PresentationMvcLayerExceptionAttribute("Index2", "TestException", "SuperAdmin")]
        public ActionResult Partial()
        {
            this.ShowMessage(NotificationMessageType.Error, Errors.Error, "CheckingPermissions");
            TestEx();
            return PartialView("_PartialTestView");
        }

        [PresentationMvcLayerExceptionAttribute("Index2", "TestException", "SuperAdmin")]
        public ActionResult JsonData()
        {
            this.ShowMessage(NotificationMessageType.Warning, Errors.Error, "DeleteCoefficients");
            TestEx();
            var result = new JsonResult();
            result.Data = new { Code = 584, Description = "Some arbitrary JSON data", TheDate = DateTime.Now.ToString() };
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }
    }
}