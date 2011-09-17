using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Lava.Core
{
    public class Input
    {
        //TODO Singleton
        public MouseInput Mouse { get; private set; }
        public KeyboardInput Keyboard { get; private set; }

        public Input()
        {
            Mouse = new MouseInput();
            Keyboard = new KeyboardInput();
        }

        //public void Initialize()
        //{
        //    Mouse = new MouseInput();
        //    Keyboard = new KeyboardInput();
        //}

        public void Update(GameTime gameTime)
        {
            Mouse.Update(gameTime);
            Keyboard.Update(gameTime);
        }
    }
}
