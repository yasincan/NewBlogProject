using NewBlogProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Services.Abstract
{
    public interface IServiceBase<T> where T : class, IModelBase
    {
        T FindById(Guid entityId);
        IEnumerable<T> Select();
        T Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
