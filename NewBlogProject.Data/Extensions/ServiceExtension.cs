using Autofac;

namespace NewBlogProject.Data.Extensions
{
    public static class DataLayerExtension
    {
        public static ContainerBuilder RegisterDataLayer(this ContainerBuilder builder)
        {
            builder.RegisterType<BlogContext>();
            return builder;
        }
    }
}
