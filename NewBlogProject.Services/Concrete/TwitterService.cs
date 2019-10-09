using NewBlogProject.Models.ResponseModels;
using NewBlogProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NewBlogProject.Services.Concrete
{
    public class TwitterService : ITwitterService, IDisposable
    {
        public async Task<string> TwitterAuthentication(string consumerKey, string consumerSecret, string callBackUrl)
        {
            string redirect = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.twitter.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            TimeSpan timestamp = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            string nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));

            Dictionary<string, string> oauth = new Dictionary<string, string>
            {
                ["oauth_nonce"] = new string(nonce.Where(c => char.IsLetter(c) || char.IsDigit(c)).ToArray()),
                ["oauth_callback"] = callBackUrl,
                ["oauth_signature_method"] = "HMAC-SHA1",
                ["oauth_timestamp"] = Convert.ToInt64(timestamp.TotalSeconds).ToString(),
                ["oauth_consumer_key"] = consumerKey,
                ["oauth_version"] = "1.0"
            };
            string[] parameterCollectionValues = oauth.Select(parameter =>
                Uri.EscapeDataString(parameter.Key) + "=" +
                Uri.EscapeDataString(parameter.Value))
            .OrderBy(kv => kv)
            .ToArray();
            string parameterCollection = string.Join("&", parameterCollectionValues);
            string baseString = "POST";
            baseString += "&";
            baseString += Uri.EscapeDataString(client.BaseAddress + "oauth/request_token");
            baseString += "&";
            baseString += Uri.EscapeDataString(parameterCollection);
            string signingKey = Uri.EscapeDataString(consumerSecret);
            signingKey += "&";
            HMACSHA1 hasher = new HMACSHA1(new ASCIIEncoding().GetBytes(signingKey));
            oauth["oauth_signature"] = Convert.ToBase64String(hasher.ComputeHash(new ASCIIEncoding().GetBytes(baseString)));
            string headerString = "OAuth ";
            string[] headerStringValues = oauth.Select(parameter =>
                    Uri.EscapeDataString(parameter.Key) + "=" + "\"" +
                    Uri.EscapeDataString(parameter.Value) + "\"")
                .ToArray();
            headerString += string.Join(", ", headerStringValues);
            client.DefaultRequestHeaders.Add("Authorization", headerString);
            HttpResponseMessage response = await client.PostAsJsonAsync("oauth/request_token", "");
            var responseString = await response.Content.ReadAsStringAsync();
            redirect = $"{client.BaseAddress}oauth/authorize?{responseString}";
            return redirect;
        }
        public async Task<TwitterUser> TwitterAccessToken(string consumerKey, string oauthToken, string oauthVerifier)
        {
            HttpClient client = new HttpClient();
            var responseString = "";
            client.BaseAddress = new Uri("https://api.twitter.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("oauth_consumer_key",consumerKey),
                      new KeyValuePair<string, string>("oauth_token",oauthToken),
                        new KeyValuePair<string, string>("oauth_verifier",oauthVerifier)
                });
            var result = await client.PostAsync("/oauth/access_token", content);

            responseString = result.Content.ReadAsStringAsync().Result;
            var item = HttpUtility.ParseQueryString(responseString);


            var twitterUser = new TwitterUser
            {
                OauthToken = item["oauth_token"],
                OauthTokenSecret = item["oauth_token_secret"],
                UserId = item["user_id"],
                ScreenName = item["screen_name"]
            };

            return twitterUser;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
