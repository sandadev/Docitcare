using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocitcareWebApp.Areas.Admin.Controllers
{
    public class StaffManagementController : Controller
    {
        // GET: Admin/StaffManagement
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/StaffManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/StaffManagement/Create
        public ActionResult Staff()
        {
            return View();
        }

        // POST: Admin/StaffManagement/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/StaffManagement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/StaffManagement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/StaffManagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/StaffManagement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
