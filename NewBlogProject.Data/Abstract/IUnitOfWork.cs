using NewBlogProject.Entity.Entity;
using System;

namespace NewBlogProject.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : ModelBase, new();
        int SaveChanges();
    }
}
