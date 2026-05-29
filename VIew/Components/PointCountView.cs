using BattleFroggy.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace BattleFroggy.VIew.Components
{
    internal class PointCountView
    {
        public PointCountModel model;
        public SpriteFont font;

        public PointCountView(PointCountModel Model)
        {
            model = Model;
        }

        public void Load(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("BaseFont");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 position = new Vector2(0, 0);
            spriteBatch.DrawString(font, $"{model.CountRound}", position, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
        }
    }
}
