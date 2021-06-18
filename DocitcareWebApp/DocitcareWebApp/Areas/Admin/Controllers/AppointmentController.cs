using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocitcareWebApp.Core;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.ViewModels;

namespace DocitcareWebApp.Areas.Admin.Controllers
{
    [AreaAuthorize(area: "Admin")]
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Appointment
        public ActionResult Index()
        {
            return View();
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

        public JsonResult DoctorInfo(int userId)
        {
            var doctlist = _unitOfWork.User.DoctorSlotDetails(userId);
            var doctorlist = doctlist.GroupBy(x => x.SlotDate).Select(f=>f.First()).ToList();
            return Json(doctorlist, JsonRequestBehavior.AllowGet);
        }

    }
}