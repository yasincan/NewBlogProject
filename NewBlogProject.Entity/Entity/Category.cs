using System.ComponentModel.DataAnnotations;

namespace NewBlogProject.Entity.Entity
{
    public class Category : ModelBase
    {
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
        [Display(Name = "Açıklma")]
        public string Description { get; set; }
    }
}
