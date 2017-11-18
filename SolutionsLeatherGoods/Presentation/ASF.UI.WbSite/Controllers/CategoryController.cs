using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;


namespace ASF.UI.WbSite.Areas.Categories.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Categories/Category
        public ActionResult Index()
        {
            var CategoryProcess = new Process.CategoryProcess();
            var Lista = CategoryProcess.SelectList();
            return View(Lista);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Entities.Category category)
        {
            var principal = Thread.CurrentPrincipal.Identity.Name;
            var CategoryProcess = new Process.CategoryProcess();
            CategoryProcess.Create(category);

            return RedirectToAction("Index");
        }

        // GET Edit/{id}
        public ActionResult Edit(int id) {

            var categoryprocess = new Process.CategoryProcess();
            var cat = categoryprocess.SelectOne(id);

            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit (Category category)
        {
            var CategoryProcess = new Process.CategoryProcess();
            CategoryProcess.Edit(category);
            return RedirectToAction("Index");
        }

       [HttpGet]
        public ActionResult Delete( int id  )
        {
            var CategoryProcess = new Process.CategoryProcess();
            var categoria=CategoryProcess.SelectOne(id);
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            var CategoryProcess = new Process.CategoryProcess();
            CategoryProcess.Delete(Convert.ToInt32(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details (int id)
        {
            var category = new Category();
            var CategoryProcess = new Process.CategoryProcess();

            category = CategoryProcess.SelectOne(id);
            return View(category);
        }

    }
}