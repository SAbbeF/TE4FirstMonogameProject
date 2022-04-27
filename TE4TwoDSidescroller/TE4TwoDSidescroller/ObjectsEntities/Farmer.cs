using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Farmer : Character
    {
        Animation animation;
        Dictionary<string, Animation> farmerDictionary;

        Health health;
        Texture2D farmerIdle;
        Texture2D farmerAttack;
        Texture2D farmerWalk;
        Texture2D farmerOuch;
        Vector2 myPosition;
        Rectangle sourceRectangle;
        bool hasTakenDamage;
        bool isAttacking;

        public static int farmerDamage;

        public Farmer(int myPosition1, int myPosition2)
        {
            characterInput = new FarmerInput(this);
            maxHealth = 50;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            movementSpeed = 2;
            jumpHeight = 3;



            hasCollider = true;
            isActive = true;

            LoadFarmerTexture();
            myPosition = new Vector2(myPosition1, myPosition2);

            sourceRectangle = new Rectangle(0, 0, 64, 96);
            myPosition = new Vector2(myPosition1, myPosition2);
            
            collisionBox = new Rectangle((int)myPosition.X, (int)myPosition.Y, 64, 96);
            health = new Health();

            FarmerDictionary();
            FarmerAnimation();
        }

        public void LoadFarmerTexture()
        {
            string currentPath = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/Enemies" + "/FarmerIdlePic.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                farmerIdle = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string Path1 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                 + "/Content/Pngs/Enemies/" + "FarmerAttackAnim.png";

            using (Stream textureStream = new FileStream(Path1, FileMode.Open))
            {
                farmerAttack = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string Path2 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/Enemies/" + "FarmerWalkAnim.png";

            using (Stream textureStream = new FileStream(Path2, FileMode.Open))
            {
                farmerWalk = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string Path3 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/Enemies/" + "FarmerOuchAnim.png";

            using (Stream textureStream = new FileStream(Path3, FileMode.Open))
            {
                farmerOuch = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }
        }

        public void FarmerDictionary()
        {
            farmerDictionary = new Dictionary<string, Animation>();

            Animation idle = new Animation(farmerIdle, 1);
            idle.isLooping = true;
            idle.FramePerSecond = 1;
            farmerDictionary.Add("idle", idle);

            Animation walkRight = new Animation(farmerWalk, 4);
            walkRight.isLooping = true;
            walkRight.FramePerSecond = 5;
            farmerDictionary.Add("walkRight", walkRight);

            Animation walkLeft = new Animation(farmerWalk, 4);
            walkLeft.isLooping = true;
            walkLeft.FramePerSecond = 5;
            walkLeft.spriteEffects = SpriteEffects.FlipHorizontally;
            farmerDictionary.Add("walkLeft", walkLeft);

            Animation attack = new Animation(farmerAttack, 6);
            attack.isLooping = true;
            attack.FramePerSecond = 8;
            farmerDictionary.Add("attack", attack);

            Animation flipAttack = new Animation(farmerAttack, 6);
            flipAttack.isLooping = true;
            flipAttack.FramePerSecond = 8;
            flipAttack.spriteEffects = SpriteEffects.FlipHorizontally;
            farmerDictionary.Add("flipAttack", flipAttack);

            Animation ouch = new Animation(farmerOuch, 3);
            ouch.isLooping = true;
            ouch.FramePerSecond = 10;
            farmerDictionary.Add("ouch", ouch);

            Animation flipOuch = new Animation(farmerOuch, 3);
            flipOuch.isLooping = true;
            flipOuch.FramePerSecond = 10;
            flipOuch.spriteEffects = SpriteEffects.FlipHorizontally;
            farmerDictionary.Add("flipOuch", flipOuch);
        }

        public void FarmerAnimation()
        {
            Animation tempIdle;
            Animation tempWalkRight;
            Animation tempWalkLeft;
            Animation tempOuch;
            Animation tempFlipOuch;
            Animation tempAttack;
            Animation tempFlipAttack;
 
            farmerDictionary.TryGetValue("idle", out tempIdle);
            farmerDictionary.TryGetValue("ouch", out tempOuch);
            farmerDictionary.TryGetValue("flipOuch", out tempFlipOuch);
            farmerDictionary.TryGetValue("attack", out tempAttack);
            farmerDictionary.TryGetValue("flipAttack", out tempFlipAttack);
            farmerDictionary.TryGetValue("walkRight", out tempWalkRight);
            farmerDictionary.TryGetValue("walkLeft", out tempWalkLeft);

            animation = tempIdle;
            if (hasTakenDamage && movementVector.X >= 0)
            {
                animation = tempOuch;
                hasTakenDamage = false;
            }

            else if (hasTakenDamage && movementVector.X <= 0)
            {
                animation = tempFlipOuch;
                hasTakenDamage = false;
            }

            else if (isAttacking && myPosition.X <= GameInfo.player1Position.X)
            {
                animation = tempAttack;
                isAttacking = false;
            }

            else if (isAttacking && myPosition.X >= GameInfo.player1Position.X)
            {
                animation = tempFlipAttack;
                isAttacking = false;
            }

            else if (movementVector.Y == 0 && movementVector.X >= 0)
            {
                animation = tempWalkRight;
            }

            else if (movementVector.Y == 0 && movementVector.X <= 0)
            {
                animation = tempWalkLeft;
            }

            else if (IsGrounded && movementVector.Y == 0 && movementVector.X == 0)
            {
                animation = tempIdle;
            }
        }

        public override void HasCollidedWith(Entity collider)
        {

            if (collider.tag == Tags.PlayerMeleeAttack.ToString())
            {
                hasTakenDamage = true;

                currentHealth = health.TakeDamage(currentHealth, Player.playerDamage, this);
            }

            if (collider.tag == Tags.PlayerRangeAttack.ToString())
            {
                hasTakenDamage = true;
                currentHealth = health.TakeDamage(currentHealth, Player.playerDamage, this);
            }

        }

        #region Actions

        public override void MoveRight()
        {

            myPosition.X += movementSpeed;
            if (SoundInput.soundEffectknigthWalkInstance.State != Microsoft.Xna.Framework.Audio.SoundState.Playing)
            {

                SoundInput.SoundEffectInstance(SoundInput.soundEffectknigthWalkInstance, 0.2f, -1f, 0.1f);

            }
        }

        public override void MoveLeft()
        {

            myPosition.X -= movementSpeed;
            if (SoundInput.soundEffectknigthWalkInstance.State != Microsoft.Xna.Framework.Audio.SoundState.Playing)
            {

                SoundInput.SoundEffectInstance(SoundInput.soundEffectknigthWalkInstance, 0.2f, -1f, 0.1f);

            }

        }

        public override void Attack1( )
        {



        }



        #endregion


        public override void Update(GameTime gameTime)
        {
            manaTick++;
            if (mana < manaCheck && manaTick == 15)
            {
                mana++;
                manaTick = 0;
            }



            myPosition += movementVector;
            FarmerDictionary();

            animation.position = myPosition;

            position = myPosition;

            collisionBox.X = (int)position.X;

            animation.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //GameInfo.spriteBatch.Draw(farmerIdle, myPosition, sourceRectangle , Color.White);
            animation.Draw(gameTime);
        }

    }
}
