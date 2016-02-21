using group12web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace group12web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Weather()
        {
            ViewBag.Message = "Weather page";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload.FileName.EndsWith(".csv"))
                    {
                        Stream stream = upload.InputStream;
                        StreamReader read = new StreamReader(stream);

                        List<string> row = new List<string>();
                        Weather weather = new Weather();
                        read.ReadLine();// Read off header

                        while (!read.EndOfStream)
                        {
                            row = read.ReadLine().Split(',').ToList();

                            weather.Station = row[0];
                            weather.Date = DateTime.ParseExact(row[3] + "/" + row[2] + "/" + row[1], "d/M/yyyy", CultureInfo.InvariantCulture); ;
                            weather.Rainfall = decimal.Parse(row[4]);

                            //Add record into DB
                            //dbContext.Weathers.Add(weather);
                            //dbContext.SaveChanges();
                        }
                        ViewBag.csv = "<p>" + row[1] + "</p>";
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View("Index");
        }
    }
}