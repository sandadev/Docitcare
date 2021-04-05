using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocitcareWebApp.Areas.Admin.Controllers
{
    [AreaAuthorize(area: "Admin")]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        [AreaAuthorize(area: "Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}