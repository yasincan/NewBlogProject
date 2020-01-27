using NewBlogProject.Services.Abstract;
using System.Web.Mvc;

namespace NewBlogProject.AdminUI.Controllers
{
    public class HomeController : BaseController
    {
        //TODO: Test NewBlogProject
        //private readonly ICaptchaService _captchaService;
        //private readonly IMailService _mailService;
        //public HomeController(ICaptchaService captchaService,IMailService mailService)
        //{
        //    _captchaService = captchaService;
        //    _mailService = mailService;
        //}
        public ActionResult Index()
        {
            //_mailService.SendMail("başlık", "içerik yasin");
            //ViewBag.Text = "New Blog Project";
            return View();
        }
        public class Yasin
        {
            public string Name { get; set; }
            public string Captcha { get; set; }
        }
        //[HttpGet]
        //public void Image()
        //{
        //    _captchaService.DisplayCaptcha("login");
        //}

        //[HttpPost]
        //public object SendForm(Yasin yasin)
        //{
        //    if (_captchaService.Verify("login", yasin.Captcha))
        //    {
        //        return "captcha dogru";
        //    }
        //    else
        //    {
        //        return "hata";
        //    }
        //}
    }
}