//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework;

//namespace Nightfall.Graphics
//{
//    public class Sprite
//    {
//        public Texture2D texture;
//        public Rectangle rect;
//        public Rectangle pixelRect;
//        public Color color = Color.White;
//        public float rotation = 0;

//        public Vector2 rotationPoint = Vector2.Zero;
//        public BlendState blendState = BlendState.AlphaBlend;

//        public Sprite(Texture2D texture, Rectangle rectangle, Rectangle pixelRectangle)
//        {
//            this.texture = texture;
//            rect = rectangle;
//            pixelRect = pixelRectangle;
//        }

//        public Sprite(Texture2D texture, Rectangle rectangle,
//            Rectangle pixelRectangle, Color color)
//            : this(texture, rectangle, pixelRectangle)
//        {
//            this.color = color;
//        }

//        public Sprite(Texture2D texture, Rectangle rectangle,
//            Rectangle pixelRectangle, Color color, BlendState blendState)
//            : this(texture, rectangle, pixelRectangle, color)
//        {
//            this.blendState = blendState;
//        }

//        public Sprite(Texture2D texture, Rectangle rectangle,
//            Rectangle pixelRectangle, float rotation, Vector2 rotationPoint)
//            : this(texture, rectangle, pixelRectangle)
//        {
//            this.rotation = rotation;
//            this.rotationPoint = rotationPoint;
//        }

//        public Sprite(Texture2D texture, Rectangle rectangle,
//            Rectangle pixelRectangle, float rotation, Vector2 rotationPoint,
//            Color color) : this(texture, rectangle, pixelRectangle, rotation, rotationPoint)
//        {
//            this.color = color;
//        }

//        public void Render(SpriteBatch uiSprites)
//        {
//            if (texture == null || color.A == 0) return;

//            if (rotation == 0) uiSprites.Draw(texture, rect, pixelRect, color);
//            else
//                uiSprites.Draw(texture, rect, pixelRect, color, rotation,
//                    rotationPoint,
//                    SpriteEffects.None, 0);
//        }
//    }
//}
