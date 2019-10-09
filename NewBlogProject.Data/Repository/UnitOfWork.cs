using NewBlogProject.Data.Abstract;
using NewBlogProject.Entity.Entity;
using System;

namespace NewBlogProject.Data.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        internal readonly BlogContext _context;

        public UnitOfWork(BlogContext context)
        {
            _context = context;
        }
        public IRepository<T> Repository<T>() where T : ModelBase, new()
        {
            return new Repository<T>(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
