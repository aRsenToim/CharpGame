using BattleFroggy.Model;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace BattleFroggy.Controller
{
    internal class ArenaController
    {
        private readonly GameModel _gameModel;
        private readonly ArenaModel _arenaModel;
        private readonly PlayerController _playerController;
        private readonly OpponentController _opponentController;
        private readonly PointCounterController _pointCounterController;
        private readonly QuadTreeController _quadTree;
        private readonly List<QuadTreeObject> _resultsCollisions;
        private readonly PlayerModel _playerModel;
        private readonly OpponentModel _opponentModel;

        public ArenaController(
            GameModel gameModel,
            PlayerModel playerModel,
            OpponentModel opponentModel,
            ArenaModel arenaModel,
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
            _quadTree = new QuadTreeController(new Rectangle(0, 0, 1280, 720), 0);
            _resultsCollisions = new List<QuadTreeObject>();
            _arenaModel = arenaModel;
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
            UpdateCollisions();
        }

        private void UpdateCollisions()
        {
            _quadTree.Clear();
            _resultsCollisions.Clear();

            foreach (var orange in _arenaModel.Oranges)
            {
                if (orange.IsActive)
                    _quadTree.Insert(orange);
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

        public List<Rectangle> GetQuadTreeBounds()
        {
            return _quadTree.GetFullBounds();
        }
    }
}