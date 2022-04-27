using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    public class ScreenManager
    {


        public void Resolution(int screenSizeChoice)
        {

            if (screenSizeChoice == 1)
            {

                GameInfo.graphicsDevice.PreferredBackBufferWidth = 1280;
                GameInfo.graphicsDevice.PreferredBackBufferHeight = 720;
                GameInfo.graphicsDevice.ApplyChanges();
            }

            if (screenSizeChoice == 2)
            {

                GameInfo.graphicsDevice.PreferredBackBufferWidth = 1024;
                GameInfo.graphicsDevice.PreferredBackBufferHeight = 576;
                GameInfo.graphicsDevice.ApplyChanges();

            }



        }




    }
}
