using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace TE4TwoDSidescroller
{
    class Boss : Character
    {
        #region variable
        static SpriteFont font;
        private string text;
        public Texture2D bossTexture;
        public Vector2 bossPosition;
        Health health;
        public static int bossAttackdmg;
        public static int bossAttack1dmg;
        bool hasTakenDamage;

        private Texture2D bossIdle;
        private Texture2D bossOuch;
        private Texture2D bossAttack1;
        private Texture2D bossAttack2;
        private Texture2D bigRockTexture;
        #endregion

        public Boss()
        {

            characterInput = new BossBehaviour(this);
            bossPosition = new Vector2(3250, 410);
            health = new Health();
            maxHealth = 500;
            currentHealth = maxHealth;
            tag = Tags.Boss.ToString();
            bossAttackdmg = 70;
            bossAttack1dmg = 50;
            LoadBossTextrue2D();
            BossDictionary();
            Animate();
            collisionBox = new Rectangle((int)bossPosition.X, (int)bossPosition.Y,
                                          bossIdle.Width *2, bossIdle.Height *3);
            hasCollider = true;
        }

        #region LoadTextrue
        public void LoadBossTextrue2D()
        {
            string bossPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies" + "/GodIdlePic.png";

            using (Stream textureStream = new FileStream(bossPath, FileMode.Open))
            {
                bossIdle = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string bossPath1 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies" + "/GodOuchAnim.png";

            using (Stream textureStream = new FileStream(bossPath1, FileMode.Open))
            {
                bossOuch = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string bossPath2 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies" + "/GodAttackAnim.png";

            using (Stream textureStream = new FileStream(bossPath2, FileMode.Open))
            {
                bossAttack1 = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string bossPath3 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies" + "/GodAttackAnimTwo.png";

            using (Stream textureStream = new FileStream(bossPath3, FileMode.Open))
            {
                bossAttack2 = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

            string bossPath4 = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/Content/Pngs/Enemies" + "/BigRock.png";

            using (Stream textureStream = new FileStream(bossPath4, FileMode.Open))
            {
                bigRockTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }
        }
        #endregion

        public void BossDictionary()
        {
            animations = new Dictionary<string, Animation>();

            Animation idle = new Animation(bossIdle, 1);
            idle.FramePerSecond = 1;
            idle.scale = 3f;
            animations.Add("idle", idle);

            Animation ouch = new Animation(bossOuch, 3);
            ouch.isLooping = true;
            ouch.FramePerSecond = 10;
            ouch.scale = 3f;
            animations.Add("ouch", ouch);

            Animation attackOne = new Animation(bossAttack1, 4);
            attackOne.isLooping = true;
            attackOne.FramePerSecond = 5;
            attackOne.scale = 3f;
            animations.Add("attackOne", attackOne);

            Animation attackTwo = new Animation(bossAttack2, 4);
            attackTwo.isLooping = true;
            attackTwo.FramePerSecond = 5;
            attackTwo.scale = 3f;
            animations.Add("attackTwo", attackTwo);

            Animation bigRock = new Animation(bigRockTexture, 4);
            bigRock.isLooping = true;
            bigRock.FramePerSecond = 5;
            animations.Add("bigRock", bigRock);

        }

        public void Animate()
        {
            Animation tempIdle;
            Animation tempOuch;
            Animation tempAttackOne;
            Animation tempAttackTwo;
            Animation tempBigRock;

            animations.TryGetValue("idle", out tempIdle);
            animations.TryGetValue("ouch", out tempOuch);
            animations.TryGetValue("attackOne", out tempAttackOne);
            animations.TryGetValue("attackTwo", out tempAttackTwo);
            animations.TryGetValue("bigRock", out tempBigRock);

            animation = tempAttackOne;

        }


        #region Collision
        public override void HasCollidedWith(Entity collider)
        {

            if (collider.tag == Tags.PlayerMeleeAttack.ToString())
            {
                currentHealth = health.TakeDamage(currentHealth, Player.playerDamage, this);
                hasTakenDamage = true;
            }

            if (collider.tag == Tags.PlayerRangeAttack.ToString())
            {
                currentHealth = health.TakeDamage(currentHealth, Player.playerDamage, this);
                hasTakenDamage = true;
            }
        }
        #endregion

        public override void Attack1()
        {
            Entity BossAttack = new BossAttack(this);
            GameInfo.entityManager.AddEntity(BossAttack);
        }

        public override void Attack2()
        {
            Entity BossAttack1 = new BossAttack1(this);
            GameInfo.entityManager.AddEntity(BossAttack1);
        }

        public override void Update(GameTime gameTime)
        {
            GameInfo.bossPosition = bossPosition;
            Animate();
            animation.position = bossPosition;
            animation.Update(gameTime);
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            //GameInfo.spriteBatch.Draw(bossIdle, bossPosition, Color.White);
            animation.Draw(gameTime);
        }
    }
}
