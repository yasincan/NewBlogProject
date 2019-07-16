using NewBlogProject.Entity.Entity;
using NewBlogProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewBlogProject.AdminUI.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        public ArticleController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }

        // GET: Articles
        [HttpGet]
        public ActionResult Index()
        {
            var articles = _articleService.Select();
            return View(articles);
            //return Json(new { data },JsonRequestBehavior.AllowGet);
        }

        // GET: Articles/Details/5
        [HttpGet]
        public ActionResult Details(Guid id)
        {
            Article article = _articleService.FindById(id);
            return View(article);
        }

        // GET: Articles/Create
        [HttpGet]
        public ActionResult Create()
        {
            var categories = _categoryService.Select();

            if (categories.Count() > 0)
            {
                ViewData["Categories"] = _categoryService.Select();
            }
            else
            {
                ViewData["Categories"] = null;
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Text,Description,IsActive,CategoryId,DeletedData")] Article article, HttpPostedFileBase uploadPicture)
        {
            if (ModelState.IsValid)
            {
                _articleService.Insert(article, uploadPicture);
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Articles/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            Article article = _articleService.FindById(id);
            ViewData["Categories"] = _categoryService.Select();
            return View(article);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,Description,IsActive,CategoryId")] Article article, HttpPostedFileBase uploadPicture)
        {
            if (ModelState.IsValid)
            {
                _articleService.Update(article, uploadPicture);
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            Article article = _articleService.FindById(id);
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Article article = _articleService.FindById(id);
            _articleService.Delete(article);
            return RedirectToAction("Index");
        }
    }
}