using BattleFroggy.Model.AttacksModel;
using Microsoft.Xna.Framework;


namespace BattleFroggy.Model.Opponents
{
        internal interface IOpponentModel
        {
            string Name { get; } 
            Vector2 Position { get; set; }
            int Width { get; }
            int Height { get; }
            Rectangle Hitbox { get; }
            AttackModel Attacks { get; }
            float ThrowCooldown { get; set; }
        }

}
