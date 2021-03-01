using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocitcareWebApp.Areas.Admin.Controllers
{
    public class LoginPageController : Controller
    {
        // GET: Admin/LoginPage
        public ActionResult Login()
        {
            return View();
        }
    }
}