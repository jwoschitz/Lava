#region File Description
//-----------------------------------------------------------------------------
// DrawableComponent3D.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statments
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;
using Lava.Core;
#endregion

namespace Lava.Objects
{
    public abstract class DrawableComponent3D : Component
    {
        #region Fields
        string modelName;
        protected bool preferPerPixelLighting = false;
        public Model Model = null;
        //public ICamera Camera;
        protected CameraManager CameraManager;

        protected ICamera Camera 
        {
            get { return CameraManager.Camera; }
        }

        public Vector3 Position = Vector3.Zero;
        public Vector3 Rotation = Vector3.Zero;

        public Matrix[] AbsoluteBoneTransforms;
        public Matrix FinalWorldTransforms;
        public Matrix OriginalWorldTransforms = Matrix.Identity;                
        #endregion

        #region Initializations
        public DrawableComponent3D(GameScreen game, string modelName)
            : base(game)
        {
            this.modelName = modelName;
            CameraManager = (CameraManager)Engine.Services.GetService(typeof(CameraManager));
            // Load the model
            Model = Engine.Content.Load<Model>(@"Models\" + modelName);

            // Copy the absolute transforms
            AbsoluteBoneTransforms = new Matrix[Model.Bones.Count];
            Model.CopyAbsoluteBoneTransformsTo(AbsoluteBoneTransforms);
        }

        #endregion Initializations

        //#region Loading
        ///// <summary>
        ///// Load the component content
        ///// </summary>
        //protected override void LoadContent()
        //{


        //    base.LoadContent();
        //}
        //#endregion

        #region Update
        /// <summary>
        /// Update the component
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update()
        {
            // Update the final transformation to properly place the component in the
            // game world.
            UpdateFinalWorldTransform();
        }

        /// <summary>
        /// Default final transformation update.
        /// </summary>
        protected virtual void UpdateFinalWorldTransform()
        {
            FinalWorldTransforms = Matrix.Identity *
                Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z) *
                    OriginalWorldTransforms *
                    Matrix.CreateTranslation(Position);
        }             
        #endregion

        #region Render
        /// <summary>
        /// Draw the component
        /// </summary>
        /// <param name="gameTime">The game time</param>
        public override void Draw()
        {
            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    // Set the effect for drawing the component
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = preferPerPixelLighting;

                    // Apply camera settings
                    effect.Projection = Camera.ProjectionMatrix;
                    effect.View = Camera.ViewMatrix;
                    
                    // Apply necessary transformations
                    effect.World = FinalWorldTransforms;
                }

                // Draw the mesh by the effect that set
                mesh.Draw();
            }
        }
        #endregion
    }
}
