using NewBlogProject.Data.Attributes;
using System.ComponentModel;

namespace NewBlogProject.Data.Enums
{
    public enum ResponseCode : int
    {
        [LocalizedDescription(typeof(Globalization.Resource),"Success")]
        Success = 5000,

        [LocalizedDescription(typeof(Globalization.Resource), "CheckRquestParameters")]
        CheckRquestParameters = 5001,

        [LocalizedDescription(typeof(Globalization.Resource), "ApiError")]
        ApiError = 5002
    }
}