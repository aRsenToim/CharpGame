using Microsoft.Xna.Framework;
using System;

namespace BattleFroggy.Model
{
    enum PlayerDirection { Left, Right, Default }

    internal class PlayerModel
    {
        public event Action OnDeath;

        public Vector2 Position;
        public Vector2 Velocity;

        public float Speed { get; } = 350f;
        public float Gravity { get; } = 900f;
        public float JumpForce { get; } = -600f;

        public int countJump { get; set; } = 0;
        public int maxJump { get; } = 2;

        public int Height { get; } = 146;
        public int Width { get; } = 100;

        public int HP { get; private set; } = 10;
        public int maxHP { get; } = 10;

        public PlayerDirection playerDirection { get; set; } = PlayerDirection.Default;
        public bool Ground { get; set; } = false;

        public Vector2 StartPosition { get; }

        public Rectangle Hitbox => new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

        public PlayerModel(Vector2 position)
        {
            Position = position;
            StartPosition = position;
        }

        public void KillHp()
        {
            HP -= 1;
            if (HP <= 0)
            {
                HP = 0;
                OnDeath?.Invoke();
            }
        }

        public void resetPlayer()
        {
            HP = maxHP;
            Position = StartPosition;
            Velocity = Vector2.Zero;
            countJump = 0;
            Ground = false;
        }
    }
}