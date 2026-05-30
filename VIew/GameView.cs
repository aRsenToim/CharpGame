using BattleFroggy.Model;
using BattleFroggy.VIew.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using BattleFroggy.VIew.Components;
using System.Collections.Generic;

namespace BattleFroggy.VIew
{
    internal class GameView
    {
        public GameModel model;
        public int widthGame;
        public int heightGame;

        public OpponentView opponentView;
        public PlayerView playerView;
        public OrangeView orangeView;
        public MainMenuView mainMenuView;
        public ArenaView arenaView;
        public HPView hpView;
        public Gameover gameoverView;

        public GameView(
            GameModel gameModel,
            int width,
            int height,
            PlayerModel playerModel,
            OpponentModel opponentModel,
            ArenaModel arenaModel,
            PointCountModel pointCounter
        )
        {
            model = gameModel;
            mainMenuView = new MainMenuView(width, height);
            arenaView = new ArenaView(
                width,
                height,
                playerModel,
                opponentModel,
                arenaModel,
                pointCounter);
            gameoverView = new Gameover();
        }

        public void Load(ContentManager content, GraphicsDevice graphicsDevice)
        {
            mainMenuView.Load(content);
            arenaView.Load(content, graphicsDevice);
            gameoverView.Load(content);
        }

        public void Draw(SpriteBatch spriteBatch, bool showDebug = false, List<Rectangle> debugBounds = null)
        {
            switch (model.CurrentState)
            {
                case GameState.MainMenu:
                    mainMenuView.Draw(spriteBatch);
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