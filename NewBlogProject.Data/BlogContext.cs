using NewBlogProject.Entity.Entity;
using System.Data.Entity;

namespace NewBlogProject.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("name=blogContext")
        {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Picture> Pictures { get; set; }
    }
}
