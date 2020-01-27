using NewBlogProject.Entity.Entity;
using System;
using System.Collections.Generic;

namespace NewBlogProject.Services.Abstract
{
    public interface ICategoryService
    {
        Category FindById(Guid id);
        IEnumerable<Category> Select();
        Category Insert(Category category);
        bool Update(Category category);
        bool Delete(Category category);
    }
}
