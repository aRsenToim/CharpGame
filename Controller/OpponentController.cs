using BattleFroggy.Model;
using BattleFroggy.Model.Opponents;
using Microsoft.Xna.Framework;

namespace BattleFroggy.Controller
{
    internal class OpponentController
    {
        private readonly OpponentRepository _repository;
        private readonly ArenaModel _arenaModel;
        private readonly PlayerModel _player;
        private float _throwInterval = 0.8f;
        private int _throwCount = 0;
        private float _bulletSpeed = 500f;
        private readonly int _screenWidth;
        private readonly int _screenHeight;

        private IOpponentModel Opponent => _repository.Current;

        public OpponentController(OpponentRepository repository, PlayerModel player, ArenaModel arenaModel, int screenWidth, int screenHeight)
        {
            _repository = repository;
            _player = player;
            _arenaModel = arenaModel;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }

        private Vector2 GetSpawnPosition() => new Vector2(
            Opponent.Position.X + Opponent.Width / 2f,
            Opponent.Position.Y + Opponent.Height / 4f);

        private Vector2 GetDirectionToPlayer()
        {
            Vector2 dir = _player.Position - Opponent.Position;
            if (dir != Vector2.Zero) dir.Normalize();
            return dir;
        }

        public void Update(float deltaTime)
        {
            Opponent.ThrowCooldown -= deltaTime;
            if (Opponent.ThrowCooldown <= 0f)
            {
                _throwCount++;
                if (_throwCount % 5 == 0)
                    Opponent.Attacks.GetAttack(2).Execute(_bulletSpeed, GetSpawnPosition(), GetDirectionToPlayer(), _arenaModel.Oranges, 200f, _screenWidth, _screenHeight);
                Opponent.Attacks.GetAttack(1).Execute(_bulletSpeed, GetSpawnPosition(), GetDirectionToPlayer(), _arenaModel.Oranges, 200f, _screenWidth, _screenHeight);
                Opponent.Attacks.GetAttack(0).Execute(_bulletSpeed, GetSpawnPosition(), GetDirectionToPlayer(), _arenaModel.Oranges, 200f, _screenWidth, _screenHeight);
                Opponent.ThrowCooldown = _throwInterval;
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
                    orange.IsActive = false;
            }
            _arenaModel.RemoveAllOranges();
        }
    }
}
