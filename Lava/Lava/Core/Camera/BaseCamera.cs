using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Lava.Core
{
    public class BaseCamera : ICamera
    {
        protected Viewport Viewport;
        protected Input Input;
        protected CameraManager CameraManager;
        protected CameraSettings Settings;

        #region Properties

        public Vector3 Position 
        {
            get { return Settings.Position; }
            set { Settings.Position = value; }        
        }

        public Matrix ProjectionMatrix { get; private set; }
        public Matrix ViewMatrix { get; private set; }

        public Rotation Rotation { get { return Settings.Rotation; } }

        public virtual Vector3 Forward
        {
            get
            {
                Matrix cameraRotation = Matrix.CreateRotationX(Rotation.UpDown) * Matrix.CreateRotationY(Rotation.LeftRight);
                Vector3 cameraForward = Vector3.Forward;
                Vector3 cameraRotatedForward = Vector3.Transform(cameraForward, cameraRotation);
                return cameraRotatedForward;
            }
        }

        public virtual Vector3 UpVector
        {
            get
            {
                Matrix cameraRotation = Matrix.CreateRotationX(Rotation.UpDown) * Matrix.CreateRotationY(Rotation.LeftRight);
                Vector3 cameraOriginalSide = new Vector3(1, 0, 0);
                Vector3 cameraRotatedSide = Vector3.Transform(cameraOriginalSide, cameraRotation);
                return cameraRotatedSide;
            }
        }

        #endregion
        
        public BaseCamera(CameraManager manager, CameraSettings settings)
        {
            CameraManager = manager;
            Settings = settings;
        }

        public virtual void Initialize()
        {
            Viewport = CameraManager.Viewport;
            Input = CameraManager.Input;
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(50),
                Viewport.AspectRatio, Settings.NearPlane, Settings.FarPlane);
            UpdateViewMatrix();
            InitializeInput();
        }

        protected virtual void InitializeInput()
        {
            Mouse.SetPosition(Viewport.Width / 2, Viewport.Height / 2);
            Input.Mouse.SetOriginalMouseState(Mouse.GetState());
        }

        public virtual void Update()
        {
            UpdateViewMatrix();
        }

        protected virtual void Translate(float amount, Vector3 direction)
        {
            Position += direction * amount;
        }

        protected virtual void AddToCameraPosition(Vector3 vectorToAdd)
        {
            Matrix cameraRotation = Matrix.CreateRotationX(Rotation.UpDown) * Matrix.CreateRotationY(Rotation.LeftRight);
            Vector3 rotatedVector = Vector3.Transform(vectorToAdd, cameraRotation);
            Position += Settings.MoveSpeed * rotatedVector;
            UpdateViewMatrix();
        }

        protected virtual void UpdateViewMatrix()
        {
            Matrix cameraRotation = Matrix.CreateRotationX(Rotation.UpDown) * Matrix.CreateRotationY(Rotation.LeftRight);

            Vector3 cameraOriginalTarget = Vector3.Forward;
            Vector3 cameraOriginalUpVector = Vector3.Up;

            Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
            Vector3 cameraFinalTarget = Position + cameraRotatedTarget;

            Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);
            Vector3 cameraFinalUpVector = Position + cameraRotatedUpVector;

            ViewMatrix = Matrix.CreateLookAt(Position, cameraFinalTarget, cameraRotatedUpVector);
        }
    }
}
