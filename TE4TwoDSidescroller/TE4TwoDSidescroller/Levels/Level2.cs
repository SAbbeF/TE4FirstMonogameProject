using System;
using System.Collections.Generic;
using System.Text;
using TE4TwoDSidescroller.Levels;

namespace TE4TwoDSidescroller
{
    class Level2
    {

        public Level2()
        {


        }

        public static void LoadContent()
        {
            Entity healthBar;
            Entity background;
            Entity playerEntity;
            Entity floor;
            Entity camera;

            Entity levelGoal;

            Entity farmerOne;
            Entity farmerTwo;
            Entity platform;
            Entity platformTwo;
            Entity platformThree;
            Entity platformFour;
            Entity platformFive;
            Entity platformSix;
            Entity platformSeven;
            Entity platformEight;


            Entity deathZone = new DeathZone();
            GameInfo.entityManager.AddEntity(deathZone);

            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

            camera = new VisionManager();
            GameInfo.entityManager.AddEntity(camera);

            farmerOne = new Farmer(500, 610);
            GameInfo.entityManager.AddEntity(farmerOne);

            platform = new Platform(new Microsoft.Xna.Framework.Vector2(400, 350), 200, 40);
            GameInfo.entityManager.AddEntity(platform);

            platformTwo = new Platform(new Microsoft.Xna.Framework.Vector2(800, 550), 400, 40);
            GameInfo.entityManager.AddEntity(platformTwo);

            platformThree = new Platform(new Microsoft.Xna.Framework.Vector2(1350, 500), 200, 40);
            GameInfo.entityManager.AddEntity(platformThree);

            platformFour = new Platform(new Microsoft.Xna.Framework.Vector2(1800, 300), 200, 40);
            GameInfo.entityManager.AddEntity(platformFour);

            platformFive = new Platform(new Microsoft.Xna.Framework.Vector2(2400, 100), 20, 600);
            GameInfo.entityManager.AddEntity(platformFive);

            platformSix = new Platform(new Microsoft.Xna.Framework.Vector2(2400, 200), 350, 40);
            GameInfo.entityManager.AddEntity(platformSix);

            platformSeven = new Platform(new Microsoft.Xna.Framework.Vector2(2800, 550), 800, 30);
            GameInfo.entityManager.AddEntity(platformSeven);

            platformEight = new Platform(new Microsoft.Xna.Framework.Vector2(3600, 350), 400, 30);
            GameInfo.entityManager.AddEntity(platformEight);

            farmerTwo = new Farmer(400, 250);
            GameInfo.entityManager.AddEntity(farmerTwo);

            levelGoal = new LevelGoals(2);
            GameInfo.entityManager.AddEntity(levelGoal);

            healthBar = new HealthBar();
            GameInfo.entityManager.AddEntity(healthBar);

        }
        public static void RemoveContent()
        {

            GameInfo.entityManager.RemoveAllEntities();


        }

    }
}
