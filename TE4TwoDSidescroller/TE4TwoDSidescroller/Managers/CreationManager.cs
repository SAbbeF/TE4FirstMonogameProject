using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace TE4TwoDSidescroller
{
    public class CreationManager
    {
        Menu menu;
        public GameTime spawnTimer;
        public CreationManager()
        {



        }

        public void Initialize()
        {
            menu = new Menu();
            GameInfo.entityManager.AddEntity(menu);
            //LevelTutorial.LoadContent();

        }

        public void StartLevel(int level)
        {

            if (level == 0)
            {

                LevelTutorial.LoadContent();

            }

            if (level == 1)
            {

                Level1.LoadContent();

            }

            if (level == 2)
            {

                Level2.LoadContent();

            }

            if (level == 3)
            {

                Level3.LoadContent();

            }


        }

        public void InitializePlayerMeleeAttack()
        {

            Entity attack = new PlayerMelee();
            GameInfo.entityManager.AddEntity(attack);
        }

        public void InitializePlayerRangeAttack()
        {
            Entity rangeAttack = new PlayerRangeAttack();
            GameInfo.entityManager.AddEntity(rangeAttack);
        }

        public void InitializeKnightAttack()
        {

            //Entity knightAttack = new KnightAttack();
            //GameInfo.entityManager.AddEntity(knightAttack);

        }

        public void InitializePriestAttack()
        {
            //Entity priestAttack = new PriestAttack();
            //GameInfo.entityManager.AddEntity(priestAttack);

        }

        //säger när allt ska skapas, intialize, skaffa tillgång till bilden?, 
    }
}
