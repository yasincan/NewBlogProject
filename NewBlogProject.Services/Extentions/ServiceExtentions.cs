using Autofac;
using NewBlogProject.Data.Abstract;
using NewBlogProject.Data.Repository;
using NewBlogProject.Services.Abstract;
using NewBlogProject.Services.Concrete;

namespace NewBlogProject.Services.Extentions
{
    public static class ServiceExtentions
    {
        public static ContainerBuilder RegisterBusinesLayer(this ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<FileUploadManager>().As<IFileUploadManager>();
            builder.RegisterType<CacheService>().As<ICacheService>();
            builder.RegisterType<CaptchaService>().As<ICaptchaService>();
            builder.RegisterType<TwitterService>().As<ITwitterService>();
            builder.RegisterType<MailService>().As<IMailService>();
            return builder;
        }
    }
}
