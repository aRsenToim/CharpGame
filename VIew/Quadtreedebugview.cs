using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BattleFroggy.VIew.Components
{
    internal class QuadTreeDebugView
    {
        private Texture2D _pixel;

        public void Load(GraphicsDevice graphicsDevice)
        {
            _pixel = new Texture2D(graphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch, List<Rectangle> bounds)
        {
            foreach (var rect in bounds)
            {
                DrawRect(spriteBatch, rect, new Color(0, 255, 100, 60));
            }   
        }

        private void DrawRect(SpriteBatch spriteBatch, Rectangle rect, Color color)
        {
            int t = 1;
            spriteBatch.Draw(_pixel, new Rectangle(rect.X, rect.Y, rect.Width, t), color);
            spriteBatch.Draw(_pixel, new Rectangle(rect.X, rect.Bottom - t, rect.Width, t), color);
            spriteBatch.Draw(_pixel, new Rectangle(rect.X, rect.Y, t, rect.Height), color);
            spriteBatch.Draw(_pixel, new Rectangle(rect.Right - t, rect.Y, t, rect.Height), color);
        }
    }
}