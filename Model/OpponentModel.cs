using Microsoft.Xna.Framework;

namespace BattleFroggy.Model
{
    internal class OpponentModel
    {

        public Vector2 Position;

        public float ThrowCooldown = 0f;

        public int Height = 335;
        public int Width = 250;
        public Rectangle Hitbox => new Rectangle(
            (int)Position.X,
            (int)Position.Y,
            Width,
            Height
        );

        public OpponentModel(Vector2 startPosition)
        {
            Position = new Vector2(startPosition.X - Width, startPosition.Y);
        }

    }
}
