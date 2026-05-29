using BattleFroggy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFroggy.Controller
{
    internal class PointCounterController
    {
        private float _timerCountPoint;
        private PointCountModel _model;

        public PointCounterController(PointCountModel pointCountModel)
        {
            _model = pointCountModel;
        }

        public void Update(float deltaTime)
        {
            _timerCountPoint += deltaTime;

            if (_timerCountPoint >= _model.TimeInPoint)
            {
                _model.AddCountPoint();
                _timerCountPoint = 0;
            }   
        }
    }
}
