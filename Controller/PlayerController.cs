using BattleFroggy.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BattleFroggy.Controller
{
    internal class PlayerController
    {
        private readonly PlayerModel _model;

        private KeyboardState _previousKeyboard;
        private int _screenWidth;
        private int _floor;

        public PlayerModel Model => _model;

        public PlayerController(PlayerModel playerModel, int screenWidth, int floor)
        {
            _model = playerModel;
            _screenWidth = screenWidth;
            _floor = floor;
        }

        public void ResolveCollisions(Rectangle opponentHitbox)
        {
            if (_model.Hitbox.Intersects(opponentHitbox))
                _model.Position.X = opponentHitbox.X - _model.Width;
        }

        public void SetPosition(float deltaTime)
        {
            _model.Velocity.Y += _model.Gravity * deltaTime;

            _model.Position += _model.Velocity * deltaTime;

            if (_model.Position.Y + _model.Height >= _floor)
            {
                _model.Position.Y = _floor - _model.Height;
                _model.Velocity.Y = 0;
                _model.Ground = true;
                _model.countJump = 0;
            }
            else
            {
                _model.Ground = false;
            }

            if (_model.Position.X < 0)
                _model.Position.X = 0;

            if (_model.Position.X + _model.Width > _screenWidth)
                _model.Position.X = _screenWidth - _model.Width;
        }

        public void Jump()
        {
            if (_model.countJump < _model.maxJump)
            {
                _model.Velocity.Y = _model.JumpForce;
                _model.Ground = false;
                _model.countJump++;
            }
        }

        public void Update(float deltaTime, KeyboardState keyboardState, Rectangle opponentHitbox)
        {
            _model.Velocity.X = 0;

            ResolveCollisions(opponentHitbox);

            if (keyboardState.IsKeyDown(Keys.A))
            {
                _model.Velocity.X = -_model.Speed;
                if (_model.Ground) _model.playerDirection = PlayerDirection.Left;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                _model.Velocity.X = _model.Speed;
                if (_model.Ground) _model.playerDirection = PlayerDirection.Right;
            }

            if (keyboardState.IsKeyDown(Keys.Space) && _previousKeyboard.IsKeyUp(Keys.Space))
            {
                _model.playerDirection = PlayerDirection.Default;
                Jump();
            }

            _previousKeyboard = keyboardState;
            SetPosition(deltaTime);
        }
    }
}