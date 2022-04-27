using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class PriestAttack : Entity
    {

        int attackWidth;
        int attackHeight;
        int movementSpeed;
        Texture2D priestAttackTexture;
        Vector2 projectileDirection;

        public PriestAttack(Character character)
        {

            projectileDirection = new Vector2();
            projectileDirection = character.movementDirection;

            attackWidth = 40;
            attackHeight = 20;

            movementSpeed = 4;

            isActive = true;
            hasCollider = true;
            tag = Tags.PriestAttack.ToString();

            if (!Priest.priestIsFacingRight)
            {

                collisionBox = new Rectangle((int)character.position.X + Priest.sourceRectangle.Width,
                    (int)character.position.Y + Priest.sourceRectangle.Height / 2,
                    attackWidth, attackHeight);


            }
            else
            {
                collisionBox = new Rectangle((int)character.position.X - Priest.sourceRectangle.Width,
                    (int)character.position.Y + Priest.sourceRectangle.Height / 2,
                    attackWidth, attackHeight);

                movementSpeed = movementSpeed * -1;
            }

            LoadPriestTexture2D();

            //animation = new Animation(priestAttackTexture, 4);
            //animation.isLooping = true;
            //animation.FramePerSecond = 5;

        }

        public void LoadPriestTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/" + "Box.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                priestAttackTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }

        //public override void HasCollidedWith(Entity collider)
        //{

        //    GameInfo.entityManager.RemoveEntity(this.uniqeId);

        //}
        //public void Animate()
        //{
        //    if (GameInfo.player1IsFacingRight)
        //    {
        //        animation.spriteEffects = SpriteEffects.None;
        //    }
        //    else
        //    {
        //        animation.spriteEffects = SpriteEffects.FlipHorizontally;
        //    }
        //}

        public override void Update(GameTime gameTime)
        {
            //projectileDirection.X += movementSpeed;
            //projectileDirection.Y += movementSpeed;


            collisionBox.X += movementSpeed;
            //collisionBox.Y += (int)projectileDirection.Y;

            //Animate();

            //animation.position.X = collisionBox.X;
            //animation.position.Y = collisionBox.Y - 50;
            //animation.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            GameInfo.spriteBatch.Draw(priestAttackTexture, collisionBox, Color.White);
            //animation.Draw(gameTime);
        }
    }



}


