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
        private readonly ArenaController _arenaController;
        private readonly OpponentRepository _repository;
        private readonly SelectionModel _selection;

        private KeyboardState _previousKeyboard;

        public bool ShowDebug { get; private set; } = false;

        public GameController(
            GameModel gameModel,
            PlayerModel playerModel,
            PlayerController playerController,
            OpponentRepository repository,
            OpponentController opponentController,
            ArenaModel arenaModel,
            PointCountModel pointCounter,
            SelectionModel selection
        )
        {
            _gameModel = gameModel;
            _repository = repository;
            _selection = selection;

            _arenaController = new ArenaController(
                playerModel, repository, arenaModel,
                playerController, opponentController,
                new PointCounterController(pointCounter));
        }

        public void Update(KeyboardState keyboard, float deltaTime)
        {
            if (keyboard.IsKeyDown(Keys.F1) && _previousKeyboard.IsKeyUp(Keys.F1))
                ShowDebug = !ShowDebug;

            switch (_gameModel.CurrentState)
            {
                case GameState.MainMenu:
                    if (keyboard.IsKeyDown(Keys.Enter) && _previousKeyboard.IsKeyUp(Keys.Enter))
                        _gameModel.ChangeState(GameState.OpponentSelect);
                    break;

                case GameState.OpponentSelect:
                    if (keyboard.IsKeyDown(Keys.Tab) && _previousKeyboard.IsKeyUp(Keys.Tab))
                        _selection.SelectedOpponent = (_selection.SelectedOpponent + 1) % 2;

                    if (keyboard.IsKeyDown(Keys.Enter) && _previousKeyboard.IsKeyUp(Keys.Enter))
                    {
                        _repository.Set(_selection.SelectedOpponent == 0 ? OpponentState.Stronghold : OpponentState.Carolina);
                        _gameModel.ChangeState(GameState.Arena);
                    }

                    if (keyboard.IsKeyDown(Keys.Escape) && _previousKeyboard.IsKeyUp(Keys.Escape))
                        _gameModel.ChangeState(GameState.MainMenu);
                    break;

                case GameState.Arena:
                    _arenaController.Update(deltaTime, keyboard);
                    break;

                case GameState.GameOver:
                    if (keyboard.IsKeyDown(Keys.Enter) && _previousKeyboard.IsKeyUp(Keys.Enter))
                        _gameModel.ChangeState(GameState.MainMenu);
                    break;
            }

            _previousKeyboard = keyboard;
        }

        public List<Rectangle> GetQuadTreeBounds() => _arenaController.GetQuadTreeBounds();
    }
}