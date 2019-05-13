using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyViewWeb.Controllers
{
    public class ResoursesController : Controller
    {
        private IResourseService service = Globals.ResourseService;
        // GET: Ingredients
        public ActionResult Index()
        {
            return View(service.GetList());
        }


        // GET: Ingredients/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreatePost()
        {
            service.AddElement(new ResourseBindingModel
            {
                ResourseName = Request["ResourseName"],
                ResoursePrice = Convert.ToDecimal(Request["ResoursePrice"]),

            });
            return RedirectToAction("Index");
        }


        // GET: Ingredients/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = service.GetElement(id);
            var bindingModel = new ResourseBindingModel
            {
                ResourseId = id,
                ResourseName = viewModel.ResourseName,
                ResoursePrice = viewModel.ResoursePrice
            };
            return View(bindingModel);
        }


        [HttpPost]
        public ActionResult EditPost()
        {
            service.UpdElement(new ResourseBindingModel
            {
                ResourseId = int.Parse(Request["ResourseId"]),
                ResourseName = Request["ResourseName"],
                ResoursePrice = decimal.Parse(Request["ResoursePrice"])
            });
            return RedirectToAction("Index");
        }


        // GET: Ingredients/Delete/5
        public ActionResult Delete(int id)
        {
            service.DelElement(id);
            return RedirectToAction("Index");
        }
    }
}
