using NewBlogProject.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Services.Abstract
{
    public interface ITwitterService
    {
      Task<string> TwitterAuthentication(string consumerKey, string consumerSecret, string callBackUrl);
      Task<TwitterUser> TwitterAccessToken(string consumerKey, string oauthToken, string oauthVerifier);
    }
}
