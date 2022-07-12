using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongClone
{
    public class Ball : Microsoft.Xna.Framework.Game
    {
        public SoundEffect blip;
        public Vector2 position;
        public Texture2D texture;
        public int Width, Height, score1, score2;
        public float speed;
        public bool movingDownLeft, movingDownRight, movingUpRight, movingUpLeft;

        public Ball()
        {
            Content.RootDirectory = ("Content");
            speed = 6.0f;
            Width = 20;
            Height = 20;
            score1 = 0;
            score2 = 0;
            movingDownLeft = true;
            movingDownRight = false;
            movingUpLeft = false;
            movingUpRight = false;
            texture = null;
            position = Vector2.Zero;
            blip = Content.Load<SoundEffect>("blip");
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void Update()
        {
            if(movingUpLeft)
            {
                position.Y -= speed;
                position.X -= speed;

            }

            if(movingDownLeft)
            {
                position.Y += speed;
                position.X -= speed;
            }

            if(movingUpRight)
            {
                position.Y -= speed;
                position.X += speed;
            }

            if(movingDownRight)
            {
                position.Y += speed;
                position.X += speed;
            }

            if(movingUpLeft && position.Y <=0 +25)
            {
                blip.Play();
                movingDownLeft = true;
                movingUpLeft = false;
            }

           else if(movingDownLeft && position.X <=0)
            {
                blip.Play();
                score2 = score2 + 1;
                movingDownLeft = false;
                movingDownRight = true;
            }

            else if(movingUpLeft && position.X<=0)
            {
                score2 = score2 + 1;
                movingUpRight = true;
                movingUpLeft = false;
            }

            else if(movingDownLeft && position.Y >=768-45)
            {
                blip.Play();
                movingUpLeft = true;
                movingDownLeft = false;
            }

            else if(movingDownRight && position.X >= 1024-Width)
            {
                blip.Play();
                score1 = score1 + 1;
                movingDownLeft = true;
                movingDownRight = false;
            }

            else if (movingUpRight && position.Y <= 0 +25)
            {
                blip.Play();
                movingDownRight = true;
                movingUpRight = false;

            }

            else if(movingDownRight && position.Y >= 768-45)
            {
                blip.Play();
                movingUpRight = true;
                movingDownRight = false;
            }

            else if(movingUpRight && position.X >= 1024-Width)
            {
                blip.Play();
                score1 = score1 + 1;

                movingUpLeft = true;
                movingUpRight = false;
            }
        }
    }

}
