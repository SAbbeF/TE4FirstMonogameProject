using System;
using System.Collections.Generic;
using System.Text;
using TE4TwoDSidescroller.Levels;
using Microsoft.Xna.Framework;

namespace TE4TwoDSidescroller
{
    class Level1
    {

        public Level1()
        {


        }


        public static void LoadContent()
        {
            Entity healthBar;
            Entity background;
            Entity playerEntity;
            Entity floor;
            Entity camera;

            Entity farmer;
            Entity farmerTwo;
            Entity farmerThree;
            Entity farmerFour;
            Entity farmerFive;

            Entity platform;
            Entity platformTwo;
            Entity platformThree;
            Entity platformFour;
            Entity platformFive;
            Entity platformSix;
            Entity platformSeven;
            Entity platformEight;

            Entity levelGoal;

            Entity deathZone = new DeathZone();
            GameInfo.entityManager.AddEntity(deathZone);

            background = new Background();
            GameInfo.entityManager.AddEntity(background);

            playerEntity = new Player();
            GameInfo.entityManager.AddEntity(playerEntity);

            floor = new Floor();
            GameInfo.entityManager.AddEntity(floor);

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

            camera = new VisionManager();
            GameInfo.entityManager.AddEntity(camera);

            farmer = new Farmer(500, 610);
            GameInfo.entityManager.AddEntity(farmer);

            farmerTwo = new Farmer(1000, 610);
            GameInfo.entityManager.AddEntity(farmerTwo);

            farmerThree = new Farmer(1500, 610);
            GameInfo.entityManager.AddEntity(farmerThree);

            farmerFour = new Farmer(2000, 610);
            GameInfo.entityManager.AddEntity(farmerFour);

            farmerFive = new Farmer(2500, 610);
            GameInfo.entityManager.AddEntity(farmerFive);

            levelGoal = new LevelGoals(1);
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
