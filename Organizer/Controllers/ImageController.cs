using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizer.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index(List<HttpPostedFileBase> files)
        {
            return View();
        }
    }
}