using BattleFroggy.Model;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace BattleFroggy.Controller
{
    internal class OpponentController
    {
        private readonly OpponentModel _opponent;
        private readonly PlayerModel _player;

        public List<OrangeModel> Oranges = new List<OrangeModel>();

        private float _throwInterval = 0.3f;    
        private float _orangeSpeed = 420f;

        private float _superOrangeSpeed = 900f; 
        private const int _superDirections = 5;

        private int _throwCount = 0;
        private const int _superEvery = 15;

        private int _screenWidth;
        private int _screenHeight;

        public OpponentController(OpponentModel opponent, PlayerModel player, int screenWidth, int screenHeight)
        {
            _opponent = opponent;
            _player = player;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;

            _opponent.ThrowCooldown = 1f;
        }

        public void Update(float deltaTime)
        {
            _opponent.ThrowCooldown -= deltaTime;
            if (_opponent.ThrowCooldown <= 0f)
            {
                _throwCount++;

                if (_throwCount % _superEvery == 0)
                    ThrowSuperAttack();
                else
                    ThrowOrange();

                _opponent.ThrowCooldown = _throwInterval;
            }

            foreach (var orange in Oranges)
            {
                if (orange.IsActive)
                {
                    orange.UpdateMovement(deltaTime);

                    if (orange.Position.X < 0 || orange.Position.X > _screenWidth ||
                        orange.Position.Y < 0 || orange.Position.Y > _screenHeight)
                    {
                        orange.IsActive = false;
                    }
                }
            }

            Oranges.RemoveAll(o => !o.IsActive);
        }

        private void ThrowOrange()
        {
            Vector2 spawnPos = GetSpawnPosition();
            Vector2 velocity = GetDirectionToPlayer(spawnPos) * _orangeSpeed;
            Oranges.Add(new OrangeModel(spawnPos, velocity));
        }

        private void ThrowSuperAttack()
        {
            Vector2 spawnPos = GetSpawnPosition();

            
            float Step = (float)((Math.PI) / _superDirections);

            for (int i = 0; i < _superDirections; i++)
            {
                float angle = (float)(Math.PI/2 + (Step * i));
                Vector2 direction = new Vector2(
                    (float)Math.Cos(angle),
                    (float)Math.Sin(angle)
                );
                Vector2 velocity = direction * _superOrangeSpeed;
                Oranges.Add(new OrangeModel(spawnPos, velocity));
            }
        }

        private Vector2 GetSpawnPosition()
        {
            return new Vector2(
                _opponent.Position.X + _opponent.Width / 2f,
                _opponent.Position.Y + _opponent.Height / 4f
            );
        }

        private Vector2 GetDirectionToPlayer(Vector2 from) 
        {
            Vector2 direction = _player.Position - from;
            if (direction != Vector2.Zero)
                direction.Normalize();
            return direction;
        }
    }
}