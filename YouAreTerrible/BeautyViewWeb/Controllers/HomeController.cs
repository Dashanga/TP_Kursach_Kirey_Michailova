using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForgeServiceDAL.Interfaces;
using ForgeServiceImplementList.Implementations;

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
            return RedirectToAction("Index", "Ресурсы");
        }

        public ActionResult Pizzas()
        {
            return RedirectToAction("Index", "Услуги");
        }

        public ActionResult PizzaOrders()
        {
            return RedirectToAction("Index", "Заявки");
        }
    }
}