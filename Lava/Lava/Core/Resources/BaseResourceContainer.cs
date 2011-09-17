using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Globalization;

namespace Lava.Core
{
    public class BaseResourceContainer
    {
        protected static CultureInfo resourceCulture;
        protected static Dictionary<string, ResourceManager> resourceDictionary;

        public CultureInfo Culture
        {
            get { return resourceCulture; }
            set { resourceCulture = value; }
        }

        protected static ResourceManager GetResourceManagerSingleton(string resourceBaseName)
        {
            initializeResourceDictionary();           
            if (!resourceDictionary.ContainsKey(resourceBaseName))
            {
                var resourceManager = new ResourceManager(resourceBaseName, typeof(BaseResourceContainer).Assembly);
                resourceDictionary[resourceBaseName] = resourceManager;
            }
            return resourceDictionary[resourceBaseName];
        }

        private static void initializeResourceDictionary()
        {
            if (object.ReferenceEquals(resourceDictionary, null))
            {
                resourceDictionary = new Dictionary<string, ResourceManager>();
            }
        }
    }
}
