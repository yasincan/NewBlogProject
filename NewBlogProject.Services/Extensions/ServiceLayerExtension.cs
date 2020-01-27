using Autofac;
using NewBlogProject.Data.Abstract;
using NewBlogProject.Data.Repository;
using NewBlogProject.Services.Abstract;
using NewBlogProject.Services.Concrete;

namespace NewBlogProject.Services.Extensions
{
    public static class ServiceLayerExtension
    {
        public static ContainerBuilder RegisterServiceLayer(this ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<FileUploadManager>().As<IFileUploadManager>();
            builder.RegisterType<CacheService>().As<ICacheService>();
            builder.RegisterType<CaptchaService>().As<ICaptchaService>();
            builder.RegisterType<TwitterService>().As<ITwitterService>();
            builder.RegisterType<MailService>().As<IMailService>();
            builder.RegisterType<ArticleService>().As<IArticleService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
           
           // builder.RegisterType<ServiceBase>().As<IServiceBase();
            return builder;
        }
    }
}
