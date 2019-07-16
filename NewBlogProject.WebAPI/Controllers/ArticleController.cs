using NewBlogProject.Entity.Entity;
using NewBlogProject.Services.Abstract;
using NewBlogProject.Services.Concrete;
using NewBlogProject.WebAPI.Attributes;
using NewBlogProject.WebAPI.Models;
using NewBlogProject.WebAPI.Models.ResponseModel;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Filters;

namespace NewBlogProject.WebAPI.Controllers
{
    [ApiExceptionFilter]
    public class ArticleController : ApiController
    {
        private readonly IArticleService _articleService;
        private readonly ICacheService _cacheService;

        public ArticleController(IArticleService articleService, ICacheService cacheService)
        {
            _articleService = articleService;
            _cacheService = cacheService;
        }

        //[ResponseType(typeof(Article))] ---->  DEVAM
        [HttpGet]
        public object ListArticles(int? page)
        {
            //string cacheKey = "cache-articles";
            //if (_cacheService.IsExist(cacheKey))
            //{
            //    return _cacheService.Get(cacheKey) as ResponseModel<IPagedList<Article>>;
            //}

            var data = _articleService.Select().ToPagedList(page ?? 1, 5);
            var response = new ResponseModel<IPagedList<Article>>()
            {
                Data = data != null ? data : null,
                ResponseCode= ResponseCode.Success
            };

           // _cacheService.Set(cacheKey, response, 20);

            return Json(response);

        }

        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}