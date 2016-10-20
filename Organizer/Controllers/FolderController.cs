using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizer.Controllers
{
    public class FolderController : Controller
    {
        // GET: Folder
        public ActionResult Index()
        {
            List<string> folders = Directory.GetDirectories(Server.MapPath("~/Files/")).ToList();
            List<DirectoryInfo> folderInfo = new List<DirectoryInfo>();

            foreach (string folder in folders)
            {
                folderInfo.Add(new DirectoryInfo(folder));
            }


            return View(folderInfo);
        }

        public ActionResult Delete(string name)
        {
            string path = Server.MapPath("~/Files/" + name);
            DirectoryInfo folder = new DirectoryInfo(path);
            folder.Delete();

            return RedirectToAction("Index");
        }
    }
}