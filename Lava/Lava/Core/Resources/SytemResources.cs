using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;

namespace Lava.Core
{
    public class SystemResources : BaseResourceContainer
    {
        private static ResourceManager ResourceManager
        {
            get { return GetResourceManagerSingleton("Nightfall.Resources.Core"); }
        }

        public static string InvalidCameraType
        {
            get { return ResourceManager.GetString("ERROR_InvalidCameraType", resourceCulture); }
        }

        public static string DuplicateServiceProviderType
        {
            get { return ResourceManager.GetString("ERROR_DuplicateServiceProviderType", resourceCulture); }
        }

        public static string InvalidServiceProvider
        {
            get { return ResourceManager.GetString("ERROR_InvalidServiceProvider", resourceCulture); }
        }

        
    }
}
