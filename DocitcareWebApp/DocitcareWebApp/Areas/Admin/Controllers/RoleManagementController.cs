using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DocitcareWebApp.Core;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Persistence;
using DocitcareWebApp.Core.ViewModels;

namespace DocitcareWebApp.Areas.Admin.Controllers
{
    [AreaAuthorize(area: "Admin")]
    public class RoleManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

       public RoleManagementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/RoleManagement
        public ActionResult Role()
        {
            var roles = _unitOfWork.Roles.GetRolesWithStatus();
            ViewData["Roles"] = roles;
            return View();
        }

        // GET: Admin/RoleManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/RoleManagement/Create
        public ActionResult NewRole()
        {
            return View();
        }

        // POST: Admin/RoleManagement/Create
        [HttpPost]
        public ActionResult NewRole(Role role)
        {
            try
            {
                role.StatusID = 1;
                role.EntityId = 2;
                _unitOfWork.Roles.Add(role);
                _unitOfWork.Complete();
                return RedirectToAction("Role");
            }
            catch
            {
                var roles = _unitOfWork.Roles.GetRolesWithStatus();
                ViewData["Roles"] = roles;
                return View("Role");
            }
        }

        // GET: Admin/RoleManagement/Edit/5
        public ActionResult EditRole(int id)
        {
            return View();
        }

        // POST: Admin/RoleManagement/Edit/5
        [HttpPost]
        public ActionResult EditRole(int id, FormCollection collection)
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
