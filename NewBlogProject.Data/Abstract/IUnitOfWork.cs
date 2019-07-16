using NewBlogProject.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Data.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<T> Repository<T>() where T : ModelBase, new();
        int SaveChanges();
    }
}
