using BattleFroggy.Model.AttacksModel;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace BattleFroggy.Model.Attacks
{
    internal class ThrowSuperAttack : IAttack
    {
        private readonly int _bulletCount;

        public ThrowSuperAttack(int bulletCount)
        {
            _bulletCount = bulletCount;
        }

        public void Execute(float bulletSpeed, Vector2 spawnPosition, Vector2 directionToPlayer, List<OrangeModel> oranges, float FloorY,
            float ScreenWidth, float ScreenHeight)
        {
            float step = (float)(Math.PI / _bulletCount);
            for (int i = 0; i < _bulletCount; i++)
            {
                float angle = (float)(Math.PI / 2 + (step * i));
                Vector2 direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                oranges.Add(new OrangeModel(spawnPosition, direction * bulletSpeed));
            }
        }
    }
}