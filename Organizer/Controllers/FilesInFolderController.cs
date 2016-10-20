using Organizer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizer.Controllers
{
    public class FilesInFolderController : Controller
    {
        // GET: FilesInFolder
        public ActionResult Index(string folder)
        {
            FilesInFolderViewModel model = new FilesInFolderViewModel();

            string folderPath = Server.MapPath("~/files/" + folder);

            if (Directory.Exists(folderPath))
            {
                model.CurrentFolder = folder;
                List<string> files = Directory.GetFiles(folderPath).ToList();
                model.files = new List<FileInfo>();
                foreach (string file in files)
                {
                    model.files.Add(new FileInfo(file));
                }
                return View(model);
            }

            ViewBag.Message = "Der er ingen filer i denne mappe.";
            return View();
        }
    }
}