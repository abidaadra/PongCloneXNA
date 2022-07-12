using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongClone
{
    public class Paddle : Microsoft.Xna.Framework.Game
    {
        public Texture2D texture;
        public Vector2 position;
        public PlayerIndex pNumber;
        public int width, height, speed;

        public Paddle()
        {
            texture = null;
            position = Vector2.Zero;
            pNumber = PlayerIndex.One;
            width = 35;
            height = 200;
            speed = 20;
        }

        public void Update()
        {
            if(position.Y <= 25)
            
                position.Y = 25;

            if (position.Y >= 768 - 225)
                position.Y = 768 - 225;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);

        }
    }
}
