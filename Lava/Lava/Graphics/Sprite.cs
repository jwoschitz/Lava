using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lava.Graphics
{
    public class Sprite
    {
        private string text;
        private SpriteFont font;
        private Vector2 position;
        private Color color;
        private SpriteType spriteType;

        public Sprite(SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            this.text = text;
            this.position = position;
            this.color = color;
            this.font = spriteFont;
            spriteType = SpriteType.String;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (spriteType == SpriteType.String)
            {
                spriteBatch.DrawString(font, text, position, color);
            }
        }
    }

    public enum SpriteType
    { 
        String
    }
}
