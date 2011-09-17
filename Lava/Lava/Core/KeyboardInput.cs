using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Lava.Core
{
    public class KeyboardInput
    {
        public KeyboardState KeyState { get; private set; }
        public KeyboardState KeyStateLastFrame { get; private set; }

        public KeyboardInput() 
        {
            KeyState = Keyboard.GetState();
        }

        public void Update(GameTime gameTime)
        {
            KeyStateLastFrame = KeyState;
            KeyState = Keyboard.GetState();
        }

        public bool IsKeyState(GameKeyState key)
        {
            switch (key)
            {
                case GameKeyState.Forward:
                    return KeyState.IsKeyDown(Keys.Up) || KeyState.IsKeyDown(Keys.W);
                case GameKeyState.Backward:
                    return KeyState.IsKeyDown(Keys.Down) || KeyState.IsKeyDown(Keys.S);
                case GameKeyState.Right:
                    return KeyState.IsKeyDown(Keys.Right) || KeyState.IsKeyDown(Keys.D);
                case GameKeyState.Left:
                    return KeyState.IsKeyDown(Keys.Left) || KeyState.IsKeyDown(Keys.A);
                case GameKeyState.ToggleCamera:
                    return isNewKeyPress(Keys.C);
                case GameKeyState.ToggleScreen:
                    return isNewKeyPress(Keys.V);
                default:
                    return false;
            }
        }

        private bool isNewKeyPress(Keys key)
        {
            return KeyState.IsKeyDown(key) && KeyStateLastFrame.IsKeyUp(key);
        }
    }

    public enum GameKeyState
    { 
        Forward,
        Backward,
        Right,
        Left,
        ToggleScreen,
        ToggleCamera
    }
}
