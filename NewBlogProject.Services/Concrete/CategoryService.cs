using NewBlogProject.Data.Abstract;
using NewBlogProject.Entity.Entity;
using NewBlogProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Delete(Category category)
        {
            category.DeletedDate = DateTime.Now;
            _unitOfWork.Repository<Category>().Delete(category);
            return _unitOfWork.SaveChanges() > 0;
        }

        public Category FindById(Guid id)
        {
            return _unitOfWork.Repository<Category>().FindById(id);
        }

        public Category Insert(Category category)
        {
            category.CreatedDate = DateTime.Now;
            _unitOfWork.Repository<Category>().Insert(category);
            _unitOfWork.SaveChanges();
            return category;
        }

        public IEnumerable<Category> Select()
        {
            return _unitOfWork.Repository<Category>().Select().OrderBy(c=>c.CreatedDate);
        }

        public IEnumerable<Category> ListCategory()
        {
            return _unitOfWork.Repository<Category>().Select();
        }

        public bool Update(Category category)
        {
            category.UpdatedDate = DateTime.Now;
            _unitOfWork.Repository<Category>().Update(category);
            return _unitOfWork.SaveChanges() > 0;
        }
    }
}
