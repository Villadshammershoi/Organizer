using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizer.Controllers
{
    public class UploadController : Controller
    {
        [HttpPost]
        public ActionResult Index(List<HttpPostedFileBase> files, string folderName)
        {
            DataContext _db = new DataContext();

            
            foreach (var file in files) 
            {
                if (file != null && file.ContentLength > 0)
                {
                    string path = Server.MapPath("~/Files/" + folderName);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    
                    file.SaveAs(Path.Combine(path,file.FileName));

                    string format = Path.GetExtension(file.FileName);
                    string filePath = path + "/" + file.FileName;

                    Images model = new Images();
                    model.Name = file.FileName;
                    model.ContentType = format;
                    
                    _db.Images.Add(model);
                    try
                    {
                        _db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                
            }
            
            return RedirectToAction( "Index", "UploadedFiles");
            
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFolder(string folderName) 
        {
            string folderPath = Server.MapPath("~/Files/" + folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderName);
            }
            return RedirectToAction("Index", "Folder");
        }
    }

    
}