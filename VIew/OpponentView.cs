using BattleFroggy.Model.Opponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BattleFroggy.VIew
{
    internal class OpponentView
    {
        private readonly OpponentRepository _repository;
        private Texture2D _texStronghold;
        private Texture2D _texCarolina;

        public OpponentView(OpponentRepository repository)
        {
            _repository = repository;
        }

        public void Load(ContentManager content)
        {
            _texStronghold = content.Load<Texture2D>("stronghold");
            try { _texCarolina = content.Load<Texture2D>("carolina"); }
            catch { _texCarolina = _texStronghold; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var current = _repository.Current;
            var tex = current.Name == "carolina" ? _texCarolina : _texStronghold;
            spriteBatch.Draw(tex, current.Position, Color.White);
        }
    }
}