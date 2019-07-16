using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NewBlogProject.Services.Abstract
{
    public interface IFileUploadManager
    {
        void UploadFile(HttpPostedFileBase file, string fileName, string path);
    }
}
