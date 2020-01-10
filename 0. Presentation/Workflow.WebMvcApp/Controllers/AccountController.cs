﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Workflow.Web.Mvc.App.Models;
using Workflow.Basic.Presentation.Attributes;
using Workflow.Basic.Presentation.Infrastructure;
using Workflow.Basic.Presentation.Resources.Common;
using Workflow.Base.Infrastructure.Config;

namespace Workflow.Web.Mvc.App.Controllers
{
    [InitializeSimpleMembership]
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public ActionResult RedirectSide()
        {
            return RedirectToLocal(string.Empty);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return RedirectToAction("RedirectSide", "Account");
                //return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", Common.UserNamePasswordIncorrect);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult ExternalLogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            throw new NotImplementedException();
            //TODO
            //return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            throw new NotImplementedException();
            //TODO
            //if (ModelState.IsValid)
            //{
            //    // Attempt to register the user
            //    try
            //    {
            //        WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
            //        WebSecurity.Login(model.UserName, model.Password);
            //        return RedirectToAction("Login", "Account");
            //    }
            //    catch (MembershipCreateUserException e)
            //    {
            //        ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
            //    }
            //}

            //// If we got this far, something failed, redisplay form
            //return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            throw new NotImplementedException();
            //TODO
            //string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            //ManageMessageId? message = null;

            //// Only disassociate the account if the currently logged in user is the owner
            //if (ownerAccount == User.Identity.Name)
            //{
            //    // Use a transaction to prevent the user from deleting their last login credential
            //    using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
            //    {
            //        bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            //        if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
            //        {
            //            OAuthWebSecurity.DeleteAccount(provider, providerUserId);
            //            scope.Complete();
            //            message = ManageMessageId.RemoveLoginSuccess;
            //        }
            //    }
            //}

            //return RedirectToAction("Manage", new { Message = message });
        }

        public ActionResult Manage(ManageMessageId? message)
        {
            throw new NotImplementedException();
            //TODO
            //ViewBag.StatusMessage =
            //    message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
            //    : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
            //    : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
            //    : "";
            //ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            //ViewBag.ReturnUrl = Url.Action("Manage");
            //return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            throw new NotImplementedException();
            //TODO
            //bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            //ViewBag.HasLocalPassword = hasLocalAccount;
            //ViewBag.ReturnUrl = Url.Action("Manage");
            //if (hasLocalAccount)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        // ChangePassword will throw an exception rather than return false in certain failure scenarios.
            //        bool changePasswordSucceeded;
            //        try
            //        {
            //            changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
            //        }
            //        catch (Exception)
            //        {
            //            changePasswordSucceeded = false;
            //        }

            //        if (changePasswordSucceeded)
            //        {
            //            return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
            //        }
            //        else
            //        {
            //            ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
            //        }
            //    }
            //}
            //else
            //{
            //    // User does not have a local password so remove any validation errors caused by a missing
            //    // OldPassword field
            //    ModelState state = ModelState["OldPassword"];
            //    if (state != null)
            //    {
            //        state.Errors.Clear();
            //    }

            //    if (ModelState.IsValid)
            //    {
            //        try
            //        {
            //            WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
            //            return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
            //        }
            //        catch (Exception)
            //        {
            //            ModelState.AddModelError("", String.Format("Unable to create local account. An account with the name \"{0}\" may already exist.", User.Identity.Name));
            //        }
            //    }
            //}

            //// If we got this far, something failed, redisplay form
            //return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            throw new NotImplementedException();
            //TODO
            //return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            throw new NotImplementedException();
            //TODO
            //var result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            //if (!result.IsSuccessful)
            //{
            //    return RedirectToAction("ExternalLoginFailure");
            //}

            //if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            //{
            //    return RedirectToLocal(returnUrl);
            //}

            //if (User.Identity.IsAuthenticated)
            //{
            //    // If the current user is logged in add the new account
            //    OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
            //    return RedirectToLocal(returnUrl);
            //}
            //else
            //{
            //    // User is new, ask for their desired membership name
            //    string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
            //    ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
            //    ViewBag.ReturnUrl = returnUrl;
            //    return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            //}
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            throw new NotImplementedException();
            //TODO
            //string provider = null;
            //string providerUserId = null;

            //if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
            //{
            //    return RedirectToAction("Manage");
            //}

            //if (ModelState.IsValid)
            //{
            //    // Insert a new user into the database
            //    /*using (UsersContext db = new UsersContext())
            //    {
            //        UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
            //        // Check if user already exists
            //        if (user == null)
            //        {
            //            // Insert name into the profile table
            //            db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
            //            db.SaveChanges();

            //            OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
            //            OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

            //            return RedirectToLocal(returnUrl);
            //        }
            //        else
            //        {
            //            ModelState.AddModelError("UserName", "User name already exists. Please enter a different user name.");
            //        }
            //    }*/
            //}

            //ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            //ViewBag.ReturnUrl = returnUrl;
            //return View(model);
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            throw new NotImplementedException();
            //TODO
            //return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            throw new NotImplementedException();
            //TODO
            //ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            //List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            //foreach (OAuthAccount account in accounts)
            //{
            //    AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

            //    externalLogins.Add(new ExternalLogin
            //    {
            //        Provider = account.Provider,
            //        ProviderDisplayName = clientData.DisplayName,
            //        ProviderUserId = account.ProviderUserId,
            //    });
            //}

            //ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            //return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }

        #region Helpers

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                var settings = SettingsProvider.WebSettings;
                var url = string.Format("{0}{1}", settings.WebFormUrl, "Views/CardIndex/SearchEmployee.aspx");
                return Redirect(url);
                //return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            throw new NotImplementedException();
            //TODO
            //switch (createStatus)
            //{
            //    case MembershipCreateStatus.DuplicateUserName:
            //        return "User name already exists. Please enter a different user name.";

            //    case MembershipCreateStatus.DuplicateEmail:
            //        return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

            //    case MembershipCreateStatus.InvalidPassword:
            //        return "The password provided is invalid. Please enter a valid password value.";

            //    case MembershipCreateStatus.InvalidEmail:
            //        return "The e-mail address provided is invalid. Please check the value and try again.";

            //    case MembershipCreateStatus.InvalidAnswer:
            //        return "The password retrieval answer provided is invalid. Please check the value and try again.";

            //    case MembershipCreateStatus.InvalidQuestion:
            //        return "The password retrieval question provided is invalid. Please check the value and try again.";

            //    case MembershipCreateStatus.InvalidUserName:
            //        return "The user name provided is invalid. Please check the value and try again.";

            //    case MembershipCreateStatus.ProviderError:
            //        return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

            //    case MembershipCreateStatus.UserRejected:
            //        return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

            //    default:
            //        return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            //}
        }

        #endregion
    }
}
