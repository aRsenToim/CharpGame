using System;

namespace BattleFroggy.Model
{
    enum GameState
    {
        MainMenu,
        OpponentSelect,
        Arena,
        GameOver
    }

    internal class GameModel
    {
        public GameState CurrentState;

        public GameModel(GameState state)
        {
            CurrentState = state;
        }

        public void ChangeState(GameState state)
        {
            CurrentState = state;
        }
    }
}