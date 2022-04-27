using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller.Levels
{
    class DeathZone : Entity
    {


        public DeathZone()
        {

            tag = Tags.DeathZone.ToString();

            isActive = true;
            hasCollider = true;

            collisionBox = new Rectangle(-1000, 900, 6000, 50);


        }


    }
}
