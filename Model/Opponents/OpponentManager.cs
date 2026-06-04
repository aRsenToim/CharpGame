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
        public Dictionary<OpponentState, IOpponentModel> Opponents;

        public OpponentManager(OpponentState opponentModel, Dictionary<OpponentState, Vector2> positions)
        {
            OpponentModel = opponentModel;
            Opponents = new Dictionary<OpponentState, IOpponentModel>();
            Opponents.Add(OpponentState.Carolina, new Carolina(positions[OpponentState.Carolina]));
            Opponents.Add(OpponentState.Stronghold, new Stronghold(positions[OpponentState.Stronghold]));
        }

        public void setOpponentModel(OpponentState opponentModel)
        {
            OpponentModel = opponentModel;
        }

        public IOpponentModel getOpponentModel() {
            return Opponents[OpponentModel];
        }

    }
}
