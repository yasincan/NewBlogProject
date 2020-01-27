using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Routing;

namespace NewBlogProject.API.Constraints
{
    public class LastLetter : IHttpRouteConstraint
    {
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            string parameterNew = values[parameterName].ToString().ToLower();
            if (parameterNew.EndsWith("rigel") ||parameterNew.EndsWith("yasin"))
               return true;
            return false;
        }
    }
}
