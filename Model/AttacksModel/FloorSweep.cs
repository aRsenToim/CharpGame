using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFroggy.Model.AttacksModel
{
    internal class FloorSweep: IAttack
    {
        public void Execute(float bulletSpeed, Vector2 spawnPosition, Vector2 directionToPlayer, List<OrangeModel> oranges, float FloorY,
            float ScreenWidth, float ScreenHeight )
        {
            float y = FloorY - 40f;
            for (int i = 0; i < 3; i++)
                oranges.Add(new OrangeModel(
                    new Vector2(i * 100f, y),
                    new Vector2(bulletSpeed, 0)));

            for (int i = 0; i < 3; i++)
                oranges.Add(new OrangeModel(
                    new Vector2(ScreenWidth - i * 100f, y),
                    new Vector2(-bulletSpeed, 0)));
        }
    }
}
