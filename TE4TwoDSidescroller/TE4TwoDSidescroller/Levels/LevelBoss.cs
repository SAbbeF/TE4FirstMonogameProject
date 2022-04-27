using System;
using System.Collections.Generic;
using System.Text;
using TE4TwoDSidescroller.Levels;

namespace TE4TwoDSidescroller
{
    class LevelBoss
    {

        public LevelBoss()
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
            Entity boss;
            Entity lastlvlText;

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

            levelGoal = new LevelGoals(5);
            GameInfo.entityManager.AddEntity(levelGoal);

            boss = new Boss();
            GameInfo.entityManager.AddEntity(boss);

            healthBar = new HealthBar();
            GameInfo.entityManager.AddEntity(healthBar);

            lastlvlText = new LastlvlText();
            GameInfo.entityManager.AddEntity(lastlvlText);
        }


        public static void RemoveContent()
        {

            GameInfo.entityManager.RemoveAllEntities();

        }
    }
}
