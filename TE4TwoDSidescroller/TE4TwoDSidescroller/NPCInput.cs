using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{
    class NPCInput : CharacterInput
    {

        protected bool moveRight;
        protected float startPosition;
        protected float endPosition;
        //public Vector2 startPoint (100, 200);
        //public float npcSpeed = 0.2f;


        public NPCInput(Character character)
            : base(character)
        {
            moveRight = true;
            startPosition = 0;
            endPosition = 0;

        }



        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }

        public virtual void Patrol()
        {

            if (startPosition == 0 || endPosition == 0)
            {
                startPosition = character.position.X;
                endPosition = character.position.X + 200;

            }


            if (moveRight)
            {
                //startPoint.X += npcSpeed * (float)GameInfo.gameTime.ElapsedGameTime.TotalMilliseconds;
                character.MoveRight();
            }
            else
            {
                //startPoint.X -= npcSpeed * (float)GameInfo.gameTime.ElapsedGameTime.TotalMilliseconds;
                character.MoveLeft();
            }


            if (character.position.X > endPosition)
            {
                moveRight = false;
            }
            if (character.position.X < startPosition)
            {
                moveRight = true;
            }

        }


    }
}

