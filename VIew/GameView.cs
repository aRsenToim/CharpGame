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
        public CountPointView countPointView;
        public HPView hpView;

        public GameView(GameModel gameModel, int width, int height, 
            PlayerModel playerModel, OpponentModel opponentModel, 
            OpponentController opponentController, ArenaModel arenaModel
            )
        {
            model = gameModel;
            mainMenuView = new MainMenuView(width, height);
            arenaView = new ArenaView(width, height);
            widthGame = width;
            heightGame = height;
            playerView = new PlayerView(playerModel);
            opponentView = new OpponentView(opponentModel);
            orangeView = new OrangeView(opponentController.Oranges);
            countPointView = new CountPointView(arenaModel);
            hpView = new HPView(playerModel);
        }

        public void Load(ContentManager Content, GraphicsDevice graphicsDevice)
        {
            mainMenuView.Load(Content);
            arenaView.Load(Content);
            playerView.Load(Content);
            countPointView.Load(Content);
            opponentView.Load(Content);
            orangeView.Load(Content);
            hpView.Load(Content);
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
                    opponentView.Draw(spriteBatch);
                    orangeView.Draw(spriteBatch);
                    countPointView.Draw(spriteBatch);
                    hpView.Draw(spriteBatch);
                    playerView.Draw(spriteBatch);
                    break;
            }
        }
    }
}
