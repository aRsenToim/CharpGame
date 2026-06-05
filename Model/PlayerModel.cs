using Microsoft.Xna.Framework;
using System;

namespace BattleFroggy.Model
{
    enum PlayerDirection
    {
        Left,
        Right,
        Default
    }
    internal class PlayerModel
    {
        public event Action OnDeath;


        public Vector2 Position;
        public Vector2 StartPosition;
        public Vector2 Velocity;

        public float Speed = 350f;
        public float Gravity = 900f;
        public float JumpForce = -600f;
        public int countJump = 0;
        public int maxJump = 2;

        public int Height = 146;
        public int Width = 100;

        public int HP = 10;
        public int maxHP = 10;

        public PlayerDirection playerDirection = PlayerDirection.Default;
        
        public bool Ground = false;

        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    Width,
                    Height
                );
            }
        }

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