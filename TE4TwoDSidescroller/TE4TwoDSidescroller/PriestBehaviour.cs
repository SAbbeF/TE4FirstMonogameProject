using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class PriestBehaviour : CharacterInput
    {
        private Vector2 escapeDistance;
        private Vector2 attackRadius;

        float attackTimer;
        float jumpTimer;

        public PriestBehaviour(Character character) : base(character)
        {

            escapeDistance = new Vector2(400, 400);
            attackRadius = new Vector2(600, 600);

            attackTimer = 0;
            jumpTimer = 0;
        }



    
        public override void Update(GameTime gameTime)
        {

            attackTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (character.movementDirection.Length() <= escapeDistance.Length() &&
                character.position.X > GameInfo.player1Position.X)
            {

                character.MoveRight();

            }

            if (character.movementDirection.Length() <= escapeDistance.Length() &&
               character.position.X < GameInfo.player1Position.X)
            {

                character.MoveLeft();

            }

            if (character.movementDirection.Length() <= attackRadius.Length()
                && attackTimer > 2500)
            {

                character.Attack1();

                attackTimer = 0;
            }


        }

    }
}
