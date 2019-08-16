using NewBlogProject.Entity.Entity;
using NewBlogProject.Services.Abstract;
using NewBlogProject.WebAPI.Attributes;
using NewBlogProject.WebAPI.Models.ResponseModel;
using PagedList;
using System;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace NewBlogProject.WebAPI.Controllers
{
    [ApiExceptionFilter]
    public class ArticleController : ApiController
    {
        internal readonly IArticleService _articleService;
        //internal readonly ICacheService _cacheService;

        public ArticleController(IArticleService articleService/*, ICacheService cacheService*/)
        {
            _articleService = articleService;
            //_cacheService = cacheService;
        }

        [HttpGet]
        [ResponseType(typeof(ResponseModel<IPagedList<Article>>))]
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
                Data = data ?? null,
                ResponseCode= ResponseCode.Success
            };

           // _cacheService.Set(cacheKey, response, 20);

            return Json(data);

        }

        [HttpGet]
        [ResponseType(typeof(ResponseModel<Article>))]
        public object ArticleById(Guid id)
        {
            var data = _articleService.FindById(id);
            var response = new ResponseModel<Article>()
            {
                Data = data ?? null,
                ResponseCode = ResponseCode.Success
            };
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