using BattleFroggy.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BattleFroggy.Controller
{
    internal class GameController
    {
        private readonly GameModel _gameModel;
        private readonly PlayerController _playerController;
        private readonly OpponentController _opponentController;
        private readonly PlayerModel _playerModel;
        private readonly OpponentModel _opponentModel;

        public ArenaController arenaController;

        private QuadTreeController _quadTree;
        private List<QuadTreeObject> _resultsCollisions;

        public GameController(
            GameModel gameModel,
            PlayerModel playerModel,
            PlayerController playerController,
            OpponentModel opponentModel,
            OpponentController opponentController,
            ArenaModel arenaModel
            )
        {
            _gameModel = gameModel;
            _playerModel = playerModel;
            _playerController = playerController;
            _opponentModel = opponentModel;
            _opponentController = opponentController;
            arenaController = new ArenaController(arenaModel);

            _quadTree = new QuadTreeController(new Rectangle(0, 0, 1920, 1080), 0);
            _resultsCollisions = new List<QuadTreeObject>();
        }

        public void Update(KeyboardState keyboardState, float deltaTime)
        {
            switch (_gameModel.CurrentState)
            {
                case GameState.MainMenu:
                    if (keyboardState.IsKeyDown(Keys.Enter))
                    {
                        _gameModel.ChangeState(GameState.Arena);
                    }
                    break;

                case GameState.Arena:
                    if (keyboardState.IsKeyDown(Keys.Escape))
                    {
                        _gameModel.ChangeState(GameState.MainMenu);
                    }
                    _playerController.Update(deltaTime, Keyboard.GetState(), _opponentModel.Hitbox);
                    _opponentController.Update(deltaTime);
                    arenaController.Update(deltaTime);
                    UpdateCollisions();

                    break;
            }
        }

        private void UpdateCollisions() {
            _quadTree.Clear();
            _resultsCollisions.Clear();

            foreach (var orange in _opponentController.Oranges)
            {
                if (orange.IsActive)
                {
                    _quadTree.Insert(orange);
                }
            }


            _quadTree.Query(_resultsCollisions, _playerModel.Hitbox);

            foreach (var quadObject in _resultsCollisions)
            {
                OrangeModel orange = (OrangeModel)quadObject;

                if (orange.IsActive && _playerModel.Hitbox.Intersects(orange.Hitbox))
                {
                    _playerModel.KillHp();
                    orange.IsActive = false;
                }
            }
        }
    }
}
