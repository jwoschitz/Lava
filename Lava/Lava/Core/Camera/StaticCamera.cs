using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Lava.Core
{
    public class StaticCamera : BaseCamera
    {
        public StaticCamera(CameraManager manager, CameraSettings settings)
            : base(manager, settings)
        { }

        public override void Update()
        {
            Rotation.LeftRight -= Settings.RotationSpeed * Input.Mouse.DifferenceX;
            Rotation.UpDown -= Settings.RotationSpeed * Input.Mouse.DifferenceY;
            Mouse.SetPosition(Viewport.Width / 2, Viewport.Height / 2);

            base.Update();
        }
    }
}
