using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocitcareWebApp.Core;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.ViewModels;
using DocitcareWebApp.Persistence;

namespace DocitcareWebApp.Areas.Admin.Controllers
{
    public class DoctorManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DoctorManagementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/DoctorManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/DoctorManagement/Create
        public ActionResult Doctor()
        {
            var doctorViewModel = new UserViewModel()
            {
                Branches = _unitOfWork.Branch.GetAll(),
                Roles = _unitOfWork.Roles.GetAll(),
                Categories = _unitOfWork.Category.GetAll(),
                Departments=_unitOfWork.Department.GetAll()
            };
            return View(doctorViewModel);
        }

        // POST: Admin/DoctorManagement/Create
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

        // GET: Admin/DoctorManagement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/DoctorManagement/Edit/5
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

        // GET: Admin/DoctorManagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/DoctorManagement/Delete/5
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
