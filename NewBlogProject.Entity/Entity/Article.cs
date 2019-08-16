using NewBlogProject.Entity.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using NewBlogProject.Globalization;

namespace NewBlogProject.Entity.Entity
{
    public class Article : ModelBase
    {
        [LocalizedDescriptionAttribute("Title", typeof(Globalization.Resource))]
        [Required(ErrorMessageResourceType = typeof(Globalization.Resource), ErrorMessageResourceName = "Required")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Makale")]
        public string Text { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Aktif/Pasif")]
        public bool IsActive { get; set; }
        [Display(Name = "Kategori")]
        public Guid CategoryId { get; set; }
        [Display(Name = "Resim")]
        public Guid? PictureId { get; set; }
        [Display(Name = "Kategori")]
        public virtual Category Category { get; set; }
        public virtual Picture Picture { get; set; }
    }
}
