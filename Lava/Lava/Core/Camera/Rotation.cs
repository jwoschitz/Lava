namespace Lava.Core
{
    public class Rotation
    {
        public float LeftRight;
        public float UpDown;

        public Rotation() 
        {
            LeftRight = 0.0f;
            UpDown = 0.0f;
        }

        public Rotation(float horizontalRotation, float verticalRotation) 
        {
            LeftRight = horizontalRotation;
            UpDown = verticalRotation;
        }
    }
}
