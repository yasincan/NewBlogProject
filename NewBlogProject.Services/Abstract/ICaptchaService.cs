using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Services.Abstract
{
    public interface ICaptchaService
    {
        bool Verify(string type, string str);
        void DisplayCaptcha(string type);
    }
}
