using System.Web.Mvc;
using BeautyServiceDAL.BindingModels;
using BeautyServiceDAL.Interfaces;

namespace BeautyViewWeb.Controllers
{
    public class SkladController : Controller
    {
        private ISkladService service = Globals.SkladService;

        public ActionResult List()
        {
            return View(service.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            service.AddElement(new SkladBindingModel
            {
                SkladName = Request["SkladName"]
            });
            return RedirectToAction("List");
        }
        public ActionResult Details(int id)
        {
            return View(service.GetElement(id));
        }

        public ActionResult Edit(int id)
        {
            var viewModel = service.GetElement(id);
            var bindingModel = new SkladBindingModel
            {
                SkladId = id,
                SkladName = viewModel.SkladName
            };
            return View(bindingModel);
        }

        [HttpPost]
        public ActionResult EditPost()
        {
            service.UpdElement(new SkladBindingModel
            {
                SkladId = int.Parse(Request["SkladId"]),
                SkladName = Request["SkladName"]
            });
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            service.DelElement(id);
            return RedirectToAction("List");
        }
    }
}