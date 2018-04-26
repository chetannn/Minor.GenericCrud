using Minor.GenericCRUD.Services;
using System.Web.Mvc;

namespace Minor.GenericCRUD.Controllers
{
    public class CrudController<TModel, TService> : Controller
        where TModel : class
        where TService : ICrudService<TModel>, new()
    {
        TService _service;

        public CrudController()
        {
            _service = new TService();
        }

        public ActionResult Index() => View(_service.GetAll());

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TModel model)
        {
            if (ModelState.IsValid)
            {
                _service.Insert(model);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            return View(_service.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TModel model)
        {
            if (ModelState.IsValid)
            {
                _service.Update(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            TModel model = _service.GetById(id);
            _service.Delete(model);

            return RedirectToAction(nameof(Index));
        }

    }
}