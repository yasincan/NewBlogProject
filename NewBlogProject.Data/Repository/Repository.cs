using NewBlogProject.Data.Abstract;
using NewBlogProject.Entity;
using NewBlogProject.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NewBlogProject.Entity.Abstract;

namespace NewBlogProject.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : ModelBase, new()
    {
        private readonly BlogContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(BlogContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual T FindById(Guid  EntityId)
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

        public virtual void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(Guid EntityId)
        {
            T entityToDelete = _dbSet.Find(EntityId);
            Delete(entityToDelete);
        }

        public virtual void Delete(T Entity)
        {
            _dbSet.Attach(Entity);
            _context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;

            
        }
    }
}
