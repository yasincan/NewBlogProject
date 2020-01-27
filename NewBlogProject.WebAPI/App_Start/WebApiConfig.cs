using NewBlogProject.API.Constraints;
using System.Web.Http;
using System.Web.Http.Routing;

namespace NewBlogProject.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API Contraint 
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("lastletter", typeof(LastLetter)); // istenilen kadar constraint eklenebilir
            //TODO: Constraint kullanımı *Route(api/{id:lastleter}) ':' ile istenilen kadar constraint eklenebilir contraints önüne eklenen '?' karakteri optional olabilri ve constraints default parametrede alabilir lastlatter=abc gibi constraints flase döner ise olursa 404 dönüyor
            config.MapHttpAttributeRoutes(constraintResolver);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
