using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizer.Controllers
{
    public class UploadedFilesController : Controller
    {
         //GET: Files
        public ActionResult Index()
        {

            List<string> files = Directory.GetFiles(Server.MapPath("~/Files/")).ToList();
            List<FileInfo> fileinfo = new List<FileInfo>();
            foreach (string file in files)
            {
                fileinfo.Add(new FileInfo(file));
            }
            return View(fileinfo);
        }

        public ActionResult Delete(string name)
        {
            string path = Server.MapPath("~/Files/" + name);
            FileInfo file = new FileInfo(path);
            file.Delete();

            return RedirectToAction("Index");
        }
    }
}