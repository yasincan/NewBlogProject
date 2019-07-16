using Autofac;
using Autofac.Integration.Mvc;
using NewBlogProject.Data.Extentions;
using NewBlogProject.Services.Abstract;
using NewBlogProject.Services.Concrete;
using NewBlogProject.Services.Extentions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace NewBlogProject.AdminUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<ArticleService>().As<IArticleService>();

            builder.RegisterDataLayer();
            builder.RegisterBusinesLayer();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
