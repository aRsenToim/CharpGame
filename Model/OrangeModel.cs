using Microsoft.Xna.Framework;

namespace BattleFroggy.Model
{
    internal class OrangeModel : QuadTreeObject
    {
        public Vector2 Position;
        public Vector2 Velocity;

        public int Width = 40;
        public int Height = 40;

        public bool IsActive = true;

        public Rectangle Hitbox => new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

        public OrangeModel(Vector2 position, Vector2 velocity) : base(new Rectangle((int)position.X, (int)position.Y, 40, 40))
        {
            Position = position;
            Velocity = velocity;
        }
        public void UpdateMovement(float deltaTime)
        {
            Position += Velocity * deltaTime;
            Bounds = Hitbox;
        }
    }
}