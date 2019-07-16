using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Identity.Models
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext():base("blogContext")
        {

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
