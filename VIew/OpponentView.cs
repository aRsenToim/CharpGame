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
        private readonly OpponentRepository _repository;
        public Texture2D texture;
        private IOpponentModel Opponent => _repository.Current;
        public OpponentView(OpponentRepository repository)
        {
            _repository = repository;
        }
        public void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>(Opponent.Name);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Opponent.Position, Color.White);
        }
            
    }
}
