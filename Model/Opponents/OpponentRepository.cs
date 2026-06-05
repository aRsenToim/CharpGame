using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BattleFroggy.Model.Opponents
{
    internal class OpponentRepository
    {
        private readonly Dictionary<OpponentState, Vector2> _positions;
        public IOpponentModel Current { get; private set; }

        public OpponentRepository(Dictionary<OpponentState, Vector2> positions)
        {
            _positions = positions;
            Current = new Carolina(positions[OpponentState.Carolina]);
        }

        public void Set(OpponentState state)
        {
            Current = state switch
            {
                OpponentState.Stronghold => new Stronghold(_positions[OpponentState.Stronghold]),
                OpponentState.Carolina => new Carolina(_positions[OpponentState.Carolina]),
                _ => Current
            };
        }
    }
}
