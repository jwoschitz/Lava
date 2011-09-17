using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lava.Core
{
    // Represents a 3D object. These objects will be drawn before 
    // 2D objects, and will have modifiers automatically provided 
    // in the editor.
    public interface I3DComponent
    {
        // Position in the Cartesian system (X, Y, Z)
        Vector3 Position { get; set; }

        // Rotation represented as a Vector3. This shouldn't
        // be used for calculations, it is left in so that
        // the rotation can be more easily modified by hand
        Vector3 EulerRotation { get; set; }
        // Rotation as a Matrix. This will give much smoother
        // and cleaner calculations that a Vector3
        Matrix Rotation { get; set; }

        // Scale for each axis (X, Y, Z)
        Vector3 Scale { get; set; }

        // BoundingBox to use for picking and pre-collision
        BoundingBox BoundingBox { get; }
    }

    // Represents a 2D object. These objects will be drawn after
    // 3D objects, and will have modifiers automatically provided
    // in the editor.
    public interface I2DComponent
    {
        Rectangle Rectangle { get; set; }
    }

    public enum ComponentType
    {
        // Represents all 2D components (I2DComponent)
        Component2D,
        // Represents all 3D components (I3DComponent)
        Component3D,
        // Represents all components that are either 2D or 3D
        // components
        Both,
        // Represents all components regardless of type
        All
    }
}
