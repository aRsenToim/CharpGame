using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace BattleFroggy.Model.AttacksModel
{
    internal class RainAttack : IAttack
    {
        private readonly int _count;
        private readonly Random _rng = new Random();

        public RainAttack(int count = 6) { _count = count; }

        public void Execute(float bulletSpeed, Vector2 spawnPosition, Vector2 directionToPlayer,
            List<OrangeModel> oranges, float FloorY, float ScreenWidth, float ScreenHeight)
        {
            for (int i = 0; i < _count; i++)
            {
                float x = (float)(_rng.NextDouble() * ScreenWidth);
                oranges.Add(new OrangeModel(new Vector2(x, 0), new Vector2(0, bulletSpeed)));
            }
        }
    }
}