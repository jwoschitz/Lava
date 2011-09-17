﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Lava.Core
{
    public class IEContentManager : ContentManager
    {
        // Do nothing in the constructor except inherit from ContentManager
        public IEContentManager(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        // Whether or not we should keep objects that have been loaded. This
        // way we can avoid loading assets multiple times. However, this may
        // lead to problems with multiple objects changing loaded data, such
        // as effects on a model
        public bool PreserveAssets = true;

        // Keep a list of disposable assets and loaded assets
        List<IDisposable> disposable = new List<IDisposable>();
        Dictionary<string, object> loaded = new Dictionary<string, object>();

        // Override loading of assets so we can use our own functionality
        public override T Load<T>(string assetName)
        {
            // Create a new instance of the requested asset
            T r = this.ReadAsset<T>(assetName, RecordIDisposable);

            // If we are holding on to loaded assets, add it to the list of
            // loaded assets
            if (PreserveAssets && !loaded.ContainsKey(assetName))
                loaded.Add(assetName, r);

            // Return the loaded asset
            return r;
        }

        // Internal method to record disposable assets
        void RecordIDisposable(IDisposable asset)
        {
            // If we are monitoring loaded assets, add it to the list of
            // disposable assets
            if (PreserveAssets)
                disposable.Add(asset);
        }

        // Unload all content
        public override void Unload()
        {
            // Dispose all disposable assets
            foreach (IDisposable disp in disposable)
                disp.Dispose();

            // Clear all loaded assets
            loaded.Clear();
            disposable.Clear();
        }

        // Unload a specific piece of content
        public void Unload(string assetName)
        {
            // If the asset has been loaded
            if (loaded.ContainsKey(assetName))
            {
                // If it is disposable, dispose it and take it off the
                // list of disposable content
                if (loaded[assetName] is IDisposable
                        && disposable.Contains((IDisposable)loaded[assetName]))
                {
                    IDisposable obj = disposable[
                        disposable.IndexOf((IDisposable)loaded[assetName])];

                    obj.Dispose();

                    disposable.Remove(obj);
                }

                // Take it off the list of loaded content
                loaded.Remove(assetName);
            }
        }
    }
}
