namespace NewBlogProject.Services.Abstract
{
    public interface ICacheService
    {
        object Get(string key);
        void Set(string key, object data, int cacheTime);
        bool IsExist(string key);
    }
}
