using BattleFroggy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFroggy.Controller
{
    internal class ArenaController
    {
        private float _timerCountPoint;
        private ArenaModel ArenaModel;
        
        public ArenaController(ArenaModel arenaModel)
        {
            ArenaModel = arenaModel;
        }
        
        public void Update(float deltaTime)
        {
            _timerCountPoint += deltaTime;

            if(_timerCountPoint >= ArenaModel.TimeInPoint)
            {
                ArenaModel.CountRound += ArenaModel.CountPoint;

                _timerCountPoint = 0;
            }
        }
    }
}
