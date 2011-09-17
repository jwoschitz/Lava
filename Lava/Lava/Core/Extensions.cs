using Microsoft.Xna.Framework;

namespace Lava.Core
{
    public static class Extensions
    {
        public static void Add(this GameComponentCollection components, GameComponent item, int updateOrder)
        {
            item.UpdateOrder = updateOrder;
            components.Add(item);
        }
    }
}
