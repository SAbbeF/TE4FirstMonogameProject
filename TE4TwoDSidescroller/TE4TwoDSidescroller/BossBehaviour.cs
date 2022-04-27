using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class BossBehaviour : CharacterInput
    {
        double heavyAttackTimer;

        public BossBehaviour(Character character) : base(character)
        {
            heavyAttackTimer = 0;
        }
        public override void Update(GameTime gameTime)
        {
            heavyAttackTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GameInfo.bossPosition.X - GameInfo.player1Position.X < 1000 && heavyAttackTimer > 2)
            {
                heavyAttackTimer = 0;
                character.Attack1();
                character.Attack2();
            }
            if (GameInfo.bossPosition.X - GameInfo.player1Position.X > 1000 && heavyAttackTimer > 2)
            {
                heavyAttackTimer = 0;
                character.Attack2();
            }
        }
    }
}
