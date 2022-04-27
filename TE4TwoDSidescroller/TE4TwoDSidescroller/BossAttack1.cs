using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class BossAttack1 : Entity
    {
        Texture2D heavyAttackTexture;
        private int attackWidth;
        private int attackHeight;
        private int attackSpeed;
        public static bool damage1;

        public BossAttack1(Character character)
        {
            tag = Tags.BossAttack1.ToString();
            hasCollider = true;
            attackWidth = 50;
            attackHeight = 50;
            attackSpeed = 5;
            damage1 = false;


            collisionBox = new Rectangle((int)GameInfo.bossPosition.X, (int)GameInfo.bossPosition.Y +190,
            attackWidth, attackHeight);

            LoadTextrue();
        }

        public void LoadTextrue()
        {
            string currentPath =
             Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs" + "/redBox.jpg";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                heavyAttackTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }
        }

        public override void HasCollidedWith(Entity collider)
        {
            if (collider.tag == Tags.Player.ToString())
            {
                GameInfo.entityManager.RemoveEntity(this.uniqeId);
                damage1 = true;
            }
        }

        public override void Update(GameTime gameTime)
        {
            collisionBox.X -= attackSpeed;
        }

        public override void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Draw(heavyAttackTexture, collisionBox, Color.White);
        }
    }
}
