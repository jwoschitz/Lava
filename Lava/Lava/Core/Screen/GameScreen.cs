using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lava.Core
{
    public class GameScreen
    {
        // Keep track of all the components we need to manage
        public ComponentCollection Components;

        // Whether or not to draw
        public bool Visible = true;

        // Whether or not this screen should block the update of
        // screens below (for pause menus), etc.
        public bool BlocksUpdate = false;

        // Whether or not this screen can override a blocked update
        // from an above screen (for a background screen), etc.
        public bool OverrideUpdateBlocked = false;

        // Same for drawing
        public bool BlocksDraw = false;

        // Same for drawing
        public bool OverrideDrawBlocked = false;

        // Same for input
        public bool BlocksInput = false;

        // Same for input
        public bool OverrideInputBlocked = false;

        // Whether or not we want to block our own input so we can
        // do things like loading screens that will want to accept
        // input at some point, but not at startup
        public bool InputDisabled = false;

        // This is set by the engine to tell us whether or not input
        // is allowed. We can still get input, but we shouldn't. This
        // is useful because a ProcessInput() type of function would
        // make it hard to manage input (because we can't utilize
        // events, etc.)
        public bool IsInputAllowed = true;

        // The name of our component, set in the constructor. This
        // is used by the Engine, because a GameScreen can be accessed
        // by name from Engine.GameScreens[Name].
        public string Name;

        // Fired when the component's Initialize() is finished. This can
        // be hooked for things like asynchronous loading screens
        public event EventHandler OnInitialized;

        // Whether or not the component is initialized. Handles firing of
        // OnInitialized.
        bool inititalized = false;
        public bool Initialized
        {
            get { return inititalized; }
            set
            {
                inititalized = value;
                if (OnInitialized != null)
                {
                    // Fire the OnInitalized event to let other's know we
                    // are done initializing
                    OnInitialized(this, new EventArgs());
                }
            }
        }

        // Constructor takes the name of the component
        public GameScreen(string Name)
        {
            // Setup our component collection
            Components = new ComponentCollection(this);

            // Register with the engine and set our name
            this.Name = Name;

            // Initialize the component
            if (!Initialized)
                Initialize();
        }

        // Overridable function to initialize the GameScreen
        public virtual void Initialize()
        {
            this.Initialized = true;
        }

        // Update the screen and child Components
        public virtual void Update()
        {
            // Create a temporary list so we don't crash if
            // a component is added to the collection while
            // updating
            List<Component> updating = new List<Component>();

            // Populate the temporary list
            foreach (Component c in Components)
                updating.Add(c);

            // Update all components that have been initialized
            foreach (Component Component in updating)
                if (Component.Initialized)
                    Component.Update();
        }

        // Draw the screen and its components. Accepts a ComponentType
        // to tell us what kind of components to draw. Either 2D, 3D, or
        // both. (Useful for drawing a reflection into a render target
        // without 2D components getting in the way)
        public virtual void Draw(ComponentType RenderType)
        {
            // Temporary list
            List<Component> drawing = new List<Component>();

            foreach (Component component in Components)
            {
                if (RenderType == ComponentType.Both)
                {
                    // If the render type is both, we will draw all 2D or
                    // 3D components
                    if (component is I2DComponent || component is I3DComponent)
                        drawing.Add(component);
                }
                else if (RenderType == ComponentType.Component2D)
                {
                    // If the render type is 2D, we will only draw 2D
                    // components
                    if (component is I2DComponent)
                        drawing.Add(component);
                }
                else if (RenderType == ComponentType.Component3D)
                {
                    // If the render type is 2D, we will only draw 3D
                    // components
                    if (component is I3DComponent)
                        drawing.Add(component);
                }
                else
                {
                    // Otherwise, we will draw every component regardless of type
                    drawing.Add(component);
                }
            }

            // Keep a list of components that are 2D so we can draw them on top
            // of the 3D components
            List<Component> defer2D = new List<Component>();

            foreach (Component component in drawing)
                if (component.Visible && component.Initialized)
                {
                    // If the component is visible and is not loading itself..
                    if (component is I2DComponent)
                    {
                        // If it is 2D, wait to draw
                        defer2D.Add(component);
                    }
                    else
                    {
                        // otherwise, draw immediately
                        component.Draw();
                    }
                }

            // Draw 2D components
            foreach (Component component in defer2D)
                component.Draw();
        }

        // Disables the GameScreen
        public virtual void Disable()
        {
            // Clear out our components
            Components.Clear();

            // Unregister from the Engine's list
            Engine.GameScreens.Remove(this);

            // If the engine happens to have this screen set as the default
            // screen, set it to the background screen in the Engine class
            if (Engine.DefaultScreen == this)
                Engine.DefaultScreen = Engine.BackgroundScreen;
        }

        // Override ToString() to return our name
        public override string ToString()
        {
            return Name;
        }
    }
}
