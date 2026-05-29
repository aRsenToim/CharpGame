using BattleFroggy.Controller;
using BattleFroggy.Model;
using BattleFroggy.VIew;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BattleFroggy
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Entities Game
        private int _widthGame = 1280;
        private int _heightGame = 720;
        private GameModel _gameModel;
        private GameController _gameController;
        private GameView _gameView;

        // Entities Player
        private PlayerController _playerController;
        private PlayerModel _playerModel;

        // Entities Opponent
        private OpponentModel _opponentModel;
        private OpponentController _opponentController;


        //Entities Arena
        private ArenaModel _arenaModel;

        //Entities PointCounter
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
            //Entities Arena
            _arenaModel = new ArenaModel(true);
            _pointCounterModel = new PointCountModel(1f, 10, 0);


            // Entities Player
            _playerModel = new PlayerModel(new Vector2(0, 0));
            _playerController = new PlayerController(_playerModel, _widthGame, 500);

            // Entities Opponent
            _opponentModel = new OpponentModel(new Vector2(_widthGame, 200));
            _opponentController = new OpponentController(_opponentModel, _playerModel, _arenaModel, _widthGame, _heightGame);


            // Entities Game
            _gameModel = new GameModel(GameState.MainMenu);
            _gameController = new GameController(
                _gameModel, 
                _playerModel, _playerController,
                _opponentModel, _opponentController, _arenaModel, _pointCounterModel);


            _gameView = new GameView(_gameModel, _widthGame, _heightGame, _playerModel, _opponentModel, _opponentController, _arenaModel, _pointCounterModel);

            _playerModel.OnDeath += () => _gameModel.ChangeState(GameState.GameOver);

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
            _gameView.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}