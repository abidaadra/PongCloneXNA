using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongClone
{
   
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont georgia;

        Texture2D topBumper;
        Texture2D bottomBumper;

        Vector2 tBumperPos;
        Vector2 bBumperPos;

        Vector2 p1scorePos;
        Vector2 p2scorePos;

        Paddle p1 = new Paddle();
        Paddle p2 = new Paddle();
        Ball ball = new Ball();


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1024;
            Content.RootDirectory = "Content";
        }

      
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

    
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            p1.texture = Content.Load<Texture2D>("player1paddle");
            p2.texture = Content.Load<Texture2D>("player2paddle");

            topBumper = Content.Load<Texture2D>("topbumper");
            bottomBumper = Content.Load<Texture2D>("bottombumper");

            ball.texture = Content.Load<Texture2D>("ball");

            georgia = Content.Load<SpriteFont>("georgiaFont");


            // TODO: use this.Content to load your game content here
            p1.position.X = 50;
            p1.position.Y = graphics.GraphicsDevice.Viewport.Height / 2 - (p1.height / 2);
            p2.position.X = graphics.GraphicsDevice.Viewport.Width - 50 - (p2.width);
            p2.position.Y = graphics.GraphicsDevice.Viewport.Height / 2 - (p2.height / 2);

            p1scorePos.X = 0;
            p1scorePos.Y = 30;
            p2scorePos.X = 850;
            p2scorePos.Y = 30;

            ball.position.X = (768 / 2) - ball.Width / 2;
            ball.position.Y = (768 / 2) - ball.Height / 2;

            tBumperPos.Y = 0;
            tBumperPos.X = 0;
            bBumperPos.X = 0;
            bBumperPos.Y = 768 - 25;



        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

       
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            PlayerInput();
            p1.Update();
            p2.Update();
            ball.Update();

            if(CollidingWithPaddle1())
            {
                if(ball.movingDownLeft)
                {
                    ball.blip.Play();
                    ball.movingDownLeft = false;
                    ball.movingDownRight = true;
                }

                else if(ball.movingUpLeft)
                {
                    ball.blip.Play();
                    ball.movingUpLeft = false;
                    ball.movingUpRight = true;
                }

            }

            if (CollidingWithPaddle2())
            {
                if(ball.movingDownRight)
                {
                    ball.blip.Play();
                    ball.movingDownRight = false;
                    ball.movingDownLeft = true;
                }

                else if(ball.movingUpRight)
                {
                    ball.blip.Play();
                    ball.movingUpRight = false;
                    ball.movingUpLeft = true;
                }
            }

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            p1.Draw(spriteBatch);
            p2.Draw(spriteBatch);
            ball.Draw(spriteBatch);

            spriteBatch.Draw(topBumper, tBumperPos, Color.White);
            spriteBatch.Draw(bottomBumper, bBumperPos, Color.White);

            spriteBatch.DrawString(georgia, "Player 1: " + ball.score1.ToString(), p1scorePos, Color.Blue);
            spriteBatch.DrawString(georgia, "Player 2: " + ball.score2.ToString(), p2scorePos, Color.Red);




            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void PlayerInput()
        {
            if (Keyboard.GetState(p1.pNumber).IsKeyDown(Keys.W))
            {
                p1.position.Y -= p1.speed;

            }

            else if(Keyboard.GetState(p1.pNumber).IsKeyDown(Keys.S))
            {
                p1.position.Y += p1.speed;
            }

            if (Keyboard.GetState(p2.pNumber).IsKeyDown(Keys.Up))
            {
                p2.position.Y -= p2.speed;

            }

            else if (Keyboard.GetState(p2.pNumber).IsKeyDown(Keys.Down))
            {
                p2.position.Y += p2.speed;
            }
        }

        public bool CollidingWithPaddle1()
        {
            if (ball.position.Y >= p1.position.Y && ball.position.X > p1.position.X && ball.position.X < (p1.position.X + p1.width) && ball.position.Y < (p1.position.Y + p1.height))
            {
                return true;
            }

            else
                return false;
        }

        public bool CollidingWithPaddle2()
        {
            if (ball.position.Y >= p2.position.Y && ball.position.X > p2.position.X && ball.position.X < (p2.position.X + p2.width) && ball.position.Y < (p2.position.Y + p2.height))
            {
                return true;
            }

            else
                return false;
        }
    }
}
