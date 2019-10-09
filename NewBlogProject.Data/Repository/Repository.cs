using NewBlogProject.Data.Abstract;
using NewBlogProject.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NewBlogProject.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : ModelBase, new()
    {
        internal readonly BlogContext _context;
        internal readonly DbSet<T> _dbSet;

        public Repository(BlogContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual T FindById(Guid EntityId)
        {
            return _dbSet.Find(EntityId);
        }

        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter != null)
            {
                return _dbSet.Where(Filter);
            }
            return _dbSet.ToList();
        }

        public virtual T Insert(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(Guid entityId)
        {
            T entityToDelete = _dbSet.Find(entityId);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;


        }
    }
}
