using BattleFroggy.Model;
using BattleFroggy.Model.Opponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BattleFroggy.Controller
{
    internal class ArenaController
    {
        private readonly ArenaModel _arenaModel;
        private readonly PlayerController _playerController;
        private readonly OpponentController _opponentController;
        private readonly PointCounterController _pointCounterController;
        private readonly QuadTreeController _quadTree;
        private readonly List<QuadTreeObject> _resultsCollisions;
        private readonly PlayerModel _playerModel;
        private readonly OpponentRepository _repository;

        public ArenaController(
            PlayerModel playerModel,
            OpponentRepository repository,
            ArenaModel arenaModel,
            PlayerController playerController,
            OpponentController opponentController,
            PointCounterController pointCounterController
        )
        {
            _playerModel = playerModel;
            _repository = repository;
            _arenaModel = arenaModel;
            _playerController = playerController;
            _opponentController = opponentController;
            _pointCounterController = pointCounterController;
            _quadTree = new QuadTreeController(new Rectangle(0, 0, 1280, 720), 0);
            _resultsCollisions = new List<QuadTreeObject>();
        }

        public void Update(
            float deltaTime,
            KeyboardState keyboardState
        )
        {
            _playerController.Update(
                deltaTime,
                keyboardState,
                _repository.Current.Hitbox
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