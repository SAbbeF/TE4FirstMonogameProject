using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class HealthBar : Entity
    {
        //skapa rektangel i vänster hörn
        //ladda in två bilder ena är högre en den andra
        //koppla ihop med player hp
        //och uppdatera med rektangelns

        Rectangle healthBar;
        Rectangle healthBarBackground;

        Vector2 healtBarPosition;
        Vector2 healtBarBackgroundPosition;

        Texture2D healthBarBackgroundTexture;
        Texture2D healthBarTexture;
        

        Player player;

        float layer;
        float layerTwo;
        float scale;
        float rotation;


        public HealthBar()
        {
            player = new Player();

            scale = 1.1f;
            layer = 0.0001f; 
            layerTwo = 0.0002f;
            rotation = 0f;

            healtBarPosition.X = -50;
            healtBarPosition.Y = -50;
            healtBarBackgroundPosition.X = -45;
            healtBarBackgroundPosition.Y = -45;

            // healthBarTexture = content.Load<Texture2D>("Pngs/healthBar.png");

            #region FileLoads
            string currentPath =
          Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) 
          + "/Content/Pngs/" + "Box.png";

          using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
          {

                healthBarBackgroundTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

          }

            string secondPath =
            Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
            + "/Content/Pngs/" + "redBox.jpg";

            using (Stream textureStream = new FileStream(secondPath, FileMode.Open))
            {

                healthBarTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);

            }
            #endregion
            
            healthBar = new Rectangle((int)healtBarPosition.X, (int)healtBarPosition.Y, GameInfo.playerOneCurrentHealth * 2 , 50);
            healthBarBackground = new Rectangle((int)healtBarBackgroundPosition.X, (int)healtBarBackgroundPosition.Y, GameInfo.playerOneCurrentHealth * 2 + 10, 60);
        }

       

        public override void Update(GameTime gameTime)
        {

            healthBar.Width = GameInfo.playerOneCurrentHealth * 2;
    
            if (healthBarBackground.Width <= 10)
            {
                healthBarBackground.Width = GameInfo.playerOneCurrentHealth * 2 + 10;
            }
            
        }

        public override void Draw(GameTime gameTime)
        {

            GameInfo.spriteBatch.Draw(healthBarBackgroundTexture, GameInfo.viewportPosition, healthBarBackground, Color.White, rotation, healtBarBackgroundPosition, scale, SpriteEffects.None, layer);
            GameInfo.spriteBatch.Draw(healthBarTexture, GameInfo.viewportPosition, healthBar, Color.White, rotation, healtBarPosition, scale, SpriteEffects.None, layerTwo);

        }
    }
}
