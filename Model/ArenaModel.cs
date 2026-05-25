using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFroggy.Model
{
    internal class ArenaModel
    {
        public float TimeInPoint { get; } = 0.5f;
        public int CountPoint { get; } = 10;
        public int CountRound;
        public bool IsActivePlayer;

        public ArenaModel(int countRound, bool isActivePlayer)
        {
            CountRound = countRound;
            IsActivePlayer = isActivePlayer;
        }


    }
}
