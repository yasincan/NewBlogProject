using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Entity.Abstract
{
    public interface IModelBase
    {
        Guid Id { get; set; }
        DateTime? DeletedDate { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
