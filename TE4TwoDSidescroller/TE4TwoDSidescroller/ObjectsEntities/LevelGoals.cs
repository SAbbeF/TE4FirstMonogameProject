using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{
    class LevelGoals : Entity
    {
        protected bool levelFinished;
        Vector2 myPosition;
        Rectangle myRectangle;
        Texture2D myTexture;
        int level;
        public LevelGoals(int currentLevel)
        {
            levelFinished = false;
            isActive = true;
            hasCollider = true;
            level = currentLevel;


            myPosition = new Vector2(4000 - 150, 720 - 150);
            myRectangle = new Rectangle((int)myPosition.X, (int)myPosition.Y, 50, 50);
            myTexture = new Texture2D
                (GameInfo.graphicsDevice.GraphicsDevice, myRectangle.Width, myRectangle.Height);
            Color[] data = new Color[myRectangle.Width * myRectangle.Height];
            for (int i = 0; i < data.Length; i++)
            {
                if (i < data.Length / 2)
                {

                    data[i] = Color.LightBlue;

                }

                if (i > data.Length / 2)
                {

                    data[i] = Color.DarkBlue;

                }


            }
            myTexture.SetData(data);
            collisionBox = new Rectangle((int)myPosition.X, (int)myPosition.Y, 50, 50);
        }

        public override void HasCollidedWith(Entity collider)
        {
            if (collider.tag == Tags.Player.ToString())
            {
                levelFinished = true;
            }
            else
            {
                levelFinished = false;
            }
        }


        public override void Update(GameTime gameTime)
        {


            if (levelFinished == true)
            {

                if (level == 1)
                {

                    Level1.RemoveContent();
                    Level2.LoadContent();

                }

                if (level == 2)
                {

                    Level2.RemoveContent();
                    Level3.LoadContent();

                }

                if (level == 3)
                {

                    Level3.RemoveContent();
                    Level4.LoadContent();

                }

                if (level == 4)
                {

                    Level4.RemoveContent();
                    LevelBoss.LoadContent();

                }
                if (level == 5)
                {
                    LevelBoss.RemoveContent();



                }
            }

        }
        public override void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Draw(myTexture, myRectangle, Color.White);
        }
    }
}
