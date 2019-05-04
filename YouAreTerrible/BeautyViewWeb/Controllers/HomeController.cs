using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyViewWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Resourses()
        {
            return RedirectToAction("Index", "Resourses");
        }

        public ActionResult Services()
        {
            return RedirectToAction("Index", "Services");
        }

        public ActionResult Applications()
        {
            return RedirectToAction("Index", "Applications");
        }
    }
}