using NewBlogProject.Data.Enums;
using System;
using System.ComponentModel;
using System.Reflection;

namespace NewBlogProject.WebAPI.Models.ResponseModel
{
    public class ResponseModel<T>
    {
        public bool IsSuccess => Data != null;
        public ResponseCode ResponseCode { get; set; }
        public object Data { get; set; }
        public string Message => GetResponseTypeDescription(ResponseCode);
        public string ExceptionMessage { get; set; }

        private string GetResponseTypeDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}