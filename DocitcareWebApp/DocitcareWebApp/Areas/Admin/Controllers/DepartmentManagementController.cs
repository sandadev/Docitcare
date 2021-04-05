using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocitcareWebApp.Core.ViewModels;
using DocitcareWebApp.Core;
using DocitcareWebApp.Persistence;
using DocitcareWebApp.Core.Domain;

namespace DocitcareWebApp.Areas.Admin.Controllers
{
    public class DepartmentManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentManagementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Admin/DepartmentManagement
        public ActionResult Index()
        {
            
            List <Department> lstDepartment = new List<Department>();
           var department = _unitOfWork.Department.GetWithStatusBranch();
            foreach (var item in department)
            {
                var dept = new Department();
                dept.DepartmentId = item.DepartmentId;
                dept.DepartmentName = item.DepartmentName;
                dept.StatusID = item.StatusID;
                dept.DepartmentCount = _unitOfWork.DepartmentBranches.GetBranchCount(item.DepartmentId).Count();
                lstDepartment.Add(dept);
            }
            
            return View(lstDepartment);
        }

        // GET: Admin/DepartmentManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/DepartmentManagement/Create
        public ActionResult Department()
        {
            var branches = _unitOfWork.Branch.GetAll();
            var statuses = _unitOfWork.Status.GetAll();
            var departmentViewModel = new DepartmentViewModel
            {
               Branches=branches,
               Statuses=statuses
            };

            return View(departmentViewModel);
        }

        // POST: Admin/DepartmentManagement/Create
        [HttpPost]
        public ActionResult Department(Department department, HttpPostedFileBase file)
        {
            department.EntityId = 2;
            try
            {
                if (file != null)
                {
                    department.File = Utilities.ImageUpload.UploadImages(file, department.EntityId, department.DepartmentName, "Department");
                }
                
                _unitOfWork.Department.Add(department);
                _unitOfWork.Complete();
                //saving brnaches of department
                foreach (var branchid in department.SelectedBrachesArray)
                {
                    var branchdetails = new DepartmentBranches
                    {
                        DepartmentId = department.DepartmentId,
                        BranchId = int.Parse(branchid)
                    };
                    _unitOfWork.DepartmentBranches.Add(branchdetails);
                }
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View();
            }
        }

        // GET: Admin/DepartmentManagement/Edit/5
        public ActionResult EditDepartment(int id)
        {
            var branches = _unitOfWork.Branch.GetAll();
            var statuses = _unitOfWork.Status.GetAll();
            var branchlist = _unitOfWork.DepartmentBranches.Find(x=>x.DepartmentId==id);
            var department = _unitOfWork.Department.Get(id);
            string[] branchArray = new string[10];
            var listCount = 0;
            foreach (var item in branchlist)
            {
                branchArray[listCount] = item.BranchId.ToString();
                listCount++;
            }
            department.SelectedBrachesArray = branchArray;
            var departmentViewModel = new DepartmentViewModel
            {
                Branches = branches,
                Statuses = statuses,
                SelectedBrachesArray = branchArray,
                Department=department
            };
            return View(departmentViewModel);
        }

        // POST: Admin/DepartmentManagement/Edit/5
        [HttpPost]
        public ActionResult EditDepartment(int id, Department department, HttpPostedFileBase file)
        {
            department.EntityId = 2;
            try
            {
                var dbDepartment = _unitOfWork.Department.Get(id);
                dbDepartment.DepartmentName = department.DepartmentName;
                dbDepartment.StatusID = department.StatusID;
                dbDepartment.RequiredPartnerDetails = department.RequiredPartnerDetails;
                if (file != null)
                {
                    department.File = Utilities.ImageUpload.UploadImages(file, department.EntityId, department.DepartmentName, "Department");
                    dbDepartment.File = department.File;
                }
                _unitOfWork.Complete();
                //saving brnaches of department
                var branches = _unitOfWork.DepartmentBranches.GetBranchCount(id);
                _unitOfWork.DepartmentBranches.RemoveRange(branches);
                _unitOfWork.Complete();
                foreach (var branchid in department.SelectedBrachesArray)
                {
                    var branchdetails = new DepartmentBranches
                    {
                        DepartmentId = id,
                        BranchId = int.Parse(branchid)
                    };
                    _unitOfWork.DepartmentBranches.Add(branchdetails);

                }
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DepartmentManagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/DepartmentManagement/Delete/5
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
