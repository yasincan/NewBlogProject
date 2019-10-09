using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Services.Abstract
{
    public interface IMailService
    {
        bool SendMail(string subject, string body);
    }
}
