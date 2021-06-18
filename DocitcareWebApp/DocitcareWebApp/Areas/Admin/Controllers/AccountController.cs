using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocitcareWebApp.Core.ViewModels;
using DocitcareWebApp.Persistence;
using DocitcareWebApp.Core;
using System.Web.Security;
using DocitcareWebApp.Core.Domain;
using log4net;

namespace DocitcareWebApp.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private static readonly ILog Log = LogManager.GetLogger(typeof(AccountController));
        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDetails model, string returnUrl)
        {
            Log.Info("Hi I am log4net Info Level");
            var isValid = _unitOfWork.User.ValidateCredentails(model);
            if (isValid!=null)
            {
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    FormsAuthentication.SetAuthCookie(isValid.FirstName, true);
                    Session["entity"] = isValid.EntityId;
                    Session["staffid"] = isValid.UserId;
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
            }
            ModelState.AddModelError("", "Invalid Credentials");
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Cookies[0].Expires.AddDays(-1);
            Session.Abandon();//Abandon session
            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }
    }
}