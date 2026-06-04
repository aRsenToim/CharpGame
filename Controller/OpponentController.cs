using BattleFroggy.Model;
using BattleFroggy.Model.Opponents;
using Microsoft.Xna.Framework;

namespace BattleFroggy.Controller
{
    internal class OpponentController
    {
        private readonly IOpponentModel _opponent;
        private ArenaModel _arenaModel;
        private PlayerModel _player;
        private float _throwInterval = 0.8f;
        private int _throwCount = 0;
        private float bulletSpeed = 500f;

        private int _screenWidth;
        private int _screenHeight;

        public OpponentController(IOpponentModel opponent, PlayerModel player, ArenaModel arenaModel, int screenWidth, int screenHeight)
        {
            _opponent = opponent;
            _player = player;
            _arenaModel = arenaModel;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _opponent.ThrowCooldown = 1f;
        }

        private Vector2 GetSpawnPosition()
        {
            return new Vector2(
                _opponent.Position.X + _opponent.Width / 2f,
                _opponent.Position.Y + _opponent.Height / 4f
            );
        }

        private Vector2 GetDirectionToPlayer()
        {
            Vector2 direction = _player.Position - _opponent.Position;
            if (direction != Vector2.Zero)
                direction.Normalize();
            return direction;
        }

        public void Update(float deltaTime)
        {
            _opponent.ThrowCooldown -= deltaTime;
            if (_opponent.ThrowCooldown <= 0f)
            {
                _throwCount++;
                if(_throwCount % 15 == 0) _opponent.Attacks.GetAttack(2).Execute(bulletSpeed, GetSpawnPosition(), GetDirectionToPlayer(), _arenaModel.Oranges, 500f, _screenWidth, _screenHeight);
                _opponent.ThrowCooldown = _throwInterval;
            }

            UpdateOranges(deltaTime);
        }

        private void UpdateOranges(float deltaTime)
        {
            foreach (var orange in _arenaModel.Oranges)
            {
                if (!orange.IsActive) continue;

                orange.Position += orange.Velocity * deltaTime;
                orange.Bounds = orange.Hitbox;

                if (orange.Position.X < 0 || orange.Position.X > _screenWidth ||
                    orange.Position.Y < 0 || orange.Position.Y > _screenHeight)
                {
                    orange.IsActive = false;
                }
            }

            _arenaModel.RemoveAllOranges();
        }
    }
}