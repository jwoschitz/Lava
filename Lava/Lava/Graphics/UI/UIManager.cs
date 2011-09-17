using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Graphics;

namespace Lava.Graphics
{
    public class UIManager : DrawableGameComponent
    {
        public Collection<IUIComponent> Components { get; private set; }
        public SpriteManager SpriteManager { get; private set; }

        public UIManager(Game game)
            : base(game)
        {
            Components = new Collection<IUIComponent> {
                new DebugOverlay(this)
            };
            game.Services.AddService(typeof(UIManager), this);
        }

        public override void Initialize()
        {
            SpriteManager = (SpriteManager)Game.Services.GetService(typeof(SpriteManager));
            for (var i = 0; i < Components.Count; i++)
            {
                Components[i].Initialize();
            }
        }

        protected override void LoadContent()
        {
            for (var i = 0; i < Components.Count; i++)
            {
                Components[i].LoadContent();
            }
        }

        public override void Update(GameTime gameTime)
        {
            for (var i = 0; i < Components.Count; i++)
            {
                Components[i].Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            for (var i = 0; i < Components.Count; i++)
            {
                var sprites = Components[i].GetSpritesToDraw();
                SpriteManager.Sprites.AddRange(sprites);
            }
        }
    }
}
