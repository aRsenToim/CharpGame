using BattleFroggy.Model;
using BattleFroggy.Model.Opponents;
using BattleFroggy.VIew.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BattleFroggy.VIew
{
    internal class GameView
    {
        public GameModel model;
        public int widthGame;
        public int heightGame;

        public MainMenuView mainMenuView;
        public ArenaView arenaView;
        public Gameover gameoverView;
        public OpponentSelectView opponentSelectView;

        private BattleFroggy.Controller.GameController _controller;

        public GameView(
            GameModel gameModel,
            int width, int height,
            PlayerModel playerModel,
            OpponentRepository repository,
            ArenaModel arenaModel,
            PointCountModel pointCounter
        )
        {
            model = gameModel;
            widthGame = width;
            heightGame = height;
            mainMenuView = new MainMenuView(width, height);
            arenaView = new ArenaView(width, height, playerModel, repository, arenaModel, pointCounter);
            gameoverView = new Gameover();
            opponentSelectView = new OpponentSelectView(width, height);
        }

        public void SetController(BattleFroggy.Controller.GameController controller)
            => _controller = controller;

        public void Load(ContentManager content, GraphicsDevice graphicsDevice)
        {
            mainMenuView.Load(content);
            arenaView.Load(content, graphicsDevice);
            gameoverView.Load(content);
            opponentSelectView.Load(content);
        }

        public void Draw(SpriteBatch spriteBatch, bool showDebug = false, List<Rectangle> debugBounds = null)
        {
            switch (model.CurrentState)
            {
                case GameState.MainMenu:
                    mainMenuView.Draw(spriteBatch);
                    break;

                case GameState.OpponentSelect:
                    opponentSelectView.Draw(spriteBatch, _controller?.SelectedOpponent ?? 0);
                    break;

                case GameState.Arena:
                    arenaView.Draw(spriteBatch, showDebug, debugBounds);
                    break;

                case GameState.GameOver:
                    gameoverView.Draw(spriteBatch);
                    break;
            }
        }
    }
}