using BattleFroggy.Model;
using Microsoft.Xna.Framework.Input;

namespace BattleFroggy.Controller
{
    internal class ArenaController
    {
        private readonly GameModel _gameModel;

        private readonly PlayerController _playerController;
        private readonly OpponentController _opponentController;
        private readonly PointCounterController _pointCounterController;

        private readonly PlayerModel _playerModel;
        private readonly OpponentModel _opponentModel;

        public ArenaController(
            GameModel gameModel,
            PlayerModel playerModel,
            OpponentModel opponentModel,
            PlayerController playerController,
            OpponentController opponentController,
            PointCounterController pointCounterController
        )
        {
            _gameModel = gameModel;

            _playerModel = playerModel;
            _opponentModel = opponentModel;

            _playerController = playerController;
            _opponentController = opponentController;
            _pointCounterController = pointCounterController;
        }

        public void Update(
            float deltaTime,
            KeyboardState keyboardState
        )
        {
            _playerController.Update(
                deltaTime,
                keyboardState,
                _opponentModel.Hitbox
            );

            _opponentController.Update(deltaTime);

            _pointCounterController.Update(deltaTime);

            CheckGameOver();
        }

        private void CheckGameOver()
        {
            if (_playerModel.HP <= 0)
            {
                _gameModel.ChangeState(GameState.GameOver);
            }
        }
    }
}