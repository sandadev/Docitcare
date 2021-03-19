using DocitcareWebApp.Core;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocitcareWebApp.Areas.SuperAdmin.Controllers
{
    public class EntityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EntityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: SuperAdmin/Entity
        public ActionResult Index()
        {
            var entity = _unitOfWork.Entities.GetAll();
            return View(entity);
        }

        // GET: SuperAdmin/Entity/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SuperAdmin/Entity/Create
        public ActionResult NewEntity()
        {
            return View();
        }

        // POST: SuperAdmin/Entity/Create
        [HttpPost]
        public ActionResult NewEntity(Entity entity)
        {
            try
            {
                // TODO: Add insert logic here

                _unitOfWork.Entities.Add(entity);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperAdmin/Entity/Edit/5
        public ActionResult EditEntity(int id)
        {
            var entity = _unitOfWork.Entities.Get(id);
            return View(entity);
        }

        // POST: SuperAdmin/Entity/Edit/5
        [HttpPost]
        public ActionResult EditEntity(int id, Entity entity)
        {
            try
            {
                // TODO: Add update logic here
                var dbEntity = _unitOfWork.Entities.Get(id);
                dbEntity.HoilderFirstName = entity.HoilderFirstName;
                dbEntity.HolderLastName = entity.HolderLastName;
                dbEntity.Email = entity.Email;
                dbEntity.EstablishedYear = entity.EstablishedYear;
                dbEntity.RegisteredDate = entity.RegisteredDate;
                dbEntity.HospitalName = entity.HospitalName;
                dbEntity.HospitalContactNumber1 = entity.HospitalContactNumber1;
                dbEntity.HospitalContactNumber2 = entity.HospitalContactNumber2;
                dbEntity.ContactPersonName = entity.ContactPersonName;
                dbEntity.ContactPhoneNumberName = entity.ContactPhoneNumberName;
                dbEntity.Address = entity.Address;
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperAdmin/Entity/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperAdmin/Entity/Delete/5
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
