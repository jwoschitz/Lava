using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Lava.Core
{
    // A custom collection for managing components in a GameScreen
    public class ComponentCollection : Collection<Component>
    {
        // The GameScreen to manage components for
        GameScreen owner;

        public ComponentCollection(GameScreen Owner)
        {
            owner = Owner;
        }

        // Override InsertItem so we can set the parent of the
        // component to the owner
        protected override void InsertItem(int index, Component item)
        {
            if (item.Parent != null && item.Parent != owner)
                item.Parent.Components.Remove(item);

            item.Parent = owner;

            base.InsertItem(index, item);
        }

        // Override RemoveItem so we can set the paren of
        // the component to null (no parent)
        protected override void RemoveItem(int index)
        {
            Items[index].Parent = null;

            base.RemoveItem(index);
        }
    }
}
