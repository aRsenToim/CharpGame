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
        public List<OrangeModel> Oranges;
        private readonly Random _rng = new Random();

        public AttackContoroller(OpponentModel Opponent, PlayerModel PlayerModel, List<OrangeModel> orangesList)
        {
            _modelOpponent = Opponent;
            _modelPlayer = PlayerModel;
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

        // --- Оригинальные атаки ---

        public void ThrowOrange(float bulletSpeed)
        {
            Vector2 spawnPos = GetSpawnPosition();
            Vector2 velocity = GetDirectionToPlayer(spawnPos) * bulletSpeed;
            Oranges.Add(new OrangeModel(spawnPos, velocity));
        }

        public void ThrowSuperAttack(float bulletSpeed, int bulletCount)
        {
            if (bulletCount <= 0) return;
            Vector2 spawnPos = GetSpawnPosition();
            float step = (float)(Math.PI / bulletCount);
            for (int i = 0; i < bulletCount; i++)
            {
                float angle = (float)(Math.PI / 2 + (step * i));
                Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                Oranges.Add(new OrangeModel(spawnPos, direction * bulletSpeed));
            }
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
        public void BoomerangAttack(float bulletSpeed)
        {
            Vector2 spawnPos = GetSpawnPosition();
            float[] speeds = { 0.6f, 1.0f, 1.4f };
            Vector2 mainDir = GetDirectionToPlayer(spawnPos);
            float baseAngle = (float)Math.Atan2(mainDir.Y, mainDir.X);
            for (int i = 0; i < 3; i++)
            {
                float angle = baseAngle - 0.5f + 0.5f * i;
                Vector2 dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                Oranges.Add(new OrangeModel(spawnPos, dir * bulletSpeed * speeds[i]));
            }
        }
        public void SniperBurst(float bulletSpeed)
        {
            Vector2 spawnPos = GetSpawnPosition();
            Vector2 dir = GetDirectionToPlayer(spawnPos);
            float[] multipliers = { 0.5f, 1.0f, 1.5f };
            foreach (float m in multipliers)
                Oranges.Add(new OrangeModel(spawnPos, dir * bulletSpeed * m));
        }
    }
}