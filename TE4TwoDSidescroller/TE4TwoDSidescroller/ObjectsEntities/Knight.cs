using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Knight : Character
    {


        GameInformationSystem gameInfoSystem;

        Animation animation;
        Dictionary<string, Animation> knightDictionary;

        private Texture2D knightWalk;
        private Texture2D knightJump;
        private Texture2D knightOuch;
        private Texture2D knightIdle;
        private Texture2D knightAttack;

        public static Rectangle sourceRectangle;

        //public  Vector2 knightPosition;
        private Vector2 knightOrigin;
        private Vector2 knightVelocity;
        private Vector2 knightScale;
        private float knightRotation;
        private float knightJumpHeight;
        private Vector2 trackingDistance;


        private Health health;

        public static bool knightIsFacingRight;
        bool isWalkingRight;
        bool hasTakenDamage;
        bool isAttacking;

        public static int knightDamage;


        public Knight(float spawnPositionX,float spawnPositionY)
        {

            characterInput = new KnightBehaviour(this);

            tag = Tags.Knight.ToString();

            IsGrounded = false;
            isActive = true;
            hasCollider = true;
            knightIsFacingRight = true;
            

             

            movementSpeed = 0.7f;
            maxHealth = 20;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            health = new Health();
            knightDamage = 0;

            gameInfoSystem = new GameInformationSystem();

            sourceRectangle = new Rectangle(0, 0, 64, 96);
            position = new Vector2(spawnPositionX, spawnPositionY);
            movementDirection = new Vector2();
            knightVelocity = new Vector2(0, 0);

            knightOrigin = new Vector2(0, 0);
            knightScale = new Vector2(1, 1);
            movementVector = new Vector2(0, 0);
            knightRotation = 0;
            trackingDistance = new Vector2(300, 300);

            collisionBox = new Rectangle(0, 0, 64, 96);

            LoadTexture2D();

            KnightDictionary();
            KnightAnimation();

            colorData = new Color[knightWalk.Width * knightWalk.Height];
            knightWalk.GetData(colorData);




        }

        public void LoadTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/Enemies/" + "KnightWalkAnim.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                knightWalk = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string Path4 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/Enemies/" + "KnightJumpAnim.png";

            using (Stream textureStream = new FileStream(Path4, FileMode.Open))
            {
                knightJump = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string Path1 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/Enemies/" + "KnightAttackAnim.png";

            using (Stream textureStream = new FileStream(Path1, FileMode.Open))
            {
                knightAttack = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string Path2 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/Enemies/" + "KnightIdlePic.png";

            using (Stream textureStream = new FileStream(Path2, FileMode.Open))
            {
                knightIdle = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string Path3 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/Enemies/" + "KnightOuchAnim.png";

            using (Stream textureStream = new FileStream(Path3, FileMode.Open))
            {
                knightOuch = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }

        public void KnightDictionary()
        {
            knightDictionary = new Dictionary<string, Animation>();

            Animation baseAnimation = new Animation(knightIdle, 1);
            baseAnimation.isLooping = true;
            baseAnimation.FramePerSecond = 1;
            knightDictionary.Add("base", baseAnimation);

            Animation walkRight = new Animation(knightWalk, 4);
            walkRight.isLooping = true;
            walkRight.FramePerSecond = 5;
            knightDictionary.Add("walkRight", walkRight);

            Animation walkLeft = new Animation(knightWalk, 4);
            walkLeft.isLooping = true;
            walkLeft.FramePerSecond = 5;
            walkLeft.spriteEffects = SpriteEffects.FlipHorizontally;
            knightDictionary.Add("walkLeft", walkLeft);

            Animation jump = new Animation(knightJump, 10);
            jump.isLooping = true;
            jump.FramePerSecond = 7;
            knightDictionary.Add("jump", jump);

            Animation flipJump = new Animation(knightJump, 10);
            flipJump.isLooping = true;
            flipJump.FramePerSecond = 7;
            flipJump.spriteEffects = SpriteEffects.FlipHorizontally;
            knightDictionary.Add("flipJump", flipJump);

            Animation attack = new Animation(knightAttack, 4);
            attack.isLooping = true;
            attack.FramePerSecond = 5;
            knightDictionary.Add("attack", attack);

            Animation flipAttack = new Animation(knightAttack, 4);
            flipAttack.isLooping = true;
            flipAttack.FramePerSecond = 1;
            flipAttack.spriteEffects = SpriteEffects.FlipHorizontally;
            knightDictionary.Add("flipAttack", flipAttack);

            Animation ouch = new Animation(knightOuch, 3);
            ouch.isLooping = true;
            ouch.FramePerSecond = 1;
            knightDictionary.Add("ouch", ouch);

            Animation flipOuch = new Animation(knightOuch, 3);
            flipOuch.isLooping = true;
            flipOuch.FramePerSecond = 10;
            flipOuch.spriteEffects = SpriteEffects.FlipHorizontally;
            knightDictionary.Add("flipOuch", flipOuch);
        }

        public void KnightAnimation()
        {
            Animation tempBase;
            Animation tempWalkRight;
            Animation tempWalkLeft;
            Animation tempIdle;
            Animation tempJump;
            Animation tempFlipJump;
            Animation tempOuch;
            Animation tempFlipOuch;
            Animation tempAttack;
            Animation tempFlipAttack;

            knightDictionary.TryGetValue("base", out tempBase);
            knightDictionary.TryGetValue("idle", out tempIdle);
            knightDictionary.TryGetValue("jump", out tempJump);
            knightDictionary.TryGetValue("ouch", out tempOuch);
            knightDictionary.TryGetValue("flipOuch", out tempFlipOuch);
            knightDictionary.TryGetValue("flipJump", out tempFlipJump);
            knightDictionary.TryGetValue("attack", out tempAttack);
            knightDictionary.TryGetValue("flipAttack", out tempFlipAttack);
            knightDictionary.TryGetValue("walkRight", out tempWalkRight);
            knightDictionary.TryGetValue("walkLeft", out tempWalkLeft);

            animation = tempBase;
            if (hasTakenDamage && movementVector.X >= 0)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempOuch;
                hasTakenDamage = false;
            }

            else if (hasTakenDamage && movementVector.X <= 0)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempFlipOuch;
                hasTakenDamage = false;
            }

            else if (isAttacking && position.X <= GameInfo.player1Position.X)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempAttack;
                isAttacking = false;
            }

            else if (isAttacking && position.X >= GameInfo.player1Position.X)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempFlipAttack;
                isAttacking = false;
            }

            else if (movementVector.Y == 0 && movementVector.X >= 0)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempWalkRight;
            }

            else if (movementVector.Y == 0 && movementVector.X <= 0)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempWalkLeft;
            }

            else if (!IsGrounded && (movementVector.Y != 0 && movementVector.X >= 0))
            {
                tempFlipJump.frameIndex = 0;

                animation = tempJump;

            }

            else if (!IsGrounded && (movementVector.Y != 0 && movementVector.X <= 0))
            {
                tempJump.frameIndex = 0;

                animation = tempFlipJump;
            }

            else if (IsGrounded && movementVector.Y == 0 && movementVector.X == 0)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempBase;
            }

        }

        public override void HasCollidedWith(Entity collider)
        {

            if (collider.tag == Tags.Floor.ToString())
            {
                IsGrounded = true;

            }

            if (canTakeDamage && collider.tag == Tags.PlayerMeleeAttack.ToString())
            {

                hasTakenDamage = true;
                currentHealth = health.TakeDamage(currentHealth, Player.playerDamage, this);
                canTakeDamage = false;

            }

            if (collider.tag == Tags.PlayerRangeAttack.ToString())
            {
                hasTakenDamage = true;

                currentHealth = health.TakeDamage(currentHealth, Player.playerDamage, this);
            }

        }

        #region Behaviour

        public override void MoveRight()
        {
            movementVector.X += movementSpeed;
            knightIsFacingRight = true;


            isWalkingRight = true;

        }

        public override void MoveLeft()
        {
            movementVector.X -= movementSpeed;
            knightIsFacingRight = false;


            isWalkingRight = false;

        }

        //public override void Jump(GameTime gameTime)
        //{
        //    if (IsGrounded)
        //    {
        //        IsGrounded = false;
        //        movementVector.Y -= movementSpeed * 50;
        //    }
        //}


        public override void Attack1()
        {
            Entity knightAttack = new KnightAttack(this);
            GameInfo.entityManager.AddEntity(knightAttack);
            isAttacking = true;
           
        }

        #endregion

        public override void Update(GameTime gameTime)
        {
            #region Controls for testing
            //if (Keyboard.GetState().IsKeyDown(Keys.Left))
            //{
            //    knightPosition.X -= movementSpeed;
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Right))
            //{
            //    knightPosition.X += movementSpeed;
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Down))
            //{
            //    knightPosition.Y += movementSpeed;
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //    knightPosition.Y -= movementSpeed;
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Space))
            //{
            //    knightPosition.Y = 0;
            //    knightPosition.X = 0;

            //}
            #endregion

            InvincibilityFrames(gameTime);

            movementDirection = GameInfo.player1Position - position;

            knightVelocity = new Vector2(0, 0);
            position += movementVector;

            KnightAnimation();

            animation.position = position;
            animation.Update(gameTime);


            base.Update(gameTime);

            if (!IsGrounded)
            {
                increasingGravity += gameInfoSystem.gravity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            knightVelocity.Y += increasingGravity - knightJumpHeight;

            movementVector += knightVelocity;

            collisionBox.X = (int)position.X;
            collisionBox.Y = (int)position.Y;


        }

        public override void Draw(GameTime gameTime)
        {

            //GameInfo.spriteBatch.Draw(knightTexture, knightPosition, sourceRectangle,
            //    Color.White, knightRotation, knightOrigin, knightScale,
            //    SpriteEffects.None, 0f);

            animation.Draw(gameTime);

            // base.Draw(gameTime);
        }

    }
}