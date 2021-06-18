using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.ViewModels;
using System.Globalization;
using DocitcareWebApp.Core;

namespace DocitcareWebApp.Areas.Admin.Controllers
{
    [AreaAuthorize(area: "Admin")]
    public class ReceptionistController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReceptionistController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Receptionist/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Receptionist/Create
        public ActionResult BookAppointment()
        {
            return View();
        }

        // POST: Admin/Receptionist/Create
        [HttpPost]
        public ActionResult BookAppointment(SlotBooking slotBooking, UserDetails userDetails,int branchId)
        {
            try
            {
                slotBooking.BookingDate = DateTime.Today;
                slotBooking.StaffId = (int)Session["staffid"];
                if (slotBooking.UserId > 0)
                {
                    slotBooking.FollowUp = false;
                    _unitOfWork.SlotBooking.Add(slotBooking);
                    _unitOfWork.Complete();
                    var dbSlotCreation = _unitOfWork.SlotCreation.Find(x => x.SlotId == slotBooking.SlotId).SingleOrDefault();
                    dbSlotCreation.Available = false;
                    _unitOfWork.Complete();

                }
                else
                {
                    if (userDetails != null)
                    {
                        var userId = 0;
                       var roleId= _unitOfWork.Roles.GetRoleIdByRoleName("Patient");
                        userDetails.RoleID = roleId;
                        var dt = Convert.ToDateTime(userDetails.DateOfBirth, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                        userDetails.DateOfBirth = dt;
                        userDetails.CreatedDate = DateTime.Today;
                        userDetails.UpadtedDate = DateTime.Today;
                        userDetails.EntityId= (int)Session["entity"];
                        _unitOfWork.User.Add(userDetails);
                        _unitOfWork.Complete();
                        userId = userDetails.UserId;
                        slotBooking.UserId = userId;
                        _unitOfWork.SlotBooking.Add(slotBooking);
                        _unitOfWork.Complete();
                        var dbSlotCreation = _unitOfWork.SlotCreation.Find(x => x.SlotId == slotBooking.SlotId).SingleOrDefault();
                        dbSlotCreation.Available = false;
                        _unitOfWork.Complete();
                        var branch = new UserBranches { UserId = userId, BranchId = branchId };
                        _unitOfWork.UserBranches.Add(branch);
                        _unitOfWork.Complete();


                    }

                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)

            {
                return View();
            }
        }

        // GET: Admin/Receptionist/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Receptionist/Edit/5
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

        // GET: Admin/Receptionist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Receptionist/Delete/5
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

        [HttpGet]
        public JsonResult LoggerUserBranches()
        {
            var entityId = (int)Session["staffid"];
            var result = _unitOfWork.UserBranches.GetUserBranchesName(entityId);
            var departmentList = _unitOfWork.Department.GetAll();
            var appointmentVM = new CommonViewModel()
            {
                LoggedUserBranch = result,
                TotalDepartment = departmentList
        };
            return Json(appointmentVM, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDepartmentDoctor(int departmentId)
        {
            var doctorList = _unitOfWork.User.DepartmentDoctor(departmentId);
            return Json(doctorList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ShowSlots(int userID,int appointType, string selectedDate,int branchId)
        {
            var convertedDate =  DateTime.ParseExact(selectedDate, "dd/MM/yyyy", null);
            var slots = _unitOfWork.SlotCreation.GetSlots(userID,appointType, convertedDate,branchId);
            return Json(slots, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPatient(string Prefix)
        {
            var roleId = _unitOfWork.Roles.GetRoleIdByRoleName("Patient");
            var userDetails = _unitOfWork.User.GetUserDetails(Prefix, roleId);
            return Json(userDetails, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FillPatient(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                int userid = Convert.ToInt32(userId);
                var userDetails = _unitOfWork.User.Find(x => x.UserId == userid).SingleOrDefault();
                return Json(userDetails, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
          
        }

    }
}
