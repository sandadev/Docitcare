using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DocitcareWebApp.Core;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Persistence;

namespace DocitcareWebApp.Areas.Admin.Controllers
{
    public class RoleManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

       public RoleManagementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/RoleManagement
        public ActionResult Index()
        {
            var Roles = _unitOfWork.Roles.GetRolesWithStatus();
            return View(Roles);
        }

        // GET: Admin/RoleManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/RoleManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RoleManagement/Create
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

        // GET: Admin/RoleManagement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/RoleManagement/Edit/5
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

        // GET: Admin/RoleManagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/RoleManagement/Delete/5
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
