using BattleFroggy.Model;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BattleFroggy.VIew.Components
{
    internal class HPView
    {
        public PlayerModel playerModel;
        public Texture2D HPTexture;
        private int widthTexture = 25;
        private int heightTexture = 25;

        public HPView(PlayerModel PlayerModel)
        {
            playerModel = PlayerModel; 
        }

        public void Load(ContentManager Content)
        {
            HPTexture = Content.Load<Texture2D>("HP");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < playerModel.HP; i++)
            {
                spriteBatch.Draw(HPTexture, new Rectangle(i*widthTexture, 100, widthTexture, heightTexture), Color.White);
            }
        }
    }
}
