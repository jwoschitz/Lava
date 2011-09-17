using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Lava.Core
{
    public class FreeCamera : BaseCamera
    {
        public FreeCamera(CameraManager manager, CameraSettings settings)
            : base(manager, settings)
        { }

        public override void Update()
        {
            Rotation.LeftRight -= Settings.RotationSpeed * Input.Mouse.DifferenceX;
            Rotation.UpDown -= Settings.RotationSpeed * Input.Mouse.DifferenceY;
            Mouse.SetPosition(Viewport.Width / 2, Viewport.Height / 2);

            if (Input.Keyboard.IsKeyState(GameKeyState.Forward))
                AddToCameraPosition(Vector3.Forward);
            if (Input.Keyboard.IsKeyState(GameKeyState.Backward))
                AddToCameraPosition(Vector3.Backward);
            if (Input.Keyboard.IsKeyState(GameKeyState.Right))
                AddToCameraPosition(Vector3.Right);
            if (Input.Keyboard.IsKeyState(GameKeyState.Left))
                AddToCameraPosition(Vector3.Left);
            
            base.Update();
        }
    }
}
