using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Lava.Core
{
    public static class Engine
    {
        // The GraphicsDevice the engine is using
        public static GraphicsDevice GraphicsDevice;

        // The Engine's SpriteBatch
        public static SpriteBatch SpriteBatch;

        // The collection of GameScreens we are managinng
        public static GameScreenCollection GameScreens = new GameScreenCollection();

        // The current GameTime
        public static GameTime GameTime;

        // Whether the Engine has been initialized yet
        public static bool IsInitialized = false;

        // The engine's service container
        public static IEServiceContainer Services;

        // The engine's content manager
        public static IEContentManager Content;

        // GameScreen provided by the engine.
        public static GameScreen BackgroundScreen;       

        // The GameScreen to set to new GameScreens when a screen is not specified
        public static GameScreen DefaultScreen;

        // Initializes the engine
        public static void SetupEngine(IGraphicsDeviceService GraphicsDeviceService)
        {
            // Setup the GraphicsDevice and SpriteBatch
            Engine.GraphicsDevice = GraphicsDeviceService.GraphicsDevice;
            Engine.SpriteBatch = new SpriteBatch(GraphicsDeviceService.GraphicsDevice);

            Engine.IsInitialized = true;

            // Setup the service container and add the IGraphicsDeviceService to it
            Engine.Services = new IEServiceContainer();
            Engine.Services.AddService(typeof(IGraphicsDeviceService), GraphicsDeviceService);

            // Setup the content manager using the service container
            Engine.Content = new IEContentManager(Services);            

            BackgroundScreen = new GameScreen("Engine.BackgroundScreen");
            BackgroundScreen.OverrideUpdateBlocked = true;
            BackgroundScreen.OverrideDrawBlocked = true;
            BackgroundScreen.OverrideInputBlocked = true;

            // Set the default screen to the background screen so new screens will
            // use it automatically unless told otherwise
            DefaultScreen = BackgroundScreen;
        }

        // Update the engine, screens, and components
        public static void Update(GameTime gameTime)
        {
            // Update the game time
            Engine.GameTime = gameTime;

            // Create a temporary list
            List<GameScreen> updating = new List<GameScreen>();

            // Populate the temp list
            foreach (GameScreen screen in GameScreens)
            {
                updating.Add(screen);
            }

            // BlocksUpdate and OverrideUpdateBlocked login
            for (int i = GameScreens.Count - 1; i >= 0; i--)
                if (GameScreens[i].BlocksUpdate)
                {
                    if (i > 0)
                        for (int j = i - 1; j >= 0; j--)
                            if (!GameScreens[j].OverrideUpdateBlocked)
                                updating.Remove(GameScreens[j]);

                    break;
                }

            // Update remaining components
            foreach (GameScreen screen in updating)
                if (screen.Initialized)
                    screen.Update();

            // Clear list
            updating.Clear();

            // Repopulate list
            foreach (GameScreen screen in GameScreens)
                updating.Add(screen);

            // BlocksInput and OverrideInputBlocked login
            for (int i = GameScreens.Count - 1; i >= 0; i--)
                if (GameScreens[i].BlocksInput)
                {
                    if (i > 0)
                        for (int j = i - 1; j >= 0; j--)
                            if (!GameScreens[j].OverrideInputBlocked)
                                updating.Remove(GameScreens[j]);

                    break;
                }

            // Set IsInputAllowed for all GameScreens
            foreach (GameScreen screen in GameScreens)
                if (!screen.InputDisabled)
                    screen.IsInputAllowed = updating.Contains(screen);
                else
                    screen.IsInputAllowed = false;
        }

        // ComponentType to render
        public static void Draw(GameTime gameTime, ComponentType RenderType)
        {
            // Update the time, create a temp list
            Engine.GameTime = gameTime;
            List<GameScreen> drawing = new List<GameScreen>();

            // Clear the back buffer
            GraphicsDevice.Clear(Color.Black);

            // Populate the temp list if the screen is visible
            foreach (GameScreen screen in GameScreens)
                if (screen.Visible)
                    drawing.Add(screen);

            // BlocksDraw and OverrideDrawBlocked logic
            for (int i = GameScreens.Count - 1; i >= 0; i--)
                if (GameScreens[i].BlocksDraw)
                {
                    if (i > 0)
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (!GameScreens[j].OverrideDrawBlocked)
                                drawing.Remove(GameScreens[j]);
                        }

                    break;
                }

            // Draw the remaining screens
            foreach (GameScreen screen in drawing)
                if (screen.Initialized)
                    screen.Draw(RenderType);
        }
    }
}
