using BattleFroggy.Model;
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

        public List<OrangeModel> Oranges;

        public AttackContoroller(OpponentModel Opponent, PlayerModel PlayerModel, 
            int screenWidth, int screenHeight, List<OrangeModel> orangesList) { 
            _modelOpponent = Opponent;
            _modelPlayer = PlayerModel;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            Oranges = orangesList;
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

        public void CrossAttack(float bulletSpeed)
        {
            Vector2 spawnPos = GetSpawnPosition();
            Vector2[] directions =
            {
                new Vector2(-1,  0),
            };
            foreach (var dir in directions)
                Oranges.Add(new OrangeModel(spawnPos, dir * bulletSpeed));
        }
        public void TripleAttack(float bulletSpeed)
        {
            Vector2 spawnPos = GetSpawnPosition();
            Vector2 mainDir = GetDirectionToPlayer(spawnPos);

            float spreadAngle = 0.7f;
            float[] angles = { -spreadAngle, 0f, spreadAngle };

            foreach (float a in angles)
            {
                Vector2 dir = new Vector2(
                    mainDir.X * (float)Math.Cos(a) - mainDir.Y * (float)Math.Sin(a),
                    mainDir.X * (float)Math.Sin(a) + mainDir.Y * (float)Math.Cos(a)
                );
                Oranges.Add(new OrangeModel(spawnPos, dir * bulletSpeed));
            }
        }
    }
}
