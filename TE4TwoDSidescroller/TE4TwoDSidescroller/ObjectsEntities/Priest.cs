using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Priest : Character
    {

        GameInformationSystem gameInfoSystem;

        private Texture2D priestTexture;
        public static Rectangle sourceRectangle;
        //static public Vector2 distanceBetweenPlayerAndPriest;
        //static public Vector2 priestPosition;
        protected Vector2 priestOrigin;
        protected Vector2 priestVelocity;
        protected Vector2 priestScale;
        protected float priestRotation;
        protected float priestJumpHeight;
        protected Vector2 priestRunningDistance; 

        private Health health;
        public static bool priestIsFacingRight;

        public static int priestDamage;

        public Priest()
        {

            characterInput = new PriestBehaviour(this);

            tag = Tags.Priest.ToString();

            IsGrounded = false;
            isActive = true;
            hasCollider = true;
            priestIsFacingRight = false;

            movementSpeed = 0.3f;
            maxHealth = 10;
            currentHealth = maxHealth;
            mana = 100;
            manaCheck = mana;
            manaTick = 0;
            priestDamage = 10;
            health = new Health();

            gameInfoSystem = new GameInformationSystem();

            sourceRectangle = new Rectangle(0, 0, 64, 96);
            position = new Vector2(500, 500);
            movementDirection = new Vector2();
            priestVelocity = new Vector2(0, 0);
            priestRunningDistance = new Vector2(200, 200);

            priestOrigin = new Vector2(0, 0);
            priestScale = new Vector2(1, 1);
            movementVector = new Vector2(0, 0);
            priestRotation = 0;

            collisionBox = new Rectangle(0, 0, 64, 96);

            LoadTexture2D();

            colorData = new Color[priestTexture.Width * priestTexture.Height];
            priestTexture.GetData(colorData);
        }

        public void LoadTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/Enemies/" + "PriestIdlePic.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                priestTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }


        public override void HasCollidedWith(Entity collider)
        {

            if (collider.tag == Tags.Floor.ToString())
            {
                IsGrounded = true;

            }


            if (collider.tag == Tags.PlayerMeleeAttack.ToString())
            {

                health.TakeDamage(currentHealth, Player.playerDamage, this);
            }

            if (collider.tag == Tags.PlayerRangeAttack.ToString())
            {
                health.TakeDamage(currentHealth, Player.playerDamage, this);
            }

        }

        #region Behaviour

        public override void MoveRight()
        {


            movementVector.X += movementSpeed;
            priestIsFacingRight = true;

        }

        public override void MoveLeft()
        {

            movementVector.X -= movementSpeed;
            priestIsFacingRight = false;
        }



        public override void Attack1()
        {

            Entity priestAttack = new PriestAttack(this);
            GameInfo.entityManager.AddEntity(priestAttack);
        }

        #endregion

        public override void Update(GameTime gameTime)
        {


            movementDirection = GameInfo.player1Position - position;

            priestVelocity = new Vector2(0, 0);
            priestJumpHeight = 0;

            position += movementVector;

            collisionBox.X = (int)position.X;
            collisionBox.Y = (int)position.Y;

            base.Update(gameTime);

            if (!IsGrounded)
            {

                increasingGravity += gameInfoSystem.gravity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            }

            priestVelocity.Y += increasingGravity - priestJumpHeight;

            movementVector += priestVelocity;


        }

        public override void Draw(GameTime gameTime)
        {


            GameInfo.spriteBatch.Draw(priestTexture, position, sourceRectangle,
                Color.White, priestRotation, priestOrigin, priestScale,
                SpriteEffects.None, 0f);


        }

    }
}
