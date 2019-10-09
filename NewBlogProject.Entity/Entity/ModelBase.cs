using NewBlogProject.Entity.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace NewBlogProject.Entity.Entity
{
    public class ModelBase : IModelBase
    {
        public Guid Id { get; set; }
        [Display(Name = "Silinme Tarihi")]

        public DateTime? DeletedDate { get; set; }

        
        [Display(Name = "Oluşturulma Tarihi")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}",ApplyFormatInEditMode =true)]
        public DateTime CreatedDate { get; set; }

 
        [Display(Name = "Güncelleme Tarihi")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode =true)]
        public DateTime? UpdatedDate { get; set; }
    }
}
