using NewBlogProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Entity.Entity
{
    public class ModelBase : IModelBase
    {
        public Guid Id { get; set; }
        [Display(Name = "Silinme Tarihi")]
        public DateTime? DeletedDate { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Güncelleme Tarihi")]
        public DateTime? UpdatedDate { get; set; }
    }
}
