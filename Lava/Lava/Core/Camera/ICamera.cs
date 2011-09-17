using Microsoft.Xna.Framework;

namespace Lava.Core
{
    public interface ICamera
    {
        Vector3 Position { get; set; }
        Vector3 Forward { get; }
        Vector3 UpVector { get; }

        Matrix ViewMatrix { get; }
        Matrix ProjectionMatrix { get; }

        Rotation Rotation { get; }

        void Initialize();
        void Update();        
    }
}
