using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BattleFroggy.VIew.Scene
{
    internal class MainMenuView
    {
        public Texture2D MainMenu;
        public int widthGame;
        public int heightGame;
        public MainMenuView(int width, int height)
        {
            widthGame = width;
            heightGame = height;
        }
        public void Load(ContentManager Content)
        {
            MainMenu = Content.Load<Texture2D>("MenuGame");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(MainMenu, new Rectangle(0, 0, widthGame, heightGame), Color.White);
        }
    }
}
