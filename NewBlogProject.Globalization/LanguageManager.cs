using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace NewBlogProject.Globalization
{
    public class LanguageManager
    {
        public static List<Language> AvailableLanguage = new List<Language> {
            new Language {
                LanguageFullName = "Turkish", LanguageCultureName = "tr"
            },
            new Language {
                LanguageFullName = "English", LanguageCultureName = "en"
            },
        };
        public static bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguage.Where(a => a.LanguageCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }
        public static string GetDefaultLanguage()
        {
            return AvailableLanguage[1].LanguageCultureName;
        }
        public void SetLanguage(string lang)
        {
            try
            {
                if (!IsLanguageAvailable(lang)) lang = GetDefaultLanguage();
                var cultureInfo = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                HttpContext.Current.Response.Cookies.Add(
                    new HttpCookie("culture", lang)
                    {
                        Expires = DateTime.Now.AddDays(1)
                    });
            }
            catch (Exception) { }
        }
    }
}
