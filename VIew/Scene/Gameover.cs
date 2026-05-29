using BattleFroggy.Model;
using BattleFroggy.VIew.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BattleFroggy.VIew.Scene
{
    internal class Gameover
    {
        public Texture2D textureScene;

        private SpriteFont font;

        public void Load(ContentManager Content)
        {
            textureScene =
                Content.Load<Texture2D>("background");

            font =
                Content.Load<SpriteFont>("BaseFont");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                textureScene,
                new Vector2(0, 0),
                Color.White
            );

            spriteBatch.DrawString(
                font,
                "GAME OVER",
                new Vector2(470, 220),
                Color.Red
            );

            spriteBatch.DrawString(
                font,
                "Press ENTER to Main Menu",
                new Vector2(350, 320),
                Color.White
            );
        }
    }
}