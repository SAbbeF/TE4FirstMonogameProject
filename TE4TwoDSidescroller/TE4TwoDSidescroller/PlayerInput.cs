using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{
    class PlayerInput : CharacterInput
    {
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        MouseState currentMouseState;
        MouseState previousMouseState;  

        #region Keys & Buttons
        private Keys upKey;
        private Keys downKey;
        private Keys leftKey;
        private Keys rightKey;

        private Keys resetKey;

        private Keys runKey;

        private Keys jumpKey;
        private Keys doubleJumpKey;

        private Keys crouchKey;
        private Keys dashKey;

        private Keys weaponSwitchKey;

        private Keys lightAttackKey;

        private Keys heavyAttackKey;
        private Keys specialAttackKey;

        private Keys parryKey;
        private Keys blockKey;
        private Keys dodgeKey;

        private Keys healthPotionKey;
        private Keys manaPotionKey;

        private Keys interactKey;

        private Keys inventoryKey;

        private Keys inGameMenuKey;

        private Keys exitToMainMenuKey;

        private Keys exitGameKey;

        #endregion

        public PlayerInput(Character character)
            : base(character)
        {

            upKey = Keys.W;
            downKey = Keys.S;
            leftKey = Keys.A;
            rightKey = Keys.D;

            jumpKey = Keys.Space;
            runKey = Keys.LeftShift;
            resetKey = Keys.R;
            lightAttackKey = Keys.Q;
            heavyAttackKey = Keys.E;
            //doubleJumpKey = Keys.Space;

        }

        public override void Update(GameTime gameTime)
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            #region Movements

            if(currentKeyboardState.IsKeyDown(Keys.R) && previousKeyboardState.IsKeyUp(Keys.R))
            {
                character.Reset();
            }

            if (currentKeyboardState.IsKeyDown(upKey))
            {
                character.MoveUp();
            }

            if (currentKeyboardState.IsKeyDown(downKey))
            {
                character.MoveDown();
            }

            if (currentKeyboardState.IsKeyDown(leftKey))
            {
                character.MoveLeft();
            }

            if (currentKeyboardState.IsKeyDown(rightKey))
            {
                character.MoveRight();
            }

            if (currentKeyboardState.IsKeyDown(runKey))
            {
                character.Run();
            }
            else
            {
                character.DoNotRun();
            }

            //if (currentKeyboardState.IsKeyDown(jumpKey) && !previousKeyboardState.IsKeyDown(jumpKey))
            //{                
            //    character.Jump(gameTime);
            //}

            if (currentKeyboardState.IsKeyDown(jumpKey))
            {
                character.Jump(gameTime);
            }

            if (Keyboard.GetState().IsKeyDown(doubleJumpKey))
            {
                character.DoubleJump();                
            }


            if (Keyboard.GetState().IsKeyDown(crouchKey))
            {
                character.Crouch();
            }
            if (Keyboard.GetState().IsKeyDown(dashKey))
            {
                character.Dash();
            }

            #endregion

            #region Combat

            #region Unused mousestates for attacks
            //if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            //{
            //    character.Attack1();
            //}

            //if (currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released)
            //{
            //    character.Attack2();
            //}
            #endregion

            if (currentKeyboardState.IsKeyDown(lightAttackKey) && !previousKeyboardState.IsKeyDown(lightAttackKey))
            {
                character.Attack1();
                              
                SoundInput.SoundEffectPlayed(SoundInput.swordSwoosh, 0.6f, 0.6f, 0.1f);
            }

            if (currentKeyboardState.IsKeyDown(heavyAttackKey) && !previousKeyboardState.IsKeyDown(heavyAttackKey))
            {
                character.Attack2();

                SoundInput.SoundEffectPlayed(SoundInput.startFireBall, 0.2f, 0.1f, 0.6f);
            }

            if (currentKeyboardState.IsKeyDown(specialAttackKey) && !previousKeyboardState.IsKeyDown(specialAttackKey))
            {
                character.Attack3();
            }


            if (Keyboard.GetState().IsKeyDown(parryKey))
            {
                character.Parry();
            }

            if (Keyboard.GetState().IsKeyDown(blockKey))
            {
                character.Block();
            }

            if (Keyboard.GetState().IsKeyDown(dodgeKey))
            {
                character.Dodge();
            }

            #endregion

            #region Conditions

            if (Keyboard.GetState().IsKeyDown(weaponSwitchKey))
            {
                character.SwitchWeapon();
            }

            if (Keyboard.GetState().IsKeyDown(interactKey))
            {
                character.Interact();
            }

            if (Keyboard.GetState().IsKeyDown(inGameMenuKey))
            {
                character.OpenInGameMenu();
            }

            if (Keyboard.GetState().IsKeyDown(inventoryKey))
            {
                character.OpenInventory();
            }

            if (Keyboard.GetState().IsKeyDown(healthPotionKey))
            {
                character.ConsumeHealthPotion();
            }

            if (Keyboard.GetState().IsKeyDown(manaPotionKey))
            {
                character.ConsumeManaPotion();
                
            }

            if (Keyboard.GetState().IsKeyDown(exitToMainMenuKey))
            {
                character.ExitToMainMenu();
            }

            if (Keyboard.GetState().IsKeyDown(exitGameKey))
            {
                character.ExitGame();
            }

            #endregion

        }
    }
}
