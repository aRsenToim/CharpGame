using Microsoft.Xna.Framework;


namespace BattleFroggy.Model
{
    public class QuadTreeObject
    {
        public Rectangle Bounds { get; set; }
        public QuadTreeObject(Rectangle bounds)
        {
            Bounds = bounds;
        }
    }
}
