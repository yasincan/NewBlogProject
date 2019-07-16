using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewBlogProject.AdminUI.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            ViewBag.Text = "New Blog Anasayfa";
            return View();
        }
    }
}