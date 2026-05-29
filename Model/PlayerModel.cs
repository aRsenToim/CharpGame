using Microsoft.Xna.Framework;
using System;
using System.ComponentModel.Design;

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
        public Vector2 Velocity;

        public float Speed = 350f;
        public float Gravity = 900f;
        public float JumpForce = -600f;
        public int countJump = 0;
        public int maxJump = 2;

        public int Height = 146;
        public int Width = 100;

        public int HP = 1;

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
        }

        public void KillHp()
        {
            if (HP-1 > 0) {
                HP -= 1;
            }else
            {
                OnDeath?.Invoke();
            }
        }

    }
}
