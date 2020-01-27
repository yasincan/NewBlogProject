using NewBlogProject.Entity.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace NewBlogProject.Entity.Entity
{
    public class ModelBase : IModelBase
    {
        public Guid Id { get; set; }
        [Display(ResourceType =typeof(Globalization.Resource), Name = "DeletedDate")]

        public DateTime? DeletedDate { get; set; }

        [Display(ResourceType = typeof(Globalization.Resource), Name = "CreatedDate")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}",ApplyFormatInEditMode =true)]
        public DateTime CreatedDate { get; set; }

        [Display(ResourceType = typeof(Globalization.Resource), Name = "UpdatedDate")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode =true)]
        public DateTime? UpdatedDate { get; set; }
    }
}
