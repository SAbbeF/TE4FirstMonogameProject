using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace TE4TwoDSidescroller
{
    class FarmerInput : NPCInput
    {

        public FarmerInput(Farmer character) : base(character)
        {



        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Patrol();

        }

    }
}
