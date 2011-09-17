using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Lava.Graphics
{
    public class BaseUIComponent : IUIComponent
    {
        protected List<Sprite> SpritesToDraw;
        protected UIManager UIManager;
        protected ContentManager Content;

        public BaseUIComponent(UIManager manager)
        {
            UIManager = manager;
            Content = UIManager.Game.Content;
            SpritesToDraw = new List<Sprite>();
        }

        public virtual void Initialize()
        {
            
        }

        public virtual void LoadContent()
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual List<Sprite> GetSpritesToDraw()
        {
            return SpritesToDraw;
        }
    }
}
