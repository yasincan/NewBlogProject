using NewBlogProject.Entity.Entity;
using NewBlogProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewBlogProject.AdminUI.Controllers
{
    public class CategoryController : BaseController
    {
        internal readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            return View(_categoryService.Select());
        }

        // GET: Categories/Details/5
        [HttpGet]
        public ActionResult Details(Guid id)
        {
            Category category = _categoryService.FindById(id);
            return View(category);
        }

        // GET: Categories/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName,Description,DeletedData")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.Id = Guid.NewGuid();
                _categoryService.Insert(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            Category category = _categoryService.FindById(id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName,Description,DeletedData")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            Category category = _categoryService.FindById(id);
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Category category = _categoryService.FindById(id);
            _categoryService.Delete(category);
            return RedirectToAction("Index");
        }
    }
}