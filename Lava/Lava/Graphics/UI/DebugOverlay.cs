using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Lava.Graphics
{
    public class DebugOverlay : BaseUIComponent
    {
        private SpriteFont font;

        public DebugOverlay(UIManager uiManager)
            : base(uiManager)
        { }

        public override void LoadContent()
        {            
           font = Content.Load<SpriteFont>("Debug");
        }

        public override void Update(GameTime gameTime)
        {
            if (font == null) font = Content.Load<SpriteFont>("Fonts/Debug");
            SpritesToDraw.Clear();
            SpritesToDraw.Add(new Sprite(font,gameTime.ElapsedGameTime.ToString(), Vector2.Zero, Color.Tomato));
            base.Update(gameTime);
        }
    }
}
