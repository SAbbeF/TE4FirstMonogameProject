using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace TE4TwoDSidescroller
{
    public class Game1 : Game
    {
        //SoundInput soundInput;

        public Game1()
        {
            //soundInput = new SoundInput();
            GameInfo.graphicsDevice = new GraphicsDeviceManager(this);
            GameInfo.collisionManager = new CollisionManager();
            GameInfo.entityManager = new EntityManagear();
            GameInfo.collisionManager = new CollisionManager();
            GameInfo.creationManager = new CreationManager();
            GameInfo.gameInformationSystem = new GameInformationSystem();
            GameInfo.screenManager = new ScreenManager();
            


            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;

        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            GameInfo.screenManager.Resolution(1);
            GameInfo.creationManager.Initialize();
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            GameInfo.spriteBatch = new SpriteBatch(GameInfo.graphicsDevice.GraphicsDevice);

            Menu.ContentLoad(Content);
            SoundInput.ContentLoad(Content);
            LastlvlText.ContentLoad(Content);
            GameInfo.creationManager.Initialize();
            
            //ej rätt GraphicsDevice ska vara graphics.GraphicsDevice
            

        }

        protected override void Update(GameTime gameTime)
        {
            //soundInput.PlaySound();
            GameInfo.entityManager.Update(gameTime);

            GameInfo.collisionManager.CollisionUpdate();
            
           
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)||Entity.wantExit)
            {
                Exit();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GameInfo.graphicsDevice.GraphicsDevice.Clear(Color.Black);
            GameInfo.spriteBatch.Begin();

            GameInfo.entityManager.Draw(gameTime);
            

            GameInfo.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
