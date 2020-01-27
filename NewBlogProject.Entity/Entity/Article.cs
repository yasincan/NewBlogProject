using System;
using System.ComponentModel.DataAnnotations;

namespace NewBlogProject.Entity.Entity
{
    public class Article : ModelBase
    {
        [Display(ResourceType = typeof(Globalization.Resource), Name = "Title")]
        public string Title { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Globalization.Resource), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(Globalization.Resource), Name = "Article")]
        public string Text { get; set; }


        [Display(ResourceType = typeof(Globalization.Resource), Name = "Description")]
        public string Description { get; set; }


        [Display(ResourceType = typeof(Globalization.Resource), Name = "ActivePasive")]
        public bool IsActive { get; set; }

        [Display(ResourceType = typeof(Globalization.Resource), Name = "Category")]
        public Guid CategoryId { get; set; }

        [Display(ResourceType = typeof(Globalization.Resource), Name = "Picture")]
        public Guid? PictureId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Picture Picture { get; set; }
    }
}
