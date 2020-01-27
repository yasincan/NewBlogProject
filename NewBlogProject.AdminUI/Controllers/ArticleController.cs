using NewBlogProject.Entity.Entity;
using NewBlogProject.Services.Abstract;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewBlogProject.AdminUI.Controllers
{
    public class ArticleController : BaseController
    {
        internal readonly IArticleService _articleService;
        internal readonly ICategoryService _categoryService;
        public ArticleController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var articles = _articleService.Select();
            return View(articles);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            Article article = _articleService.FindById(id);
            return View(article);
        }

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
                ViewBag.Message = "Hiç kategori yok; Makale eklemek için kategori eklenmeli.";
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Text,Description,IsActive,CategoryId")] Article article, HttpPostedFileBase uploadPicture)
        {
            if (ModelState.IsValid)
            {
                _articleService.Insert(article, uploadPicture);
                return RedirectToAction("Index");
            }
            var categories = _categoryService.Select();
            if (categories.Count() > 0)
            {
                ViewData["Categories"] = _categoryService.Select();
            }
            else
            {
                ViewData["Categories"] = null;
                ViewBag.Message = "Hiç kategori yok; Makale eklemek için kategori eklenmeli.";
            }
            return View(article);
        }

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
        public ActionResult Edit(Article article, HttpPostedFileBase uploadPicture)
        {
            if (ModelState.IsValid)
            {
                _articleService.Update(article, uploadPicture);
                return RedirectToAction("Index");
            }
            return View(article);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            Article article = _articleService.FindById(id);
            return View(article);
        }

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