using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Services.Abstract
{
    public interface ICacheService
    {
        object Get(string key);
        void Set(string key, object data, int cacheTime);
        bool IsExist(string key);
    }
}
