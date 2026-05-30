using BattleFroggy.Model;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BattleFroggy.Controller
{
    internal class OpponentController
    {
        private readonly OpponentModel _opponent;
        private ArenaModel _arenaModel;

        private AttackContoroller _attackController;

        private float _throwInterval = 0.8f;
        private float _orangeSpeed = 420f;

        private const int _superDirections = 5;
        private int _throwCount = 0;
        private const int _superEvery = 15;

        private int _screenWidth;
        private int _screenHeight;

        public OpponentController(OpponentModel opponent, PlayerModel player, ArenaModel arenaModel, int screenWidth, int screenHeight)
        {
            _opponent = opponent;
            _arenaModel = arenaModel;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            _attackController = new AttackContoroller(opponent, player, screenWidth, screenHeight, arenaModel.Oranges);
            _opponent.ThrowCooldown = 1f;
        }

        public void Update(float deltaTime)
        {
            _opponent.ThrowCooldown -= deltaTime;
            if (_opponent.ThrowCooldown <= 0f)
            {
                _throwCount++;
                _attackController.TripleAttack(_orangeSpeed);
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