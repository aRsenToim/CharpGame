
using BattleFroggy.Model;

namespace BattleFroggy.Controller
{
    internal class PointController
    {
        private float _timerCountPoint;
        private PointCountModel _model;

        public PointController(PointCountModel pointCountModel)
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
