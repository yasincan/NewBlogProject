using Autofac;
using Autofac.Integration.Mvc;
using NewBlogProject.AdminUI.App_Start;
using NewBlogProject.Data.Extentions;
using NewBlogProject.Services.Abstract;
using NewBlogProject.Services.Concrete;
using NewBlogProject.Services.Extentions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NewBlogProject.AdminUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            builder.RegisterDataLayer();
            builder.RegisterBusinesLayer();
            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<ArticleService>().As<IArticleService>();


            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
