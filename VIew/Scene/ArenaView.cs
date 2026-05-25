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

        public ArenaView(int width, int height)
        {
            widthGame = width;
            heightGame = height;
        }

        public void Load(ContentManager Content)
        {
            Arena = Content.Load<Texture2D>("EdgeCity");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Arena, new Rectangle(0, 0, widthGame, heightGame), Color.White);
        }
    }
}
