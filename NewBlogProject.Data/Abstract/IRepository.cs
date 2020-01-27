using NewBlogProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NewBlogProject.Data.Abstract
{
    public interface IRepository<T> where T : IModelBase
    {
        T FindById(Guid EntityId);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null);
        T Insert(T Entity);
        void Update(T Entity);
        void Delete(Guid EntityId);
        void Delete(T Entity);
    }
}
