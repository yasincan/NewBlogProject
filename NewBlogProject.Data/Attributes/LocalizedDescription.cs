using System;
using System.ComponentModel;
using System.Resources;

namespace NewBlogProject.Data.Attributes
{

    public class LocalizedDescription : DescriptionAttribute
    {
        private readonly ResourceManager _resourceManager;
        private readonly string _resourceKey;

        public LocalizedDescription(Type resoruceType, string resourceKey) 
        { 
            _resourceManager = new ResourceManager(resoruceType);
            _resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                string description = _resourceManager.GetString(_resourceKey);
                return string.IsNullOrWhiteSpace(description) ? string.Format("[[{0}]]", _resourceKey) : description;
            }
        }
    }
}
