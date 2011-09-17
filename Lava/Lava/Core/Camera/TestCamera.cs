using Microsoft.Xna.Framework;

namespace Lava.Core
{
    public class TestCamera : BaseCamera
    {
        private int moverCount;
        private bool isIncreasing;

        public TestCamera(CameraManager manager, CameraSettings settings)
            : base(manager, settings)
        {
            moverCount = 0;
            isIncreasing = true;
        }

        public override void Update()
        {
            if (isIncreasing)
            {
                AddToCameraPosition(Vector3.Up);
                moverCount += 1;
            }
            else 
            {
                AddToCameraPosition(Vector3.Down);
                moverCount -= 1;
            }
            if (moverCount >= 10)
            {
                isIncreasing = false;
            }
            if (moverCount <= -10)
            {
                isIncreasing = true;
            }
               
            base.Update();
        }
    }
}
