using Autofac;

namespace NewBlogProject.Data.Extentions
{
    public static class ServiceExtentions
    {
        public static ContainerBuilder RegisterDataLayer(this ContainerBuilder builder)
        {
            builder.RegisterType<BlogContext>();
            return builder;
        }
    }
}
