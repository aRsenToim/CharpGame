using Microsoft.Xna.Framework;
using MonoGame.Framework.Devices.Sensors;

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
        public Vector2 Position;
        public Vector2 Velocity;

        public float Speed = 350f;
        public float Gravity = 900f;
        public float JumpForce = -600f;
        public int countJump = 0;
        public int maxJump = 2;

        public int Height = 146;
        public int Width = 100;

        public int HP = 10;

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
            HP -= 1;
        }

    }
}
