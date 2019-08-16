using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace NewBlogProject.Entity.Attributes
{

    public class LocalizedDescriptionAttribute:DescriptionAttribute
    {
        internal readonly ResourceManager _resourceManager;
        internal readonly string _resourceKey;
        
        public LocalizedDescriptionAttribute(string resourceKey, Type resoruceType)
        {
            _resourceManager = new ResourceManager(resoruceType);
            _resourceKey = resourceKey;
        }
    }
}
