using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFroggy.Model
{

    enum GameState
    {
        MainMenu,
        Arena,
        GameOver
    }
    internal class GameModel
    {
        public GameState CurrentState;

        public GameModel(GameState state) {
            CurrentState = state;
        }
        public void ChangeState(GameState state)
        {
            CurrentState = state;
        }
    }
}
