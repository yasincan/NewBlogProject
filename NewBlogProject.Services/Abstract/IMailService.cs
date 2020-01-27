namespace NewBlogProject.Services.Abstract
{
    public interface IMailService
    {
        bool SendMail(string subject, string body);
    }
}
