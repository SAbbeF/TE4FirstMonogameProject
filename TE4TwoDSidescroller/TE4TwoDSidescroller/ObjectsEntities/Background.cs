using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using MonoGame;


namespace TE4TwoDSidescroller
{
    class Background : Entity
    {
        Texture2D myTexture;
        Rectangle sourceRectangle;
        int playerCoordinatesX;
        int playerCoordinatesY;
        float layer;
        float scale;
        float rotation;
        float backgroundSpeed;
        Vector2 backgroundPosition;
        

        

        public Background()
        {
            backgroundSpeed = 0.03f;
            scale = 1.1f;
            layer = 0.0f;
            rotation = 0f;
            playerCoordinatesX = (int)GameInfo.player1Position.X;
            playerCoordinatesY = (int)GameInfo.player1Position.Y;
            
            string currentPath =
           Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/" + "Background.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {

                myTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

            }
            
            sourceRectangle = new Rectangle(0, 0, myTexture.Width, myTexture.Height);
            
        }

        public override void Update(GameTime gameTime)
        {
            //sourceRectangle.X = playerCoordinatesX * (int)backgroundSpeed * (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            //sourceRectangle.Y = playerCoordinatesY * (int)backgroundSpeed * (int)gameTime.ElapsedGameTime.TotalMilliseconds;

        }

        public override void Draw(GameTime gameTime)
        {

            GameInfo.spriteBatch.Draw
                (myTexture, new Vector2(GameInfo.viewportPosition.X - GameInfo.viewportPosition.X * backgroundSpeed, GameInfo.viewportPosition.Y - GameInfo.viewportPosition.Y * backgroundSpeed), sourceRectangle, Color.White, rotation, position, scale, SpriteEffects.None, layer);


        }

    }
}
