using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lava.Core;
using Lava.Objects;
using Microsoft.Xna.Framework;

namespace Lava
{
    public class TestScreen : GameScreen
    {
        public TestScreen() : base("Testscreen")
        {
            Components.Add(new CameraManager(this));
            Components.Add(new Marble(this) { Position = Vector3.Zero });
        }        

        public override void Update()
        {            
            base.Update();
        }

        public override void Draw(ComponentType RenderType)
        {
            base.Draw(RenderType);
        }
    }
}
