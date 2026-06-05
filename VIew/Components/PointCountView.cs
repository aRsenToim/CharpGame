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
            spriteBatch.DrawString(font, $"Point: {model.CountRound}", new Vector2(0, 0), Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.DrawString(font, $"Best Point: {model.BestPoint}", new Vector2(0, 40), Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
        }
    }
}
