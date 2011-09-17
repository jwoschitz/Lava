using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Lava.Objects;
using Lava.Core;
using Lava.Graphics;

namespace Lava
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BaseGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        private Input input;
        private bool isActive = false;

        public BaseGame()
        {
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Engine.SetupEngine(graphics);
            Engine.Content.RootDirectory = "Content";
            input = new Input();
            Engine.Services.AddService(typeof(Input), input);
            //var screen = new TestScreen()
            //{
            //    BlocksDraw = true,
            //    BlocksInput = true,
            //    BlocksUpdate = true,
            //};
            Engine.GameScreens.Add(new TestScreen()
            {
                BlocksDraw = true,
                BlocksInput = true,
                BlocksUpdate = true,
            });            
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            //var input = (Input)Services.GetService(typeof(Input));
            base.Update(gameTime);
            input.Update(gameTime);
            if (input.Keyboard.IsKeyState(GameKeyState.ToggleScreen))
            {
                if (isActive)
                {
                    Engine.GameScreens.Clear();
                    Engine.GameScreens.Add(new TestScreen()
                    {
                        BlocksDraw = true,
                        BlocksInput = true,
                        BlocksUpdate = true,
                    });   
                    isActive = !isActive;
                }
                else
                {
                    Engine.GameScreens.Clear();
                    Engine.GameScreens.Add(new TestScreen2()
                    {
                        BlocksDraw = true,
                        BlocksInput = true,
                        BlocksUpdate = true,
                    });   
                    isActive = !isActive;
                }
            }
            Engine.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //graphics.GraphicsDevice.Clear(Color.Black);

            //// Drawing sprites changes some render states around, which don't play
            //// nicely with 3d models. 
            //// In particular, we need to enable the depth buffer.
            //DepthStencilState depthStensilState =
            //    new DepthStencilState() { DepthBufferEnable = true };
            //graphics.GraphicsDevice.DepthStencilState = depthStensilState;
            //marble.Draw(gameTime);

            base.Draw(gameTime);
            Engine.Draw(gameTime, ComponentType.All);
        }
    }
}
