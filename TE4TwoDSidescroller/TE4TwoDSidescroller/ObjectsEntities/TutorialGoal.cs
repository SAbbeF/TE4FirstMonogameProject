using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{
    class TutorialGoal : Entity
    {
        Texture2D myTexture;
        Vector2 myPosition;
        public Rectangle myRectangle;
        bool tutorialFinished;
        public TutorialGoal()
        {
            tutorialFinished = false;
            isActive = true;
            hasCollider = true;



            myPosition = new Vector2(4000-150, 720-150);
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

        #region faulty
        //public static bool InputChecks(Player player)
        //{
        //    bool flagLeft = false;
        //    bool flagRight = false;
        //    bool flagUp = false;
        //    bool flagDown = false;
        //    bool flagRun = false;
        //    bool flagAttack = false;

        //    #region Checks
        //    while (player.isActive)
        //    {

        //        if (player.MoveRight())
        //        {

        //            flagRight = true;

        //        }

        //        if (player.MoveLeft())
        //        {

        //            flagLeft = true;

        //        }

        //        if (player.)
        //        {

        //           flagUp = true;

        //        }

        //        if (player.MoveDown())
        //        {

        //            flagDown = true;

        //        }


        //        #endregion
        //        if (flagRight == true && flagLeft == true && flagUp == true && flagDown == true && flagAttack == true && flagRun == true)
        //        {

        //            return true;

        //        }
        //        else 
        //        {
        //            return false;
        //        }
        //    }
        //}
        #endregion


        public override void HasCollidedWith(Entity collider)
        {
            if (collider.tag == Tags.Player.ToString())
            {
                tutorialFinished = true;
            }
            else
            {
                tutorialFinished = false;
            }
        }


        public override void Update(GameTime gameTime)
        {

            
            if (tutorialFinished == true)
            {
                LevelTutorial.RemoveContent();
                Level1.LoadContent();
            }

        }

        public override void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Draw(myTexture, myRectangle, Color.White);
        }
    }
}
