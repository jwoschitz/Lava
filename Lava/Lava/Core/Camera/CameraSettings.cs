using Microsoft.Xna.Framework;

namespace Lava.Core
{
    public class CameraSettings
    {
        private Rotation rotation;

        #region Properties
        public Vector3 Position { get; set; }

        public Rotation Rotation 
        {
            get
            {
                if (rotation == null)
                {
                    rotation = new Rotation();
                }
                return rotation;
            }
            set 
            { 
                rotation = value; 
            }
        }

        public float NearPlane { get; set; }
        public float FarPlane { get; set; }
        public float RotationSpeed { get; set; }
        public float MoveSpeed { get; set; }
        #endregion

        public CameraSettings() : this(new Vector3(300, 0, 0), 45.0f, 0.0f)
        { }

        public CameraSettings(Vector3 startPosition)
        {
            Position = startPosition;
            NearPlane = 0.5f;
            FarPlane = 1000.0f;
            RotationSpeed = 0.005f;
            MoveSpeed = 10.0f;
        }

        public CameraSettings(Vector3 startPosition, float horizontalRotation, float verticalRotation) : this(startPosition)
        {
            Rotation = new Rotation(horizontalRotation, verticalRotation);
        }
    }
}
