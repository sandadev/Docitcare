using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocitcareWebApp.Core;
using DocitcareWebApp.Core.ViewModels;
using DocitcareWebApp.Core.Domain;
using DocitcareWebApp.Persistence;
using System.IO;

namespace DocitcareWebApp.Areas.Admin.Controllers
{
    [AreaAuthorize(area: "Admin")]
    public class BranchManagementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BranchManagementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Admin/BranchManagement
        public ActionResult Index()
        {
            var branches = _unitOfWork.Branch.GetBranchWithStatusCity();
            return View(branches);
        }

        // GET: Admin/BranchManagement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/BranchManagement/Create
        public ActionResult Branch()
        {
            var cities = _unitOfWork.APTSCities.GetAll();
            var branchViewModel = new BranchViewModel
            {
                Cities = cities
            };
            return View(branchViewModel);
        }

        // POST: Admin/BranchManagement/Create
        [HttpPost]
        public ActionResult Branch(Branch branch, HttpPostedFileBase file)
        {
            branch.EntityId = (int)Session["entity"];
            try
            {
                branch.FilePath = Utilities.ImageUpload.UploadImages(file,branch.EntityId,branch.BranchName,"Branch");
                _unitOfWork.Branch.Add(branch);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/BranchManagement/Edit/5
        public ActionResult EditBranch(int id)
        {
            var cities = _unitOfWork.APTSCities.GetAll();
            var branch = _unitOfWork.Branch.Get(id);
            var branchViewModel = new BranchViewModel
            {
                Branch = branch,
                Cities = cities
            };
            return View(branchViewModel);
        }

        // POST: Admin/BranchManagement/Edit/5
        [HttpPost]
        public ActionResult EditBranch(int id,Branch branch, HttpPostedFileBase file)
        {
            try
            {
                var dbBranch = _unitOfWork.Branch.Get(id);
                dbBranch.BranchName = branch.BranchName;
                dbBranch.CityId = branch.CityId;
                dbBranch.StatusID = branch.StatusID;
                if(file!=null)
                {
                    dbBranch.FilePath = Utilities.ImageUpload.UploadImages(file, branch.EntityId, branch.BranchName, "Branch");
                }
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/BranchManagement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/BranchManagement/Delete/5
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
