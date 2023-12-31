﻿using Serilog;
using System.Web.Mvc;

namespace SerilogOwinBug.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Log.Information("Hello from Home Controller");
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
    }
}