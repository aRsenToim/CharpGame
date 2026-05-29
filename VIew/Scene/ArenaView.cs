using BattleFroggy.Controller;
using BattleFroggy.Model;
using BattleFroggy.VIew.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BattleFroggy.VIew.Scene
{
    internal class ArenaView
    {
        public Texture2D Arena;

        public int widthGame;
        public int heightGame;

        private OpponentView opponentView;
        private PlayerView playerView;
        private OrangeView orangeView;
        private HPView hpView;
        private ArenaModel _arenaModel;
        private PointCountView _pointCounterView;

        public ArenaView(
            int width,
            int height,
            PlayerModel playerModel,
            OpponentModel opponentModel,
            OpponentController opponentController,
            ArenaModel arenaModel,
            PointCountModel pointCounter
        ){
            widthGame = width;
            heightGame = height;
            playerView = new PlayerView(playerModel);
            opponentView = new OpponentView(opponentModel);
            orangeView = new OrangeView(arenaModel.Oranges);
            _arenaModel = arenaModel;
            hpView = new HPView(playerModel);
            _pointCounterView = new PointCountView(pointCounter);
        }

        public void Load(ContentManager Content)
        {
            Arena = Content.Load<Texture2D>("EdgeCity");
            playerView.Load(Content);
            opponentView.Load(Content);
            orangeView.Load(Content);
            hpView.Load(Content);
            _pointCounterView.Load(Content);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Arena, new Rectangle(0, 0, widthGame, heightGame), Color.White);
            opponentView.Draw(spriteBatch);
            orangeView.Draw(spriteBatch);
            hpView.Draw(spriteBatch);
            playerView.Draw(spriteBatch);
            _pointCounterView.Draw(spriteBatch);
        }
    }
}