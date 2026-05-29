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
        private readonly ArenaModel _arenaModel;
        private readonly PlayerModel _playerModel;
        private readonly OpponentModel _opponentModel;
        
        private readonly PointCounterController _pointCounterController;
        public ArenaController arenaController;
        

        private QuadTreeController _quadTree;
        private List<QuadTreeObject> _resultsCollisions;
        private KeyboardState _previousKeyboard;


        public GameController(
            GameModel gameModel,
            PlayerModel playerModel,
            PlayerController playerController,
            OpponentModel opponentModel,
            OpponentController opponentController,
            ArenaModel arenaModel,
            PointCountModel pointCounter
            )
        {
            _gameModel = gameModel;
            _playerModel = playerModel;
            _playerController = playerController;
            _opponentModel = opponentModel;
            _arenaModel = arenaModel;
            _opponentController = opponentController;
            arenaController = new ArenaController(
                _gameModel,
                playerModel,
                opponentModel,
                playerController,
                opponentController,
                new PointCounterController(pointCounter)
            );

            _quadTree = new QuadTreeController(new Rectangle(0, 0, 1920, 1080), 0);
            _resultsCollisions = new List<QuadTreeObject>();
            _pointCounterController = new PointCounterController(pointCounter);
        }

        public void Update(KeyboardState keyboardState, float deltaTime)
        {
            switch (_gameModel.CurrentState)
            {
                case GameState.MainMenu:
                    if (keyboardState.IsKeyDown(Keys.Enter) && _previousKeyboard.IsKeyUp(Keys.Enter))
                        _gameModel.ChangeState(GameState.Arena);
                    break;

                case GameState.Arena:
                    arenaController.Update(deltaTime, keyboardState);
                    UpdateCollisions();
                    break;

                case GameState.GameOver:
                    if (keyboardState.IsKeyDown(Keys.Enter) && _previousKeyboard.IsKeyUp(Keys.Enter))
                        _gameModel.ChangeState(GameState.MainMenu);
                    break;
            }

            _previousKeyboard = keyboardState;
        }

        private void UpdateCollisions() {
            _quadTree.Clear();
            _resultsCollisions.Clear();

            foreach (var orange in _arenaModel.Oranges)
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
