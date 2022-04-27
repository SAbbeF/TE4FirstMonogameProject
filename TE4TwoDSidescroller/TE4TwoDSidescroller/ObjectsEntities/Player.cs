using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TE4TwoDSidescroller
{

    //:D
    class Player : Character
    {
        #region Variables/Fields
        public Texture2D currentTexture;
        private Texture2D playerRunRight;
        private Texture2D playerIdle;
        private Texture2D playerJump;
        private Texture2D playerOuch;

        Health health;

        private Rectangle playerSourceRectangle;
        private Vector2 playerPosition;
        private Vector2 playerVelocity;

        private Rectangle detectionHitBox;

        private Vector2 playerScale;
        private float playerRotation;
        private Vector2 playerOrigin;

        private float moveSpeed;
        private float runSpeed;
        private float walkSpeed;

        float deltaTime;
        float time;



        bool isWalkingRight;
        bool isWalkingLeft;
        bool isJumping;
        public bool isFacingRight;
        bool hasTakenDamage;

        bool rightSideCollision;
        bool leftSideCollision;
        bool topSideCollision;
        bool bottomSidecollison;

        public static int playerDamage;

        #endregion

        public Player()
        {

            tag = Tags.Player.ToString();
            characterInput = new PlayerInput(this);

            health = new Health();

            playerSourceRectangle = new Rectangle(0, 0, 67, 96); // 256 * 96 - 64/67

            playerVelocity = new Vector2(0, 0);
            movementVector = new Vector2(0, 0);

            playerScale = new Vector2(1, 1);
            playerRotation = 0;
            playerOrigin = new Vector2(0, 0);

            playerPosition = new Vector2(0, 0);

            moveSpeed = 2;
            walkSpeed = 2;
            runSpeed = 4;

            IsGrounded = false;
            hasCollider = true;
            isActive = true;
            isFacingRight = true;


            collisionBox = new Rectangle(0, 0, playerSourceRectangle.Width, playerSourceRectangle.Height);


            LoadPlayerTexture2D();
            PlayerDictionary();
            Animate();

            maxHealth = 200;
            currentHealth = maxHealth;

            mana = 200;
            manaCheck = mana;
            manaTick = 0;
            playerDamage = 10;

        }

        public Vector2 PlayerPosition
        {
            get
            {
                return playerPosition;
            }
            set
            {
                playerPosition = value;
            }
        }

        public Texture2D CurrentTexture
        {
            get
            {
                return currentTexture;
            }
            set
            {
                currentTexture = value;
            }
        }

        public void LoadPlayerTexture2D()
        {
            string path2 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/MainCharacters/" + "ShadowIdleAnim.png";
            using (Stream textureStream = new FileStream(path2, FileMode.Open))
            {
                playerIdle = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string path3 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/MainCharacters/" + "ShadowJumpAnim.png";
            using (Stream textureStream = new FileStream(path3, FileMode.Open))
            {
                playerJump = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string currentPath = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/MainCharacters/" + "ShadowRunRight.png";
            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                playerRunRight = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string path4 = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location)
                + "/Content/Pngs/MainCharacters/" + "ShadowOuchAnim.png";
            using (Stream textureStream = new FileStream(path4, FileMode.Open))
            {
                playerOuch = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }
        }

        public void PlayerDictionary()
        {
            animations = new Dictionary<string, Animation>();

            Animation baseAnimation = new Animation(playerIdle, 4);
            baseAnimation.FramePerSecond = 4;
            animations.Add("base", baseAnimation);

            Animation runRight = new Animation(playerRunRight, 4);
            runRight.isLooping = true;
            runRight.FramePerSecond = 5;
            animations.Add("runRight", runRight);

            Animation runLeft = new Animation(playerRunRight, 4);
            runLeft.isLooping = true;
            runLeft.FramePerSecond = 5;
            runLeft.spriteEffects = SpriteEffects.FlipHorizontally;
            animations.Add("runLeft", runLeft);

            Animation idle = new Animation(playerIdle, 4);
            idle.isLooping = true;
            idle.FramePerSecond = 5;
            animations.Add("idle", idle);

            Animation flipIdle = new Animation(playerIdle, 4);
            flipIdle.isLooping = true;
            flipIdle.FramePerSecond = 5;
            flipIdle.spriteEffects = SpriteEffects.FlipHorizontally;
            animations.Add("flipIdle", flipIdle);

            Animation jump = new Animation(playerJump, 21);
            jump.isLooping = true;
            jump.FramePerSecond = 14;
            animations.Add("jump", jump);

            Animation flipJump = new Animation(playerJump, 21);
            flipJump.isLooping = true;
            flipJump.FramePerSecond = 14;
            flipJump.spriteEffects = SpriteEffects.FlipHorizontally;
            animations.Add("flipJump", flipJump);

            Animation ouch = new Animation(playerOuch, 3);
            ouch.isLooping = true;
            ouch.FramePerSecond = 10;
            animations.Add("ouch", ouch);

            Animation flipOuch = new Animation(playerOuch, 3);
            flipOuch.isLooping = false;
            flipOuch.FramePerSecond = 8;
            flipOuch.spriteEffects = SpriteEffects.FlipHorizontally;
            animations.Add("flipOuch", flipOuch);
        }

        public void Animate()
        {
            Animation tempBase;
            Animation tempRunRight;
            Animation tempRunLeft;
            Animation tempIdle;
            Animation tempFlipIdle;
            Animation tempJump;
            Animation tempFlipJump;
            Animation tempOuch;
            Animation tempFlipOuch;

            animations.TryGetValue("base", out tempBase);
            animations.TryGetValue("idle", out tempIdle);
            animations.TryGetValue("flipIdle", out tempFlipIdle);
            animations.TryGetValue("jump", out tempJump);
            animations.TryGetValue("ouch", out tempOuch);
            animations.TryGetValue("flipOuch", out tempFlipOuch);
            animations.TryGetValue("flipJump", out tempFlipJump);
            animations.TryGetValue("runRight", out tempRunRight);
            animations.TryGetValue("runLeft", out tempRunLeft);

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

            else if (IsGrounded && movementVector.Y == 0 && movementVector.X == 0 && isWalkingRight)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;


                animation = tempIdle;

            }

            else if (IsGrounded && movementVector.Y == 0 && movementVector.X == 0 && !isWalkingRight)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempFlipIdle;
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

            else if (movementVector.Y == 0 && movementVector.X >= 0)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempRunRight;

            }

            else if (movementVector.Y == 0 && movementVector.X <= 0)
            {
                tempJump.frameIndex = 0;
                tempFlipJump.frameIndex = 0;

                animation = tempRunLeft;

            }
        }

        public override void HasCollidedWith(Entity collider)
        {

            if (collider.tag != Tags.KnightAttack.ToString() && 
                collider.tag != Tags.PlayerMeleeAttack.ToString() &&
                collider.tag != Tags.PriestAttack.ToString() &&
                collider.tag != Tags.BossAttack.ToString() &&
                collider.tag != Tags.BossAttack1.ToString())
            {

            #region Right
            if (collisionBox.Left + movementVector.X < collider.collisionBox.Right &&
                collisionBox.Right > collider.collisionBox.Right &&
                collisionBox.Bottom > collider.collisionBox.Top &&
                collisionBox.Top < collider.collisionBox.Bottom)
            {
                rightSideCollision = true;
            }

            #endregion

            #region Left 
            if (collisionBox.Right + movementVector.X > collider.collisionBox.Left &&
                collisionBox.Left < collider.collisionBox.Left &&
                collisionBox.Bottom > collider.collisionBox.Top &&
                collisionBox.Top < collider.collisionBox.Bottom)
            {
                leftSideCollision = true;
            }

            #endregion

            #region Top
            if (collisionBox.Bottom + movementVector.Y > collider.collisionBox.Top &&
                collisionBox.Top < collider.collisionBox.Top &&
                collisionBox.Right > collider.collisionBox.Left &&
                collisionBox.Left < collider.collisionBox.Right)
            {
                topSideCollision = true;
            }

            #endregion

            #region Bottom
            if (collisionBox.Top + movementVector.Y < collider.collisionBox.Bottom &&
                collisionBox.Bottom > collider.collisionBox.Bottom &&
                collisionBox.Right > collider.collisionBox.Left &&
                collisionBox.Left < collider.collisionBox.Right)
            {
                bottomSidecollison = true;
            }


            #endregion

            }

            if (topSideCollision)
            {
                IsGrounded = true;

            }

            if (collider.tag == Tags.KnightAttack.ToString())
            {
                currentHealth = health.TakeDamage(currentHealth, Knight.knightDamage, this);
                hasTakenDamage = true;
                GameInfo.playerOneCurrentHealth = currentHealth;

                //SoundInput.SoundEffectInstance(SoundInput.evilLaugh, 0.9f, 0.1f, 0.1f);

                if (SoundInput.soundEffectevilLaughInstance.State != SoundState.Playing)
                {

                    SoundInput.SoundEffectInstance(SoundInput.soundEffectevilLaughInstance, 0.9f, 0.1f, 0.1f);

                }
                //SoundInput.SoundEffectPlayed(SoundInput.evilLaugh , 0.9f, 0.1f, 0.1f);
            }

            if (collider.tag == Tags.DeathZone.ToString())
            {

                currentHealth = health.TakeDamage(currentHealth, 9999, this);

            }

            if (collider.tag == Tags.PriestAttack.ToString())
            {
                currentHealth = health.TakeDamage(currentHealth, Priest.priestDamage, this);
                hasTakenDamage = true;
                GameInfo.playerOneCurrentHealth = currentHealth;
            }

            #region collison
            // Problemet är att det funkar liksom "OnCollisionStay" i unity,
            //så hälsan minskar några gånger när det kolliderar en gång

            //if (collider.tag == Tags.BossAttack.ToString())
            //{
            //    currentHealth = health.TakeDamage(currentHealth, Boss.bossAttackdmg, this);
            //    hasTakenDamage = true;

            //    //GameInfo.entityManager.RemoveEntity();
            //}
            //if (collider.tag == Tags.BossAttack1.ToString())
            //{
            //    currentHealth = health.TakeDamage(currentHealth, Boss.bossAttack1dmg, this);
            //    hasTakenDamage = true;
            //    //GameInfo.entityManager.RemoveEntity();

            //}
            #endregion

            if (BossAttack.damage == true)
            {
                currentHealth = health.TakeDamage(currentHealth, Boss.bossAttackdmg, this);
                hasTakenDamage = true;
                BossAttack.damage = false;
                GameInfo.playerOneCurrentHealth = currentHealth;
            }
            if (BossAttack1.damage1 == true)
            {
                currentHealth = health.TakeDamage(currentHealth, Boss.bossAttack1dmg, this);
                hasTakenDamage = true;
                BossAttack1.damage1 = false;
                GameInfo.playerOneCurrentHealth = currentHealth;
            }

        }

        #region Input

        public override void Reset()
        {
            playerPosition = new Vector2(200, 50);
            IsGrounded = false;
        }

        //public override void MoveUp()
        //{
        //    movementVector.Y -= moveSpeed;
        //    //Modife later to implant accelartion and friction. (acceleration - friction * movementVector.Y)
        //}

        //public override void MoveDown()
        //{
        //    movementVector.Y += moveSpeed;
        //}

        public override void MoveLeft()
        {
            movementVector.X -= moveSpeed;

            isWalkingRight = false;
            isFacingRight = false;
            if (SoundInput.soundEffectknigthWalkInstance.State != SoundState.Playing && IsGrounded == true)
            {

                SoundInput.SoundEffectInstance(SoundInput.soundEffectknigthWalkInstance, 0.3f, 0.1f, 0.1f);

            }
        }

        public override void MoveRight()
        {
            movementVector.X += moveSpeed;

            isWalkingRight = true;
            isFacingRight = true;
            if (SoundInput.soundEffectknigthWalkInstance.State != SoundState.Playing && IsGrounded == true)
            {

                SoundInput.SoundEffectInstance(SoundInput.soundEffectknigthWalkInstance, 0.3f, 0.1f, 0.1f);

            }
        }

        public override void Run()
        {
            moveSpeed = runSpeed;
        }

        public override void DoNotRun()
        {
            moveSpeed = walkSpeed;
        }

        public override void Jump(GameTime gameTime)
        {
            movementVector.Y -= moveSpeed + 1;
            if (SoundInput.soundEffectmainCharacterJumpInstance.State != SoundState.Playing && IsGrounded == true)
            {

                SoundInput.SoundEffectInstance(SoundInput.soundEffectmainCharacterJumpInstance, 1f, 0.1f, 0.1f);

            }
            IsGrounded = false;


        }

        public override void Attack1()
        {

            GameInfo.creationManager.InitializePlayerMeleeAttack();
            if (SoundInput.soundEffectswordSwooshInstance.State != Microsoft.Xna.Framework.Audio.SoundState.Playing)
            {

                SoundInput.SoundEffectInstance(SoundInput.soundEffectswordSwooshInstance, 0.9f, 0.1f, 0.1f);

            }
        }

        public override void Attack2()
        {
            GameInfo.creationManager.InitializePlayerRangeAttack();
        }

        #endregion



        public override void Update(GameTime gameTime)
        {
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            playerVelocity = new Vector2(0, 0);
            playerPosition += movementVector;

            Animate();

            animation.position = playerPosition;
            animation.Update(gameTime);

            GameInfo.player1Position = playerPosition;
            GameInfo.Player1TextureSize = playerSourceRectangle;
            GameInfo.player1IsFacingRight = isFacingRight;
            GameInfo.playerOneCurrentHealth = currentHealth;

            base.Update(gameTime);

            if (!IsGrounded)
            {
                increasingGravity += GameInfo.gameInformationSystem.gravity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            collisionBox.X = (int)playerPosition.X;
            collisionBox.Y = (int)playerPosition.Y;

            playerVelocity.Y += increasingGravity;
            movementVector += playerVelocity;

            if ((movementVector.X > 0 && leftSideCollision) ||
                (movementVector.X < 0 && rightSideCollision))
            {
                movementVector.X = 0;
            }

            if ((movementVector.Y > 0 && topSideCollision) ||
                (movementVector.Y < 0 && bottomSidecollison))
            {
                movementVector.Y = 0;
            }

            leftSideCollision = false;
            rightSideCollision = false;
            topSideCollision = false;
            bottomSidecollison = false;

            IsGrounded = false;

            #region Harry's Code
            manaTick++;
            if (mana < manaCheck && manaTick == 15)
            {
                mana++;
                manaTick = 0;
            }

            //gör en bool som checkar ifall du kan checka enemy collision
            //så när du blir skadad slår du av den för 0.5 sek

            //ifall fienders vapen overlappar med kroppen så ta skada
            /* if (true)
             {
                 character.TakeDamage(currentHEalth, 10);
             }*/

            #endregion
        }

        public override void Draw(GameTime gameTime)
        {
            //GameInfo.spriteBatch.Draw(currentTexture, playerPosition, playerSourceRectangle, Color.White, playerRotation, playerOrigin, playerScale, SpriteEffects.None, 0.0f);
            animation.Draw(gameTime);
        }
    }
}