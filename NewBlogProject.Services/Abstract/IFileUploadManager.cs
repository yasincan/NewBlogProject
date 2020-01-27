using System.Web;

namespace NewBlogProject.Services.Abstract
{
    public interface IFileUploadManager
    {
        void UploadFile(HttpPostedFileBase file, string fileName, string path);
    }
}
