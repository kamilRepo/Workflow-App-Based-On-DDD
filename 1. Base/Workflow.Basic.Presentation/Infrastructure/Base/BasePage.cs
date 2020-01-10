using Workflow.Dashboard.Interface.Presentation.Dto;
using Workflow.Basic.Presentation.BasicModels;
using Workflow.Basic.Presentation.Helper;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Workflow.Basic.Presentation.Infrastructure
{
    public class BasePage : Page
    {
        protected Guid PageNumber { get; private set; }
        protected SessionUser SessionUser { get; private set; }

        protected void InitData(Guid pageNumbers, SessionUser sessionUser)
        {
            PageNumber = pageNumbers;

            //TODO 
            //SessionUser = sessionUser;
            var value = HttpContext.Current.Request.Cookies[SessionVariables.sessionUserId].Value;
            if (!string.IsNullOrEmpty(value))
            {
                int id = Convert.ToInt32(value);
                if (id == 409)
                    id = 2;
                var user = new SessionUser(
                    id, "Jan", "Kowalski", "jan.kowalski@workflow.pl", false, false, true, false);
                
                Session[SessionVariables.user] = user;
                SessionUser = user;

                HttpContext.Current.Response.Cookies[SessionVariables.sessionUserId].Value = value.ToString();
                HttpContext.Current.Response.Cookies[SessionVariables.sessionUserId].Expires = DateTime.Now.AddDays(1);
                HttpContext.Current.Response.Cookies[SessionVariables.sessionUserId].HttpOnly = true;
                HttpContext.Current.Response.Cookies[SessionVariables.sessionUserId].Shareable = true;
            }

        }

        protected override void InitializeCulture()
        {
            UICulture = Request.UserLanguages[0];
            base.InitializeCulture();
        }

        protected int GetIdFromUrl()
        {
            int id = 0;
            if (Request.QueryString["id"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
            }

            return id;
        }

        protected string Translate(string classKey, string resourceKey)
        {
            return PageMethodsHelper.Translate(classKey, resourceKey);
        }
    }
}