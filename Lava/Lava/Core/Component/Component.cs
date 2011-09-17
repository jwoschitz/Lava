using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lava.Core
{
    public class Component
    {
        // The GameScreen object that owns this component
        public GameScreen Parent;

        // Whether or not this component has been initialized
        public bool Initialized = false;

        // Whether or not the GameScreen that owns the component
        // should draw it
        public bool Visible = true;

        public GraphicsDevice GraphicsDevice
        {
            get { return Engine.GraphicsDevice; }
        }

        // This overloaded constructor allows us to specify the parent
        public Component(GameScreen Parent)
        {
            Initialize(Parent);
        }

        // This overload allows will set the parent to the default
        // GameScreen
        public Component()
        {
            Initialize(Engine.DefaultScreen);
        }

        // This is called by the constructor to initialize the
        // component. This allows us to only have to override this
        // method instead of both constructors
        protected virtual void Initialize(GameScreen Parent)
        {
            // Check if the engine has been initialized before setting
            // up the component, or the Engine will crash when the
            // component tries to add itself to the list.
            if (!Engine.IsInitialized)
                throw new Exception("Engine must be initialized with \"SetupEngine()\""
                    + "before components can be initialized");
            //LoadContent();
            Initialized = true;
        }

        //protected virtual void LoadContent()
        //{ 
        
        //}

        // Updates the component - This is called by the owner
        public virtual void Update()
        {
        }

        // Draws the component - This is called by the owner
        public virtual void Draw()
        {
        }

        // Unregisters the component with its parent
        public virtual void DisableComponent()
        {
            Parent.Components.Remove(this);
        }
    }
}
