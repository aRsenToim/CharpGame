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
    internal class PlayerView
    {
        public PlayerModel player;
        public Texture2D playerTexture;
        public Texture2D playerTextureLeft;
        public Texture2D playerTextureRigth;

        public PlayerView(PlayerModel playerModel)
        {
            player = playerModel;
        }

        public void Load(ContentManager Content)
        {
            playerTexture = Content.Load<Texture2D>("froggy");
            playerTextureLeft = Content.Load<Texture2D>("froggy_left");
            playerTextureRigth = Content.Load<Texture2D>("froggy_rigth");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (player.playerDirection)
            {
                case PlayerDirection.Left:
                    spriteBatch.Draw(playerTextureLeft, player.Hitbox, Color.White);
                    break;
                case PlayerDirection.Right:
                    spriteBatch.Draw(playerTextureRigth, player.Hitbox, Color.White);
                    break;
                default:
                    spriteBatch.Draw(playerTexture, player.Hitbox, Color.White);
                    break;
            }
        }
    }
}
