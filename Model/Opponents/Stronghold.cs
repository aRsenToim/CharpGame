using BattleFroggy.Model.Attacks;
using BattleFroggy.Model.AttacksModel;
using Microsoft.Xna.Framework;

namespace BattleFroggy.Model.Opponents
{
    internal class Stronghold : IOpponentModel
    {
        public string Name { get; } = "stronghold";
        public Vector2 Position { get; set; }
        public AttackModel Attacks { get; } = new AttackModel();
        public float ThrowCooldown { get; set; } = 0f;
        public int Height { get; } = 350;
        public int Width { get; } = 350;
        public Rectangle Hitbox => new Rectangle(
            (int)Position.X,
            (int)Position.Y,
            Width,
            Height
        );

        public Stronghold(Vector2 startPosition)
        {
            Position = new Vector2(startPosition.X - Width, startPosition.Y);
            Attacks.AddAttack(new ThrowOrange());
            Attacks.AddAttack(new ThrowSuperAttack(5));
            Attacks.AddAttack(new FloorSweep());
        }
    }
}
