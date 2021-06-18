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
    [AreaAuthorize(area: "Admin")]
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
        public ActionResult Doctor(UserDetails userDetails, string dob, HttpPostedFileBase file)
        {
            try
            {
               
                    userDetails.EntityId = (int)Session["entity"];
                    var dt = DateTime.ParseExact(dob, "dd/MM/yyyy", null);
                    dt = Convert.ToDateTime(dt, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
                    userDetails.DateOfBirth = dt;
                    userDetails.CreatedDate = DateTime.Today;
                    userDetails.UpadtedDate = DateTime.Today;
                    userDetails.Password = "admin@123";
                    var roleId = _unitOfWork.Roles.GetRoleIdByRoleName("Doctor");
                    userDetails.RoleID = roleId;
                    userDetails.File = Utilities.ImageUpload.UploadImages(file, userDetails.EntityId, userDetails.FirstName, "User");
                    _unitOfWork.User.Add(userDetails);
                    _unitOfWork.Complete();
                    //saving branches of user
                    foreach (var branchid in userDetails.SelectedBrachesArray)
                    {
                        var branchdetails = new UserBranches
                        {
                            UserId = userDetails.UserId,
                            BranchId = int.Parse(branchid)
                        };
                        _unitOfWork.UserBranches.Add(branchdetails);
                    }
                    _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DoctorManagement/Edit/5
        public ActionResult EditDoctor(int id)
        {
            var userDetail = _unitOfWork.User.Get(id);
            string dob = userDetail.DateOfBirth.ToString("dd/MM/yyyy");
            var userBranchesList = _unitOfWork.UserBranches.Find(x => x.UserId == id);
            string[] branchArray = new string[10];
            var listCount = 0;
            foreach (var item in userBranchesList)
            {
                branchArray[listCount] = item.BranchId.ToString();
                listCount++;
            }
            userDetail.SelectedBrachesArray = branchArray;
            var doctorViewModel = new UserViewModel()
            {
                Branches = _unitOfWork.Branch.GetAll(),
                Roles = _unitOfWork.Roles.GetAll(),
                Categories = _unitOfWork.Category.GetAll(),
                SelectedBrachesArray = branchArray,
                UserDetails = userDetail,
                DOB = dob,
                Departments = _unitOfWork.Department.GetAll()

            };
            return View(doctorViewModel);
        }

        // POST: Admin/DoctorManagement/Edit/5
        [HttpPost]
        public ActionResult EditDoctor(int id, UserDetails userDetails, string dob, HttpPostedFileBase file)
        {
            try
            {
                var dbStaff = _unitOfWork.User.Get(id);
                dbStaff.FirstName = userDetails.FirstName;
                dbStaff.LastName = userDetails.LastName;
                dbStaff.DateOfBirth = DateTime.ParseExact(dob, "dd/MM/yyyy", null);
                dbStaff.Email = userDetails.Email;
                dbStaff.TelephoneNumber1 = userDetails.TelephoneNumber1;
                dbStaff.TelephoneNumber2 = userDetails.TelephoneNumber2;
                dbStaff.Gender = userDetails.Gender;
                dbStaff.MartialStatus = userDetails.MartialStatus;
                dbStaff.RoleID = userDetails.RoleID;
                dbStaff.DepartmentId = userDetails.DepartmentId;
                dbStaff.UserType = userDetails.UserType;
                dbStaff.Address1 = userDetails.Address1;
                dbStaff.Address2 = userDetails.Address2;
                dbStaff.Country = userDetails.Country;
                dbStaff.State = userDetails.State;
                dbStaff.City = userDetails.City;
                dbStaff.Pincode = userDetails.Pincode;
                dbStaff.UpadtedDate = DateTime.Today;
                dbStaff.Specialisation = userDetails.Specialisation;
                dbStaff.Experience = userDetails.Experience;
                dbStaff.Languages = userDetails.Languages;
                dbStaff.Certification = userDetails.Certification;
                dbStaff.AwardsRecognition = userDetails.AwardsRecognition;
                dbStaff.Membership = userDetails.Membership;
                dbStaff.Registration = userDetails.Registration;
                dbStaff.ConsultationFee = userDetails.ConsultationFee;
                if (file != null)
                {
                    userDetails.File = Utilities.ImageUpload.UploadImages(file, userDetails.EntityId, userDetails.FirstName, "User");
                }
                _unitOfWork.Complete();
                //adding branches
                var branches = _unitOfWork.UserBranches.GetBranchCount(id);
                _unitOfWork.UserBranches.RemoveRange(branches);
                _unitOfWork.Complete();
                foreach (var branchid in userDetails.SelectedBrachesArray)
                {
                    var branchdetails = new UserBranches
                    {
                        UserId = id,
                        BranchId = int.Parse(branchid)
                    };
                    _unitOfWork.UserBranches.Add(branchdetails);

                }
                _unitOfWork.Complete();

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
