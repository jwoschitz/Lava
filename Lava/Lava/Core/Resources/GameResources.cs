using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;

namespace Lava.Core
{
    public class GameResources : BaseResourceContainer
    {
        private static ResourceManager ResourceManager
        {
            get { return GetResourceManagerSingleton("Nightfall.Resources.Game"); }
        }

        public static string TestMessage
        {
            get { return ResourceManager.GetString("Testmessage1", resourceCulture); }
        }     
    }
}
