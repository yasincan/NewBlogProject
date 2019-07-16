using NewBlogProject.WebAPI.Models.ResponseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace NewBlogProject.WebAPI.Attributes
{
    public class ApiExceptionFilter:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
            if (actionExecutedContext.Exception.InnerException==null)
            {
                exceptionMessage = actionExecutedContext.Exception.Message;
            }
            else
            {
                exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
            }

            var responseModel  = new ResponseModel<object>() { ExceptionMessage = $"Hata oluştu.Hata mesajı:{exceptionMessage}", ResponseCode =ResponseCode.ApiError};

            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(JsonConvert.SerializeObject(responseModel)),

            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            response.StatusCode = HttpStatusCode.OK;

            actionExecutedContext.Response = response;
        }
    }
}
