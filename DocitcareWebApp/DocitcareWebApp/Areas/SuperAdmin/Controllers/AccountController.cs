using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DocitcareWebApp.Core.Domain;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using DocitcareWebApp.Core.ViewModels;
using DocitcareWebApp.Persistence;
using DocitcareWebApp.Core;
using System.Web.Security;

namespace DocitcareWebApp.Areas.SuperAdmin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
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
        public ActionResult Login(SuperAdminRegistration model, string returnUrl)
        {
            //if (ModelState.IsValid)
            //{
                var isValid = _unitOfWork.SuperAdminRegistration.ValidateCredentails(model);

            if (isValid!=null)
            {
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    FormsAuthentication.SetAuthCookie(isValid.FirstName, true);
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Entity", new { area = "SuperAdmin" });
                }

            }
           
                ModelState.AddModelError("", "Invalid Credentials");
            //}
           
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Cookies[0].Expires.AddDays(-1);
            return RedirectToAction("Index","Entity",new {area="SuperAdmin" });
        }


    }
}
