using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace BattleFroggy.Model.AttacksModel
{
    internal class ThrowOrange : IAttack
    {
        public void Execute(float bulletSpeed, Vector2 spawnPosition, Vector2 directionToPlayer, List<OrangeModel> oranges, float FloorY,
            float ScreenWidth, float ScreenHeight)
        {
            oranges.Add(new OrangeModel(spawnPosition, directionToPlayer * bulletSpeed));
        }
    }
}
