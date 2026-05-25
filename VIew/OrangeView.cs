using BattleFroggy.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BattleFroggy.VIew
{
    internal class OrangeView
    {
        public List<OrangeModel> oranges;
        public Texture2D texture;

        public OrangeView(List<OrangeModel> orangeList)
        {
            oranges = orangeList;
        }

        public void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("orange");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var orange in oranges)
            {
                if (orange.IsActive)
                    spriteBatch.Draw(texture, orange.Hitbox, Color.White);
            }
        }
    }
}
