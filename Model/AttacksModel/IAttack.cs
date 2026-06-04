using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BattleFroggy.Model.AttacksModel
{
    internal interface IAttack
    {
        void Execute(float bulletSpeed, Vector2 spawnPosition, Vector2 directionToPlayer, List<OrangeModel> oranges, float FloorY,
            float ScreenWidth, float ScreenHeight);
    }
}
