using Autofac;
using Autofac.Integration.WebApi;
using NewBlogProject.Data.Extentions;
using NewBlogProject.Services.Abstract;
using NewBlogProject.Services.Concrete;
using NewBlogProject.Services.Extentions;
using NewBlogProject.WebAPI.App_Start;
using System.Reflection;
using System.Web.Http;
using System.Web.Routing;

namespace NewBlogProject.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            
            var builder = new ContainerBuilder();
            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // This will register the required service class object in above snippets.
          
            //builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            //builder.RegisterType<ArticleService>().As<IArticleService>();

            builder.RegisterDataLayer();
            builder.RegisterBusinesLayer();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
 