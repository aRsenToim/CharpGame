using BattleFroggy.Model;
using BattleFroggy.Model.Opponents;
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
        public IOpponentModel model;
        public Texture2D texture;

        public OpponentView(IOpponentModel Model) {
            model = Model;
        }
        public void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>(model.Name);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, model.Position, Color.White);
        }
            
    }
}
