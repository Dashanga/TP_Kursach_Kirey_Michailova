using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.Interfaces;
using BeautyServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyViewWeb.Controllers
{
    public class ApplicationsController : Controller
    {
        private IResourseService resoursesService = Globals.ResourseService;
        private IMainService mainService = Globals.MainService;
        
        public ActionResult Index()
        {
            return View(mainService.GetList());
        }

        public ActionResult Create()
        {
            var resourses = new SelectList(resoursesService.GetList(), "ResourseId", "ResourseName");
            ViewBag.Resourses = resourses;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            var resourseId = int.Parse(Request["ResourseId"]);
            var resourseCount = int.Parse(Request["Count"]);
            var totalCost = CalcSum(resourseId, resourseCount);

            mainService.CreateApplication(new ApplicationBindingModel
            {
                ResourseId = resourseId,
                Count = resourseCount,
                Summa = totalCost

            });
            return RedirectToAction("Index");
        }

        private Decimal CalcSum(int resourseId, int resourseCount)
        {
            ResourseViewModel resourse = resoursesService.GetElement(resourseId);
            return resourseCount * resourse.ResoursePrice;
        }

        public ActionResult SetStatus(int id, string status)
        {
            try
            {
                switch (status)
                {
                    case "Отправлена":
                        mainService.SendApplication(new ApplicationBindingModel {ApplicationId = id});
                        break;
                    case "Выполнена":
                        mainService.FinishApplication(new ApplicationBindingModel {ApplicationId = id});
                        break;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}