

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BattleFroggy.Model
{
    enum DirectionFire
    {
        Left,
        Right
    }
    internal class FirePlayer
    {
        public Vector2 Position;
        public DirectionFire direction;

        public FirePlayer(Vector2 position, DirectionFire directionFire) { 
           Position = position;
           direction = directionFire;
        }

        public void Update(float deltaTime)
        {
            if (direction == DirectionFire.Left) {
                Position.X = -(900f * deltaTime);
            }else
            {
                Position.X = (900f * deltaTime);
            }
        }


    }
}
