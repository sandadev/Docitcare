using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocitcareWebApp.Core;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Core.ViewModels;
using DocitcareWebApp.Persistence;
using System.Text;

namespace DocitcareWebApp.Areas.Admin.Controllers
{
    [AreaAuthorize(area: "Admin")]
    public class StaffManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StaffManagementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Admin/StaffManagement
        public ActionResult Index()
        {
            var staffDetails = _unitOfWork.User.GetAll();
            var staffViewModel = new List<StaffListViewModel>();
            var roles = _unitOfWork.Roles.GetAll();
            
            foreach (var staff in staffDetails)
            {
                var user = new StaffListViewModel();
                StringBuilder sb = new StringBuilder();
                var branches = _unitOfWork.UserBranches.Find(x=>x.UserId==staff.UserId);
                
                foreach (var item in branches)
                {
                    var appendingBranches = _unitOfWork.Branch.Get(item.BranchId);
                    //sb.AppendLine(appendingBranches.BranchName);
                    sb.Append(appendingBranches.BranchName+",");
                }
                user.UserId = staff.UserId;
                user.FirstName = staff.FirstName;
                user.LastName = staff.LastName;
                user.Gender = staff.Gender==0?"Male" :"Female";
                var role = roles.FirstOrDefault(x => x.RoleID == staff.RoleID);
                user.Role = role.RoleName;
                user.Branches = sb.ToString();
                if ( !string.IsNullOrEmpty(user.Branches))
                {
                    user.Branches = user.Branches.Remove(user.Branches.Length - 1);
                } 
                staffViewModel.Add(user);
            }
            return View(staffViewModel);
        }

        // GET: Admin/StaffManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/StaffManagement/Create
        public ActionResult Staff()
        {

            var staffViewModel = new UserViewModel()
            {
                Branches = _unitOfWork.Branch.GetAll(),
                Roles = _unitOfWork.Roles.GetAll(),
                Categories = _unitOfWork.Category.GetAll()
            };
            return View(staffViewModel);
        }

        // POST: Admin/StaffManagement/Create
        [HttpPost]
        public ActionResult Staff(UserDetails userDetails)
        {
            try
            {
                userDetails.EntityId = 2;
                userDetails.DepartmentId = 0;
                userDetails.CreatedDate = DateTime.Now;
                userDetails.UpadtedDate = DateTime.Now;
                userDetails.Password = "admin@123";
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
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/StaffManagement/Edit/5
        public ActionResult EditStaff(int id)
        {
            var userDetail = _unitOfWork.User.Get(id);
            var userBranchesList = _unitOfWork.UserBranches.Find(x => x.UserId == id);
            string[] branchArray = new string[10];
            var listCount = 0;
            foreach (var item in userBranchesList)
            {
                branchArray[listCount] = item.BranchId.ToString();
                listCount++;
            }
            userDetail.SelectedBrachesArray = branchArray;
            var staffViewModel = new UserViewModel()
            {
                Branches = _unitOfWork.Branch.GetAll(),
                Roles = _unitOfWork.Roles.GetAll(),
                Categories = _unitOfWork.Category.GetAll(),
                SelectedBrachesArray=branchArray,
                UserDetails=userDetail

            };
            return View(staffViewModel);
        }

        // POST: Admin/StaffManagement/Edit/5
        [HttpPost]
        public ActionResult EditStaff(int id, UserDetails userDetails)
        {
            try
            {
                var dbStaff = _unitOfWork.User.Get(id);
                dbStaff.FirstName = userDetails.FirstName;
                dbStaff.LastName = userDetails.LastName;
                dbStaff.DateOfBirth = userDetails.DateOfBirth;
                dbStaff.Email = userDetails.Email;
                dbStaff.TelephoneNumber1 = userDetails.TelephoneNumber1;
                dbStaff.TelephoneNumber2 = userDetails.TelephoneNumber2;
                dbStaff.Gender = userDetails.Gender;
                dbStaff.MartialStatus = userDetails.MartialStatus;
                dbStaff.RoleID = userDetails.RoleID;
                dbStaff.UserType = userDetails.UserType;
                dbStaff.Address1 = userDetails.Address1;
                dbStaff.Address2 = userDetails.Address2;
                dbStaff.Country = userDetails.Country;
                dbStaff.State = userDetails.State;
                dbStaff.City = userDetails.City;
                dbStaff.Pincode = userDetails.Pincode;
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
