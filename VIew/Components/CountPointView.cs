using BattleFroggy.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BattleFroggy.VIew.Components
{
    internal class CountPointView
    {
        public ArenaModel model;
        public SpriteFont font;

        public CountPointView(ArenaModel Model)
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
