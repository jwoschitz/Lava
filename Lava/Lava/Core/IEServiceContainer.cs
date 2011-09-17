using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lava.Core
{
    public class IEServiceContainer : IServiceProvider
    {
        Dictionary<Type, object> services = new Dictionary<Type, object>();

        // Adds a new service
        public void AddService(Type Service, object Provider)
        {
            if (services.ContainsKey(Service))
                throw new ArgumentException(string.Format(SystemResources.DuplicateServiceProviderType, Service.Name));
            this.services.Add(Service, Provider);
        }

        //Replaces the service if the type of the provider is already added or adds a new service
        public void RegisterService(Type Service, object Provider)
        {
            if (services.ContainsKey(Service))
            {
                services.Remove(Service);
            }
            this.services.Add(Service, Provider);
        }

        // Get a service from the service container
        public object GetService(Type Service)
        {
            foreach (Type type in services.Keys)
            {
                if (type == Service) return services[type];
            }
            throw new ArgumentException(string.Format(SystemResources.InvalidServiceProvider, Service.Name));
        }

        // A shortcut way to get a service. The benefit here is that we
        // can specify the type in the brackets and also return the
        // service of that type. For example, instead of
        // "Camera cam = (Camera)Services.GetService(typeof(Camera));",
        // we can use "Camera cam = Services.GetService()"
        public T GetService<T>()
        {
            object result = GetService(typeof(T));

            if (result != null)
                return (T)result;

            return default(T);
        }

        // Removes a service provider from the container
        public void RemoveService(Type Service)
        {
            if (services.ContainsKey(Service))
                services.Remove(Service);
        }

        // Gets whether or not the container has a provider of this type
        public bool ContainsService(Type Service)
        {
            return services.ContainsKey(Service);
        }
    }
}
