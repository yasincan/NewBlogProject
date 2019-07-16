using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NewBlogProject.WebAPI.Models.ResponseModel
{
    public enum ResponseCode
    {
        [Description("İşlem başarılıdır.")]
        Success = 5000,

        [Description("Lütfen parmetreleri kontrol ediniz.")]
        CheckRquestParameters = 5001,

        [Description("Api hata.")]
        ApiError=5002
    }
}