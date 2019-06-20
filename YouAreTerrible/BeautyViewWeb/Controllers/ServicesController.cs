using BeautyServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyViewWeb.Controllers
{
    public class ServicesController : Controller
    {
        public IServiceService service = Globals.ServiceService;
        public ActionResult Index()
        {
            return View(service.GetList());
        }

        //public ActionResult Delete(int id)
        //{
        //    service.DelElement(id);
        //    return RedirectToAction("Index");
        //}
    }
}