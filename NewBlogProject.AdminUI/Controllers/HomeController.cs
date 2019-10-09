using NewBlogProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewBlogProject.AdminUI.Controllers
{
    public class HomeController : BaseController
    {
        private ICaptchaService _captchaService;
        public HomeController(ICaptchaService captchaService)
        {
            _captchaService = captchaService;
        }
        public ActionResult Index()
        {
            ViewBag.Text = "New Blog Project";
            return View();
        }
        public class yasin{
            public string Name { get; set; }
            public string Captcha { get; set; }
        }
        [HttpGet]
        public void Image()
        {
            _captchaService.DisplayCaptcha("login");
        }
       
        [HttpPost]
        public object SendForm(yasin yasin)
        {
            if(_captchaService.Verify("login", yasin.Captcha))
            {
                return "captcha dogru";
            }
            else
            {
                return "hata";
            }
        }
    }
}