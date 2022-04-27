using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace TE4TwoDSidescroller
{
    class Platform : Entity
    {
        Texture2D myTexture;
        Vector2 myPosition;

        public Platform(Vector2 floorPosition, int xSize, int Ysize)
        {
            tag = Tags.Platform.ToString();
            isActive = true;
            hasCollider = true;
            collisionBox = new Rectangle();
            myPosition = floorPosition;
           
            collisionBox = new Rectangle((int)floorPosition.X, (int)floorPosition.Y, xSize, Ysize);
            myTexture = new Texture2D
                (GameInfo.graphicsDevice.GraphicsDevice, collisionBox.Width, collisionBox.Height);
            Color[] data = new Color[collisionBox.Width * collisionBox.Height];
            for (int i = 0; i < data.Length; i++)
            {
                if (i < data.Length / 3)
                {

                    data[i] = Color.OrangeRed;

                }

                if (i > data.Length / 3)
                {

                    data[i] = Color.Black;

                }

            }

            myTexture.SetData(data);

        }
        public override void Draw(GameTime gameTime)
        {


            GameInfo.spriteBatch.Draw(myTexture, myPosition, Color.White);


        }
    }
}
