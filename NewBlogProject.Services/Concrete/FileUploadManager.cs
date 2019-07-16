using NewBlogProject.Entity.Entity;
using NewBlogProject.Services.Abstract;
using System;
using System.IO;
using System.Web;

namespace NewBlogProject.Services.Concrete
{
    public class FileUploadManager : IFileUploadManager
    {
        //TODO : upload işlemleri için de kullanılabilir
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
