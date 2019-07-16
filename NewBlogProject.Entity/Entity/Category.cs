using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Entity.Entity
{
    public class Category:ModelBase
    {
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
        [Display(Name = "Açıklma")]
        public string Description { get; set; }
    }
}
