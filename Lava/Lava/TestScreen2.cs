using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lava.Core;
using Microsoft.Xna.Framework;
using Lava.Objects;

namespace Lava
{
    public class TestScreen2 : GameScreen
    {
        protected CameraManager CameraManager;
        protected Input Input;

        public TestScreen2() : base("Testscreen2")
        {
            Input = (Input)Engine.Services.GetService(typeof(Input));
            this.CameraManager = new CameraManager(this, CameraType.FreeCamera, new CameraSettings(new Vector3(500.0f,0.0f,-300.0f),40.0f,0.0f));
            Components.Add(CameraManager);
            Components.Add(new Marble(this) { Position = Vector3.Zero });
            Components.Add(new Marble(this) { Position = new Vector3(60.0f,0.0f,0.0f) });
        }

        public override void Update()
        {
            base.Update();
            if (Input.Keyboard.IsKeyState(GameKeyState.ToggleCamera))
            {
                if (CameraManager.CameraType == CameraType.FreeCamera)
                {
                    CameraManager.SetCamera(CameraType.TestCamera);
                }
                else
                {
                    CameraManager.SetCamera(CameraType.FreeCamera);
                }
            }
        }
    }
}
