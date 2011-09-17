using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lava.Graphics
{
    public class SpriteManager : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        public List<Sprite> Sprites { get; set; }        

        public SpriteManager(Game game) : base(game)
        {
            Sprites = new List<Sprite>();            
            game.Services.AddService(typeof(SpriteManager), this);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }

        public override void Initialize()
        { 
        
        }

        public override void Draw(GameTime gameTime)
        {
            initializeSpriteBatch();
            spriteBatch.Begin();
            if (Sprites.Count > 0)
            {
                for (int spriteNum = 0; spriteNum < Sprites.Count; spriteNum++)
                {
                    var sprite = Sprites[spriteNum];
                    sprite.Draw(spriteBatch);
                }
            }
            spriteBatch.End();
            Sprites.Clear();
        }

        private void initializeSpriteBatch()
        {
            if (spriteBatch == null) spriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }

        public void AddSprite(Sprite sprite)
        {
            Sprites.Add(sprite);
        }
    }
}
