using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.Interfaces;
using BeautyViewWeb;
using System.Web.Mvc;

namespace PizzeriaWebView.Controllers
{
    public class SkladsController : Controller
    {
        private ISkladService service = Globals.SkladService;
        private IResourseService ingredientService = Globals.ResourseService;

        public ActionResult Index()
        {
            return View(service.GetList());
        }

        public ActionResult AddResourse()
        {
            var ingredients = new SelectList(ingredientService.GetList(), "ResourseId", "ResourseName");
            ViewBag.Resourses = ingredients;
            return View();
        }

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreatePost()
        {
            service.AddElement(new SkladBindingModel
            {
                SkladName = Request["SkladName"],
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
