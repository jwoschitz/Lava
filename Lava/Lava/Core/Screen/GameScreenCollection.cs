using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Lava.Core
{
    public class GameScreenCollection : KeyedCollection<string, GameScreen>
    {
        // Allow us to get a screen by name like so:
        // Engine.GameScreens["ScreenName"]
        protected override string GetKeyForItem(GameScreen item)
        {
            return item.Name;
        }

        protected override void RemoveItem(int index)
        {
            // Get the screen to be removed
            GameScreen screen = Items[index];

            // If this screen is the current default screen, set the
            // default to the background screen
            if (Engine.DefaultScreen == screen)
                Engine.DefaultScreen = Engine.BackgroundScreen;

            base.RemoveItem(index);
        }
    }
}
