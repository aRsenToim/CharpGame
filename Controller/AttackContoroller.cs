using BattleFroggy.Model;
using BattleFroggy.Model.Opponents;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace BattleFroggy.Controller
{
    internal class AttackContoroller
    {
        private OpponentModel _modelOpponent;
        private PlayerModel _modelPlayer;

        private int _screenWidth;
        private int _screenHeight;

        public List<OrangeModel> Oranges { get; } = new List<OrangeModel>();  

        public AttackContoroller(OpponentModel Opponent, PlayerModel PlayerModel, int screenWidth, int screenHeight) { 
            _modelOpponent = Opponent;
            _modelPlayer = PlayerModel;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }
        private Vector2 GetSpawnPosition()
        {
            return new Vector2(
                _modelOpponent.Position.X + _modelOpponent.Width / 2f,
                _modelOpponent.Position.Y + _modelOpponent.Height / 4f
            );
        }

        private Vector2 GetDirectionToPlayer(Vector2 from)
        {
            Vector2 direction = _modelPlayer.Position - from;
            if (direction != Vector2.Zero)
                direction.Normalize();
            return direction;
        }
        public void ThrowOrange(float bulletSpeed)
        {
            Vector2 spawnPos =
                GetSpawnPosition();

            Vector2 velocity =
                GetDirectionToPlayer(spawnPos)
                * bulletSpeed;

            Oranges.Add(
                new OrangeModel(
                    spawnPos,
                    velocity
                )
            );
        }
        public void ThrowSuperAttack(float bulletSpeed, int bulletCount)
        {
            Vector2 spawnPos = GetSpawnPosition();
            float Step = (float)((Math.PI) / bulletCount);

            for (int i = 0; i < bulletCount; i++)
            {
                float angle = (float)(Math.PI / 2 + (Step * i));
                Vector2 direction = new Vector2(
                    (float)Math.Cos(angle),
                    (float)Math.Sin(angle)
                );
                Vector2 velocity = direction * bulletSpeed;
                Oranges.Add(new OrangeModel(spawnPos, velocity));
            }
        }
    }
}
