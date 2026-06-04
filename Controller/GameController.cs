using BattleFroggy.Model;
using BattleFroggy.Model.Opponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BattleFroggy.Controller
{
    internal class GameController
    {
        private readonly GameModel _gameModel;
        private readonly PlayerModel _playerModel;

        private readonly ArenaController _arenaController;

        private KeyboardState _previousKeyboard;

        public bool ShowDebug { get; private set; } = false;

        public GameController(
            GameModel gameModel,
            PlayerModel playerModel,
            PlayerController playerController,
            IOpponentModel opponentModel,
            OpponentController opponentController,
            ArenaModel arenaModel,
            PointCountModel pointCounter
        )
        {
            _gameModel = gameModel;
            _playerModel = playerModel;

            var pointCounterController = new PointCounterController(pointCounter);

            _arenaController = new ArenaController(
                gameModel,
                playerModel,
                opponentModel,
                arenaModel,
                playerController,
                opponentController,
                pointCounterController
            );
        }

        public void Update(KeyboardState keyboardState, float deltaTime)
        {
            if (keyboardState.IsKeyDown(Keys.F1) && _previousKeyboard.IsKeyUp(Keys.F1))
                ShowDebug = !ShowDebug;

            switch (_gameModel.CurrentState)
            {
                case GameState.MainMenu:
                    if (keyboardState.IsKeyDown(Keys.Enter) && _previousKeyboard.IsKeyUp(Keys.Enter))
                        _gameModel.ChangeState(GameState.Arena);
                    break;

                case GameState.Arena:
                    _arenaController.Update(deltaTime, keyboardState);
                    break;

                case GameState.GameOver:
                    if (keyboardState.IsKeyDown(Keys.Enter) && _previousKeyboard.IsKeyUp(Keys.Enter))
                        _gameModel.ChangeState(GameState.MainMenu);
                    break;
            }

            _previousKeyboard = keyboardState;
        }

        public List<Rectangle> GetQuadTreeBounds()
        {
            return _arenaController.GetQuadTreeBounds();
        }
    }
}