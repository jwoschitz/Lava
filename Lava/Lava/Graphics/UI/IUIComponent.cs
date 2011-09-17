using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Lava.Graphics
{
    public interface IUIComponent
    {
        List<Sprite> GetSpritesToDraw();
        void Initialize();
        void LoadContent();
        void Update(GameTime gameTime);
    }
}
