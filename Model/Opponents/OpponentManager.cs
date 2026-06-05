using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BattleFroggy.Model.Opponents
{
    enum OpponentState
    {
        Stronghold,
        Carolina,
    }
    internal class OpponentManager
    {
        public OpponentState OpponentModel { get; private set; }

        public OpponentManager(OpponentState opponentModel)
        {
            OpponentModel = opponentModel;
        }

        public void setOpponentModel(OpponentState opponentModel)
        {
            OpponentModel = opponentModel;
        }

    }
}
