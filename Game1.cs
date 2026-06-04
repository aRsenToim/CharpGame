using BattleFroggy.Controller;
using BattleFroggy.Model;
using BattleFroggy.Model.Opponents;
using BattleFroggy.VIew;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BattleFroggy
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private int _widthGame = 1280;
        private int _heightGame = 720;
        private GameModel _gameModel;
        private GameController _gameController;
        private GameView _gameView;

        private PlayerController _playerController;
        private PlayerModel _playerModel;



        private OpponentManager _opponentManager;
        private OpponentController _opponentController;

        private ArenaModel _arenaModel;
        private PointCountModel _pointCounterModel;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = _widthGame;
            _graphics.PreferredBackBufferHeight = _heightGame;
        }

        protected override void Initialize()
        {
            _arenaModel = new ArenaModel();
            _pointCounterModel = new PointCountModel(1f, 10, 0);

            _playerModel = new PlayerModel(new Vector2(0, 0));
            _playerController = new PlayerController(_playerModel, _widthGame, 500);

            _opponentManager = new OpponentManager(OpponentState.Stronghold, new Dictionary<OpponentState, Vector2>
            {
                { OpponentState.Carolina, new Vector2(_widthGame, 200) },
                { OpponentState.Stronghold, new Vector2(_widthGame, 200) }
            }
            );
            _opponentController = new OpponentController(_opponentManager.getOpponentModel(), _playerModel, _arenaModel, _widthGame, _heightGame);

            _gameModel = new GameModel(GameState.MainMenu);
            _gameController = new GameController(
                _gameModel,
                _playerModel, _playerController,
                _opponentManager.getOpponentModel(), _opponentController, _arenaModel, _pointCounterModel);

            _gameView = new GameView(
                _gameModel,
                _widthGame,
                _heightGame,
                _playerModel,
                _opponentManager.getOpponentModel(),
                _arenaModel,
                _pointCounterModel);

            _playerModel.OnDeath += () => {
                _pointCounterModel.SetCoundRound(0);
                _gameModel.ChangeState(GameState.GameOver);
                _arenaModel.RemoveAllOranges();
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gameView.Load(Content, GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _gameController.Update(Keyboard.GetState(), deltaTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _gameView.Draw(
                _spriteBatch,
                _gameController.ShowDebug,
                _gameController.ShowDebug ? _gameController.GetQuadTreeBounds() : null
            );
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}