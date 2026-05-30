using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFroggy.Model
{
    internal class PointCountModel
    {
        public float TimeInPoint { get; } = 0.5f;
        public int CountPoint { get; } = 10;
        public int CountRound { get; private set; } = 0;
    
        public PointCountModel(float timeInPoint, int countPoint, int countRound) {
            TimeInPoint = timeInPoint;
            CountPoint = countPoint;
            CountRound = countRound;
        }
        public void SetCoundRound(int countRound)
        {
            CountRound = countRound;
        }
        public void AddCountPoint()
        {
            CountRound += CountPoint;
        }
    }
}
