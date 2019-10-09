using Autofac;
using Autofac.Integration.WebApi;
using NewBlogProject.Data.Extentions;
using NewBlogProject.Services.Abstract;
using NewBlogProject.Services.Concrete;
using NewBlogProject.Services.Extentions;
using System.Reflection;
using System.Web.Http;

namespace NewBlogProject.WebAPI
{
    public static class AutofacDependecyBuilder
    {
        public static void DependencyBuilder()
        {
            var builder = new ContainerBuilder();
            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // This will register the required service class object in above snippets.
          
            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<ArticleService>().As<IArticleService>();
            builder.RegisterType<CaptchaService>().As<ICaptchaService>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


        //-----------------------------------------------------------------




            ////  var configuration = GlobalConfiguration.Configuration;

            //var builder = new ContainerBuilder();

            //builder.dep

            //builder.ConfigureWebApi(configuration);

            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            //builder.RegisterType<ArticleService>().As<IArticleService>();

            //var container = builder.Build();
            //var resolver = new AutofacWebApiDependencyResolver(container);
            //configuration.ServiceResolver.SetResolver(resolver);




            //var builder = new ContainerBuilder();
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());



            ////builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();


            //var container = builder.Build();
            //builder.RegisterDataLayer();
            //builder.RegisterBusinesLayer();
            //builder.RegisterType<ArticleService>().As<IArticleService>();
        }
    }
}