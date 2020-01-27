namespace NewBlogProject.Services.Abstract
{
    public interface ICaptchaService
    {
        bool Verify(string type, string str);
        void DisplayCaptcha(string type);
    }
}
