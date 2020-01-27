using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NewBlogProject.Identity.ApplicationManager;
using NewBlogProject.Identity.Models;
using NewBlogProject.Identity.Models.ViewModel;
using NewBlogProject.Models.ResponseModels;
using NewBlogProject.Services.Abstract;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace NewBlogProject.AdminUI.Controllers
{
    public class AccountController : Controller
    {
        internal ApplicationSignInManager _signInManager;
        internal ApplicationUserManager _userManager;
        internal ICaptchaService _captchaService;
        internal ITwitterService _twitterService;

        public AccountController(ICaptchaService captchaService, ITwitterService twitterService)
        {
            _captchaService = captchaService;
            _twitterService = twitterService;
        }
        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private const string XsrfKey = "XsrfId";

        //------------------------------------------------------------------------------------------

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        //------------------------------------------------------------------------------------------

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpGet]
        public void Image()
        {
            _captchaService.DisplayCaptcha("login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [OutputCache(NoStore = true, Location = OutputCacheLocation.None)]

        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    if (_captchaService.Verify("login", model.Captcha))
                    {
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("Captcha", "Doğrulama kodunu hatalı girdiniz");
                        return View();
                    }
                case SignInStatus.LockedOut:
                    return View("Çıkış");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);



                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            return View(model);
        }

        string consumerKey = "consumerKey ";
        string consumerSecret = "consumerSecret ";
        string redirectUrl = "https://localhost:10000/Home/ValidateTwitterAuth";

        public async Task<ActionResult> TwitterAuthentication()
        {
            var url = await _twitterService.TwitterAuthentication(consumerKey, consumerSecret, redirectUrl);
            return Redirect(url);
        }

        public async Task<ActionResult> ValidateTwitterAuth()
        {
            var oauthToken = Request.Params.Get("oauth_token");
            var oauthVerifier = Request.Params.Get("oauth_verifier");

            TwitterUser twitterUser = await _twitterService.TwitterAccessToken(consumerKey, oauthToken, oauthVerifier);
            return RedirectToAction("Index", "Home");
        }

    }
}