using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Entity.Entity
{
    public class Article : ModelBase
    {
        [Display(Name = "Başlık")]
        public string Title { get; set; }
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
