using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DocitcareWebApp.Utilities
{
    public static class ImageUpload
    {
        public static string UploadImages(HttpPostedFileBase file,int entityId,string branchName,string saveToFolder)
        {
            string path = string.Empty;
            string saveImagePath = string.Empty;
            if (file != null)
            {
                saveImagePath = "/Images/" + saveToFolder + "/" + entityId + "_" + branchName + Path.GetExtension(Path.GetFileName(file.FileName));
                path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/"+ saveToFolder + "/"+entityId+"_"+branchName+Path.GetExtension(Path.GetFileName(file.FileName))));
                file.SaveAs(path);
            }
            return saveImagePath;
        }
    }
}