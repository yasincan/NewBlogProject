namespace NewBlogProject.Models.ResponseModels
{
    public class TwitterUser
    {
        public string OauthToken { set; get; }
        public string OauthTokenSecret { set; get; }
        public string UserId { set; get; }
        public string ScreenName { set; get; }
    }
}
