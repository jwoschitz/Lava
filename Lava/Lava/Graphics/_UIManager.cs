//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Microsoft.Xna.Framework;
//using System.Collections.ObjectModel;
//using Microsoft.Xna.Framework.Graphics;

//namespace Nightfall.Graphics
//{
//    public class UIManager : DrawableGameComponent
//    {
//        public Collection<IUIComponent> Components { get; private set; }
//        public List<Sprite> Sprites;
//        private SpriteBatch spriteBatch;

//        public UIManager(Game game)
//            : base(game)
//        {
//            Components = new Collection<IUIComponent>();
//            Sprites = new List<Sprite>();
//            game.Services.AddService(typeof(UIManager), this);
//        }

//        public override void Initialize()
//        {
//            for (var i = 0; i < Components.Count; i++)
//            {
//                Components[i].Initialize();
//            }
//        }

//        protected override void LoadContent()
//        {
//            for (var i = 0; i < Components.Count; i++)
//            {
//                Components[i].LoadContent();
//            }
//        }

//        public override void Update(GameTime gameTime)
//        {
//            for (var i = 0; i < Components.Count; i++)
//            {
//                Components[i].Update(gameTime);
//            }
//        }

//        public override void Draw(GameTime gameTime)
//        {
//            //for (var i = 0; i < Components.Count; i++)
//            //{
//            //    Components[i].Draw(gameTime);
//            //}


//            if (Sprites.Count > 0)
//            {
//                // We can improve a little performance by rendering
//                // the additive stuff at first end!
//                bool startedAdditiveSpriteMode = false;
//                for (int spriteNum = 0; spriteNum < Sprites.Count; spriteNum++)
//                {
//                    var sprite = Sprites[spriteNum];
//                    if (sprite.blendState == BlendState.Additive)
//                    {
//                        if (startedAdditiveSpriteMode == false)
//                        {
//                            startedAdditiveSpriteMode = true;
//                            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.Additive);                            
//                        }
//                        sprite.Render(spriteBatch);
//                    }
//                }

//                if (startedAdditiveSpriteMode)
//                    spriteBatch.End();

//                // Handle all remembered sprites
//                for (int spriteNum = 0; spriteNum < Sprites.Count; spriteNum++)
//                {
//                    var sprite = Sprites[spriteNum];
//                    if (sprite.blendState != BlendState.Additive)
//                    {
//                        spriteBatch.Begin(SpriteSortMode.BackToFront,sprite.blendState);
//                        sprite.Render(spriteBatch);
//                        // Dunno why, but for some reason we have start a new sprite
//                        // for each texture change we have. Else stuff is not rendered
//                        // in the correct order on top of each other.
//                        spriteBatch.End();
//                    }
//                }
//                Sprites.Clear();
//            }
//        }
//    }
//}
