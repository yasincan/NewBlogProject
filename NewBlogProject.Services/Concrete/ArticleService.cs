using MvcContrib.Pagination;
using NewBlogProject.Data.Abstract;
using NewBlogProject.Entity.Entity;
using NewBlogProject.Services.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace NewBlogProject.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileUploadManager _fileUploadManager;
        public ArticleService(IUnitOfWork unitOfWork, IFileUploadManager fileUploadManager)
        {
            _unitOfWork = unitOfWork;
            _fileUploadManager = fileUploadManager;
        }

        public bool Delete(Article article)
        {
            article.DeletedDate = DateTime.Now;
            _unitOfWork.Repository<Article>().Delete(article);

            if (article.PictureId != null)
            {
                Guid id = article.Picture.Id;
                Picture articlePicture = _unitOfWork.Repository<Picture>().FindById(id);
                articlePicture.DeletedDate = DateTime.Now;
                _unitOfWork.Repository<Picture>().Delete(id);
            }
            return _unitOfWork.SaveChanges() > 0;
        }

        public Article FindById(Guid id)
        {
            return _unitOfWork.Repository<Article>().FindById(id);
        }

        public Article Insert(Article article, HttpPostedFileBase uploadPicture)
        {

            if (uploadPicture != null)
            {
                var fileName = Path.GetFileName(uploadPicture.FileName);
                var newFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(uploadPicture.FileName);
                _fileUploadManager.UploadFile(uploadPicture, newFileName, "~/Images/ArticlePicture");


                article.Picture = new Picture() // Farklı olsun :)
                {
                    Id = Guid.NewGuid(),
                    Path = newFileName,
                    Title = fileName,
                    CreatedDate = DateTime.Now
                };


                _unitOfWork.Repository<Picture>().Insert(article.Picture);
                _unitOfWork.SaveChanges();
                article.PictureId = article.Picture.Id;
            }
            article.Id = Guid.NewGuid();
            article.CreatedDate = DateTime.Now;
            _unitOfWork.Repository<Article>().Insert(article);
            _unitOfWork.SaveChanges();
            return article;
        }

        public IEnumerable<Article> Select()
        {
            var article = _unitOfWork.Repository<Article>().Select().Where(a => a.DeletedDate == null).OrderByDescending(a => a.CreatedDate);
            return article;
        }

        public bool Update(Article article, HttpPostedFileBase uploadPicture)
        {
            Article newArticle = _unitOfWork.Repository<Article>().FindById(article.Id);

            if (uploadPicture != null)
            {
                if (newArticle.PictureId!=null)
                {
                    var id = Guid.Parse(Convert.ToString(newArticle.PictureId));
                    Picture picture = _unitOfWork.Repository<Picture>().FindById(id);

                    if (System.IO.File.Exists(HttpContext.Current.Server.MapPath("~/Images/ArticlePicture/" + picture.Id)))
                    {
                        System.IO.File.Delete(HttpContext.Current.Server.MapPath("~/Images/" + picture.Path));
                    }
                    picture.DeletedDate = DateTime.Now;
                    _unitOfWork.Repository<Picture>().Delete(picture);
                    _unitOfWork.SaveChanges();
                }
              
                    var fileName = Path.GetFileName(uploadPicture.FileName);
                    var newFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(uploadPicture.FileName);
                    _fileUploadManager.UploadFile(uploadPicture, newFileName, "~/Images/ArticlePicture");
                    Picture newPicture = new Picture()
                    {
                        Id = Guid.NewGuid(),
                        Path = newFileName,
                        Title = fileName,
                        CreatedDate = DateTime.Now
                    };
                    _unitOfWork.Repository<Picture>().Insert(newPicture);
                    _unitOfWork.SaveChanges();
                    newArticle.PictureId = newPicture.Id;
            }

            newArticle.UpdatedDate = DateTime.Now;
            newArticle.Text = article.Text;
            newArticle.Title = article.Title;
            newArticle.CategoryId = article.CategoryId;
            newArticle.Description = article.Description;
            newArticle.IsActive = article.IsActive;

            _unitOfWork.Repository<Article>().Update(newArticle);
            return _unitOfWork.SaveChanges() > 0;
        }
    }
}
