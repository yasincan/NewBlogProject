using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NewBlogProject.Entity.Entity;

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
