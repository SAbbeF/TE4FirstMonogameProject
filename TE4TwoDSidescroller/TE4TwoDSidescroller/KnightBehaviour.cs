using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class KnightBehaviour : CharacterInput
    {

        private Vector2 trackingDistance;

        int spacingBetweenEntities;
        float attackTimer;
        float jumpTimer;

        public KnightBehaviour(Character character) : base(character)
        {

            trackingDistance = new Vector2(400, 400);
            attackTimer = 0;
            jumpTimer = 0;
            spacingBetweenEntities = 50;
        }
        
        public override void Update(GameTime gameTime)
        {


            attackTimer += gameTime.ElapsedGameTime.Milliseconds;
            jumpTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (character.movementDirection.Length() <= trackingDistance.Length() &&
                character.position.X + spacingBetweenEntities < GameInfo.player1Position.X)
            {

                character.MoveRight();
                if (SoundInput.soundEffectknigthWalkInstance.State != Microsoft.Xna.Framework.Audio.SoundState.Playing)
                {

                    SoundInput.SoundEffectInstance(SoundInput.soundEffectknigthWalkInstance, 0.2f, 0.1f, 0.1f);

                }
            }

            if (character.movementDirection.Length() <= trackingDistance.Length() &&
                character.position.X - spacingBetweenEntities > GameInfo.player1Position.X)
            {

                character.MoveLeft();
                if (SoundInput.soundEffectknigthWalkInstance.State != Microsoft.Xna.Framework.Audio.SoundState.Playing)
                {

                    SoundInput.SoundEffectInstance(SoundInput.soundEffectknigthWalkInstance, 0.2f, 0.1f, 0.1f);

                }
            }

            if (character.position.Y > GameInfo.player1Position.Y)
            {

                character.Jump(gameTime);

                jumpTimer = 0;
            }

            if (character.movementDirection.Length() <= trackingDistance.Length() - 250
                && attackTimer > 2000)
            {
                if (SoundInput.soundEffectswordSwooshInstance.State != Microsoft.Xna.Framework.Audio.SoundState.Playing)
                {

                    SoundInput.SoundEffectInstance(SoundInput.soundEffectswordSwooshInstance, 0.9f, 0.1f, 0.1f);

                }
                character.Attack1();

                attackTimer = 0;
            }

        }


    }



}

