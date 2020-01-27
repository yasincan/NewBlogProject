using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using NewBlogProject.Globalization;

namespace NewBlogProject.WebAPI.Controllers
{
    public class BaseController : ApiController
    {
        //protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        //{
        //    string lang = null;
        //    // HttpCookie langCookie = Request.Cookies["culture"];
        //    var langCookie = 
        //    if (langCookie != null)
        //    {
        //        lang = langCookie.Value;
        //    }
        //    else
        //    {
        //        var userLanguage = Request.UserLanguages;
        //        var userLang = userLanguage != null ? userLanguage[0] : "";
        //        if (userLang != "")
        //        {
        //            lang = userLang;
        //        }
        //        else
        //        {
        //            lang = LanguageManager.GetDefaultLanguage();
        //        }
        //    }
        //    new LanguageManager().SetLanguage(lang);
        //    return base.BeginExecuteCore(callback, state);
    }
}
