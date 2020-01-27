using NewBlogProject.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Web;

namespace NewBlogProject.Services.Abstract
{
    public interface IArticleService
    {
        Article FindById(Guid id);
        IEnumerable<Article> Select();
        Article Insert(Article article, HttpPostedFileBase uploadPicture);
        bool Update(Article article, HttpPostedFileBase uploadPicture);
        bool Delete(Article article);
    }
}
