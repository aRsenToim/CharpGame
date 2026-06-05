using BattleFroggy.Model.Opponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BattleFroggy.VIew.Scene
{
    internal class OpponentSelectView
    {
        private readonly int _w;
        private readonly int _h;
        private SpriteFont _font;

        private static readonly string[] Names = { "STRONGHOLD", "CAROLINA" };

        public OpponentSelectView(int width, int height)
        {
            _w = width;
            _h = height;
        }

        public void Load(ContentManager content)
        {
            _font = content.Load<SpriteFont>("BaseFont");
        }

        public void Draw(SpriteBatch sb, int selected)
        {
            for (int i = 0; i < Names.Length; i++)
            {
                string label = (i == selected ? "> " : "  ") + Names[i];
                Color color = i == selected ? Color.White : Color.Gray;
                Vector2 size = _font.MeasureString(label);
                sb.DrawString(_font, label, new Vector2(_w / 2f - size.X / 2f, _h / 2f + i * 60), color);
            }
        }
    }
}