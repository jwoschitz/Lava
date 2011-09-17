using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Lava.Core
{
    public class MouseInput
    {
        private MouseState mouseState;
        private MouseState originalMouseState;
        private float mouseDifferenceX;
        private float mouseDifferenceY;

        public MouseInput()
        {
            originalMouseState = Mouse.GetState();
        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (mouseState != originalMouseState)
            {
                mouseDifferenceX = mouseState.X - originalMouseState.X;
                mouseDifferenceY = mouseState.Y - originalMouseState.Y;
            }
            else
            {
                mouseDifferenceX = 0;
                mouseDifferenceY = 0;
            }
        }

        public void SetOriginalMouseState(MouseState originalState)
        {
            originalMouseState = originalState;
        }

        public MouseState Current 
        { 
            get { return mouseState; } 
        }
        public MouseState Original 
        { 
            get { return originalMouseState; } 
        }

        public float DifferenceX
        {
            get { return mouseDifferenceX; }
        }

        public float DifferenceY
        {
            get { return mouseDifferenceY; }
        }
    }
}
