#region File Description
//-----------------------------------------------------------------------------
// Marble.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Lava.Core;


#endregion

namespace Lava.Objects
{
    class Marble : DrawableComponent3D
    {
        #region Fields/Properties
        Texture2D m_marbleTexture;
        #endregion

        #region Initializtions
        public Marble(GameScreen game)
            : base(game, "marble")
        {
            preferPerPixelLighting = true;
            // Load the texture of the marble
            m_marbleTexture = Engine.Content.Load<Texture2D>(@"Textures\Marble");
        }
        #endregion Initializtions

        //#region Loading
        ///// <summary>
        ///// Load the marble content
        ///// </summary>
        //protected override void LoadContent()
        //{
        //    base.LoadContent();


        //}
        //#endregion

        #region Render
        /// <summary>
        /// Draw the marble
        /// </summary>
        /// <param name="gameTime">The game time</param>
        public override void Draw()
        {            
            var originalSamplerState = GraphicsDevice.SamplerStates[0];

            // Cause the marble's textures to linearly clamp            
            GraphicsDevice.SamplerStates[0] = SamplerState.LinearClamp;

            foreach (var mesh in Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    // Set the effect for drawing the marble
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = preferPerPixelLighting;
                    effect.TextureEnabled = true;
                    effect.Texture = m_marbleTexture;

                    // Apply camera settings
                    effect.Projection = Camera.ProjectionMatrix;
                    effect.View = Camera.ViewMatrix;

                    // Apply necessary transformations
                    effect.World = AbsoluteBoneTransforms[mesh.ParentBone.Index] *
                        FinalWorldTransforms;
                }

                mesh.Draw();
            }

            // Return to the original state
            GraphicsDevice.SamplerStates[0] = originalSamplerState;
        }
        #endregion
    }
}
