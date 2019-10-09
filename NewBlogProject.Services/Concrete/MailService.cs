using NewBlogProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Services.Concrete
{
    public class MailService : IMailService, IDisposable
    {
        string mailToListForAppSettings = ConfigurationManager.AppSettings["newblogproject:form:mail:to"];
        string mailCCListForAppSettings = ConfigurationManager.AppSettings["newblogproject:form:mail:cc"];

    public bool SendMail(string subject, string body)
        {
            string fromMail = string.Empty,
            host = string.Empty,
            user = string.Empty,
            password = string.Empty;
            int port = 0;

            SmtpSection mailSettings = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            if (mailSettings != null)
            {
                fromMail = mailSettings.From;
                host = mailSettings.Network.Host;
                port = mailSettings.Network.Port;
                user = mailSettings.Network.UserName;
                password = mailSettings.Network.Password;
            }

            List<string> toList = mailToListForAppSettings.Trim().Split(',').ToList();
            List<string> ccList = !string.IsNullOrWhiteSpace(mailCCListForAppSettings) && !string.IsNullOrEmpty(mailCCListForAppSettings)
                ? mailCCListForAppSettings.Trim().Split(',').ToList()
                : null;

            MailMessage mail = new MailMessage();

            toList.ForEach(mm => mail.To.Add(mm));

            if (ccList != null)
            {
                if (ccList.Count > 0 && !ccList.Any(p => string.IsNullOrEmpty(p.Trim())))
                    ccList.ForEach(mm => mail.CC.Add(mm.Trim()));
            }

            mail.Subject = subject;
            mail.From = new MailAddress("yasin@yasin.com");
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            //smtp.Credentials = new System.Net.NetworkCredential(user, password);
            //smtp.Port = port;
            //smtp.Host = host;
            //smtp.EnableSsl = true; //SSL varmı yokmu
            bool result = true;

            try
            {
                smtp.Send(mail);
                result = true;
            }
            catch (SmtpException ex)
            {
                result = false;
            }

            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
