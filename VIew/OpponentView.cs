using BattleFroggy.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFroggy.VIew
{
    internal class OpponentView
    {
        public OpponentModel model;
        public Texture2D texture;

        public OpponentView(OpponentModel Model) {
            model = Model;
        }
        public void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("Granny");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, model.Position, Color.White);
        }
            
    }
}
