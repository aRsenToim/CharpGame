using BattleFroggy.Model.Attacks;
using BattleFroggy.Model.AttacksModel;
using Microsoft.Xna.Framework;

namespace BattleFroggy.Model.Opponents
{
    internal class Carolina : IOpponentModel
    {
        public string Name { get; } = "carolina";
        public Vector2 Position { get; set; }
        public AttackModel Attacks { get; } = new AttackModel();
        public float ThrowCooldown { get; set; } = 0f;
        public int Height { get; } = 335;
        public int Width { get; } = 250;
        public Rectangle Hitbox => new Rectangle(
            (int)Position.X,
            (int)Position.Y,
            Width,
            Height
        );

        public Carolina(Vector2 startPosition)
        {
            Position = new Vector2(startPosition.X - Width, startPosition.Y);
            Attacks.AddAttack(new ThrowOrange());
            Attacks.AddAttack(new ThrowSuperAttack(4));
        }
    }
}