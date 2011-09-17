using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lava.Core
{
    public class CameraManager : Component
    {
        private CameraType currentCameraType;

        public CameraSettings Settings { get; private set; }
        public ICamera Camera { get; private set; }
        public CameraType CameraType { get { return currentCameraType; } }

        public Input Input { get; private set; }
        public Viewport Viewport { get; private set; }

        public CameraManager(GameScreen parent)
            : this(parent, CameraType.FreeCamera, new CameraSettings())
        { }

        public CameraManager(GameScreen parent, CameraType cameraType)
            : this(parent, cameraType, new CameraSettings())
        { }

        public CameraManager(GameScreen parent, CameraType cameraType, CameraSettings settings)
            : base(parent)
        {            
            Settings = settings;
            Engine.Services.RegisterService(typeof(CameraManager), this);
            Viewport = Engine.GraphicsDevice.Viewport;
            Input = (Input)Engine.Services.GetService(typeof(Input));
            SetCamera(cameraType);
        }

        public override void Update()
        {
            Camera.Update();
        }

        public void SetCamera(CameraType cameraType, CameraSettings settings)
        {
            Settings = settings;
            SetCamera(cameraType);
        }

        public void SetCamera(CameraType cameraType)
        {
            switch (cameraType)
            {
                case CameraType.FreeCamera:
                    Camera = new FreeCamera(this, Settings);                    
                    break;
                case CameraType.StaticCamera:
                    Camera = new StaticCamera(this, Settings);
                    break;
                case CameraType.TestCamera:
                    Camera = new TestCamera(this, Settings);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(SystemResources.InvalidCameraType);
            }
            currentCameraType = cameraType;
            Camera.Initialize();
        }
    }

    public enum CameraType
    {
        FreeCamera,
        StaticCamera,
        TestCamera
    }
}
