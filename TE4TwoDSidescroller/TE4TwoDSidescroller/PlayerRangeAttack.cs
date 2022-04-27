using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    //få det att fungera först, optimera senare
    //Klassen är nästan indentisk till PlayerMelee

    class PlayerRangeAttack : Entity
    {
        private Animation animation;

        Texture2D playerAttackTexture;

        int attackWidth;
        int attackHeight;

        public PlayerRangeAttack()
        {

            attackWidth = 40;
            attackHeight = 20;

            movementSpeed = 4;

            isActive = true;
            hasCollider = true;
            tag = Tags.PlayerRangeAttack.ToString();

            if (GameInfo.player1IsFacingRight)
            {

                collisionBox = new Rectangle((int)GameInfo.player1Position.X + GameInfo.Player1TextureSize.Width,
                    (int)GameInfo.player1Position.Y + GameInfo.Player1TextureSize.Height / 2,
                    attackWidth, attackHeight);


            }
            else
            {
                collisionBox = new Rectangle((int)GameInfo.player1Position.X - GameInfo.Player1TextureSize.Width,
                    (int)GameInfo.player1Position.Y + GameInfo.Player1TextureSize.Height / 2,
                    attackWidth, attackHeight);

                movementSpeed = movementSpeed * -1;
            }

            LoadTexture2D();

            animation = new Animation(playerAttackTexture, 4);
            animation.isLooping = true;
            animation.FramePerSecond = 8;

        }

        public void LoadTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/MainCharacters/" + "ShadowStarAnim.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                playerAttackTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }

        public override void HasCollidedWith(Entity collider)
        {

            GameInfo.entityManager.RemoveEntity(this.uniqeId);
        }

        public void Animate()
        {
            if (GameInfo.player1IsFacingRight)
            {
                animation.spriteEffects = SpriteEffects.None;
            }
            else
            {
                animation.spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }

        public override void Update(GameTime gameTime)
        {

            collisionBox.X += (int)movementSpeed;

            Animate();

            animation.position.X = collisionBox.X;
            animation.position.Y = collisionBox.Y -50;

            animation.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            GameInfo.spriteBatch.Draw(playerAttackTexture, collisionBox, Color.White);
            animation.Draw(gameTime);
        }
    }

}


