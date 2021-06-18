using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocitcareWebApp.Core;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.ViewModels;
using System.Globalization;

namespace DocitcareWebApp.Areas.Admin.Controllers
{
    [AreaAuthorize(area: "Admin")]
    public class SlotCreationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SlotCreationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Admin/SlotCreation
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/SlotCreation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SlotCreation/Create
        public ActionResult NewSlot()
        {
            return View();
        }

        // POST: Admin/SlotCreation/Create
        [HttpPost]
        public ActionResult NewSlot(SlotCreation slotCreation)
        {
            try
            {
                var startDate = Utilities.ConvetDates.SlotCreationConvertStringToDateTimeMMDDYYFormat(slotCreation.StartDate);
                int noOfDays = Utilities.ConvetDates.SlotCreationGetDays(slotCreation.StartDate,slotCreation.EndDate);
                List<TimeSpan> slots;
                for (int i = 0; i <= noOfDays; i++)
                {
                  var checkDay= startDate.AddDays(i);
                    string[] prefferedDaysList = slotCreation.PrefferedDays[0].Split(',');
                    if (prefferedDaysList.Length > 0 && prefferedDaysList.Contains(checkDay.DayOfWeek.ToString()))
                    {
                        slots = Utilities.ConvetDates.SlotCreationGetTimeSlots(slotCreation.StartTime, slotCreation.EndTime, slotCreation.Duration);
                        //adding records after getting slots
                        if (slots.Count > 0)
                        {
                            foreach (var slotTime in slots)
                            {
                                SlotCreation createSlots = new SlotCreation();
                                createSlots.SlotDate = checkDay;
                                createSlots.StartTime = slotCreation.StartTime;
                                createSlots.EndTime = slotCreation.EndTime;
                                createSlots.Duration = slotCreation.Duration;
                                createSlots.UserType = 0;
                                createSlots.UserId = slotCreation.UserId;
                                createSlots.BranchId = slotCreation.BranchId;
                                createSlots.Available = true;
                                createSlots.Leave = false;
                                createSlots.Block = false;
                                createSlots.SlotTime = slotTime;
                                createSlots.StartDate = slotCreation.StartDate.ToString();
                                createSlots.EndDate = slotCreation.EndDate.ToString();
                                createSlots.StaffId = (int)Session["staffid"];
                                _unitOfWork.SlotCreation.Add(createSlots);
                                _unitOfWork.Complete();
                            }
                            
                        }
                    }

                }


                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/SlotCreation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/SlotCreation/Edit/5
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

        // GET: Admin/SlotCreation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/SlotCreation/Delete/5
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
        public JsonResult GetDoctorList()
        {
           var entityId = (int)Session["entity"];
            var result = _unitOfWork.User.DoctorList(entityId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDoctorDeptBranch(int doctorId)
        {
            if (doctorId != 0)
            { 
           
            var doctor = _unitOfWork.User.Find(x => x.UserId == doctorId).SingleOrDefault();
            var dept = _unitOfWork.Department.Find(d => d.DepartmentId == doctor.DepartmentId).SingleOrDefault();
            var doctorBranch = _unitOfWork.UserBranches.GetBranchCount(doctorId);
            List<Branch> lstBranches= new List<Branch>();
            foreach (var branchId in doctorBranch)
            {
                lstBranches.Add(_unitOfWork.Branch.Get(branchId.BranchId));
            }
            var branchVM = new CommonViewModel
            {
                GetBranches =lstBranches,
                UserDepartment = dept
            };
            var result = branchVM;
            return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Redirect("NewSlot");
        }
    }
}
