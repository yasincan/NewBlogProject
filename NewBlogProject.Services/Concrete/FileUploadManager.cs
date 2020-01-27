using NewBlogProject.Services.Abstract;
using System.IO;
using System.Web;

namespace NewBlogProject.Services.Concrete
{
    public class FileUploadManager : IFileUploadManager
    {
        /// <summary>
        ///  upload işlemleri için de kullanılabilir
        /// </summary>
        public void UploadFile(HttpPostedFileBase file, string fileName, string path)
        {
            var directoryPath = HttpContext.Current.Server.MapPath(path);
            if (!Directory.Exists(directoryPath)) // Klasör yolu yoksa oluştur
            {
                Directory.CreateDirectory(directoryPath);
            }
            string filePath = Path.Combine(directoryPath, fileName);
            file.SaveAs(filePath);
        }
    }
}
