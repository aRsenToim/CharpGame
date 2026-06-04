using BattleFroggy.Model;
using BattleFroggy.Model.Opponents;
using BattleFroggy.VIew.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

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
        private QuadTreeDebugView _debugView;

        public ArenaView(
            int width,
            int height,
            PlayerModel playerModel,
            IOpponentModel opponentModel,
            ArenaModel arenaModel,
            PointCountModel pointCounter
        )
        {
            widthGame = width;
            heightGame = height;
            playerView = new PlayerView(playerModel);
            opponentView = new OpponentView(opponentModel);
            orangeView = new OrangeView(arenaModel.Oranges);
            _arenaModel = arenaModel;
            hpView = new HPView(playerModel);
            _pointCounterView = new PointCountView(pointCounter);
            _debugView = new QuadTreeDebugView();
        }

        public void Load(ContentManager content, GraphicsDevice graphicsDevice)
        {
            Arena = content.Load<Texture2D>("EdgeCity");
            playerView.Load(content);
            opponentView.Load(content);
            orangeView.Load(content);
            hpView.Load(content);
            _pointCounterView.Load(content);
            _debugView.Load(graphicsDevice);
        }

        public void Draw(SpriteBatch spriteBatch, bool showDebug = false, List<Rectangle> debugBounds = null)
        {
            spriteBatch.Draw(Arena, new Rectangle(0, 0, widthGame, heightGame), Color.White);
            opponentView.Draw(spriteBatch);
            orangeView.Draw(spriteBatch);
            hpView.Draw(spriteBatch);
            playerView.Draw(spriteBatch);
            _pointCounterView.Draw(spriteBatch);

            if (showDebug && debugBounds != null)
                _debugView.Draw(spriteBatch, debugBounds);
        }
    }
}