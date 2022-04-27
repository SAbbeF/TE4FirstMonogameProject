using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Stamina : Character
    {

        public static bool sprint;
        public static int stamina;

        private int tickTimer;

        public Stamina()
        {

            stamina = 100;
            tickTimer = 0;
            sprint = false;

        }

        public override void Update(GameTime gametime)
        {
            //gör så att när man håller ner shift så är sprint true

            if (sprint == false)
            {

                if (tickTimer == 2 && stamina != 100)
                {

                    stamina++;
                    tickTimer = 0;

                }
                tickTimer++;

            }
            else if (sprint)
            {

                if (tickTimer == 2 && stamina != 0)
                {

                    stamina--;
                    tickTimer = 0;

                }
                tickTimer++;

            }
        }
    }
}
