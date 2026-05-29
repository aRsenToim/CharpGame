using BattleFroggy.Model;
using BattleFroggy.VIew.Scene;
using BattleFroggy.Controller;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BattleFroggy.VIew.Components;

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

        public GameView(GameModel gameModel, int width, int height, PlayerModel playerModel, OpponentModel opponentModel, 
            OpponentController opponentController, ArenaModel arenaModel, PointCountModel pointCounter)
        {
            model = gameModel;
            mainMenuView = new MainMenuView(width, height);
            arenaView =
                new ArenaView(
                    width,
                    height,
                    playerModel,
                    opponentModel,
                    opponentController, 
                    arenaModel, pointCounter);
            gameoverView = new Gameover();
        }


        public void Load(ContentManager Content, GraphicsDevice graphicsDevice)
        {
            mainMenuView.Load(Content);
            arenaView.Load(Content);
            gameoverView.Load(Content);
        }   

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (model.CurrentState)
            {
                case GameState.MainMenu:
                    mainMenuView.Draw(spriteBatch);
                    break;

                case GameState.Arena:
                    arenaView.Draw(spriteBatch);
                    break;
                case GameState.GameOver:
                    gameoverView.Draw(spriteBatch);
                    break;
            }
        }
    }
}
