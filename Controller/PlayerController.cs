using BattleFroggy.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text.RegularExpressions;


namespace BattleFroggy.Controller
{
    internal class PlayerController
    {
        public PlayerModel model;
        
        private KeyboardState _previousKeyboard;
        private int _screenWidth;
        private int Floor;


        public PlayerController(PlayerModel playerModel, int screenWidth, int floor)
        {
            model = playerModel;
            _screenWidth = screenWidth;
            Floor = floor;
        }
        public void ResolveCollisions(Rectangle opponentHitbox)
        {
            if (model.Hitbox.Intersects(opponentHitbox))
                model.Position.X = opponentHitbox.X - model.Width;
        }

        public void SetPosition(float deltaTime)
        {
            model.Velocity.Y += model.Gravity * deltaTime;

            model.Position += model.Velocity * deltaTime;

            if (model.Position.Y + model.Height >= Floor)
            {
                model.Position.Y = Floor - model.Height;
                model.Velocity.Y = 0;

                model.Ground = true;
                model.countJump = 0;
            }
            else
            {
                model.Ground = false;
            }

            if (model.Position.X < 0)
            {
                model.Position.X = 0;
            }

            if (model.Position.X + model.Width > _screenWidth)
            {
                model.Position.X = _screenWidth - model.Width;
            }
        }

        public void Jump()
        {
            if (model.countJump < model.maxJump)
            {
                model.Velocity.Y = model.JumpForce;
                model.Ground = false;
                model.countJump++;
            }
        }

        public void Update(float deltaTime, KeyboardState keyboardState, Rectangle opponentHitbox)
        {
            model.Velocity.X = 0;

            ResolveCollisions(opponentHitbox);

            if (keyboardState.IsKeyDown(Keys.A))
            {
                model.Velocity.X = -model.Speed;
                if(model.Ground) model.playerDirection = PlayerDirection.Left;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                model.Velocity.X = model.Speed;
                if (model.Ground) model.playerDirection = PlayerDirection.Right;
            }


            if (keyboardState.IsKeyDown(Keys.Space) && _previousKeyboard.IsKeyUp(Keys.Space))
            {
                model.playerDirection = PlayerDirection.Default;
                Jump();
            }

            _previousKeyboard = keyboardState;
            SetPosition(deltaTime);
        }
    }
}
