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
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult PieChart(int pieWidth, int pieHeight)
        {

            var Images = db.Images.GroupBy(p => p.ContentType).ToList();
           
            var pen = new Pen(Color.Red);
            int barWidth = 200;
            int spacing = 100;
            int xPos = 0;
            int barHeightMultiplier = 2;
            int width = (Images.Count() * barWidth) + (Images.Count() * spacing);

            int MaxHeight = 0;

            foreach(var img in Images){
                if(img.Count() > MaxHeight) {
                    MaxHeight = img.Count();
                }
            }
            int height = (MaxHeight * barHeightMultiplier) * 8;

            Bitmap exampleimage = new Bitmap(width, height);
            Graphics GraphicsObject = Graphics.FromImage(exampleimage);

            foreach (var val in Images)
            {
                string fileType = val.FirstOrDefault().ContentType;


                GraphicsObject.FillRectangle(new SolidBrush(Color.Red), new Rectangle()
                {
                    Height = val.Count() * barHeightMultiplier,
                    Width = barWidth,
                    X = xPos + spacing,
                    Y = height - (val.Count() * barHeightMultiplier)
                });

                var measureString = GraphicsObject.MeasureString(fileType, new Font("Arial", 10));


                GraphicsObject.DrawString(fileType, new Font("Arial", 10), new SolidBrush(Color.Black), xPos + (barWidth), height - (val.Count() * barHeightMultiplier), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far });

                xPos += barWidth+spacing;
            }

            MemoryStream ms = new MemoryStream();
            exampleimage.Save(ms, ImageFormat.Png);

            return File(ms.ToArray(), "image/png");
        }
















        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}