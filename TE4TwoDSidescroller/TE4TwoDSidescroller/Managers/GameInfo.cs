using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TE4TwoDSidescroller
{


    public static class GameInfo
    {
        
        static public Game1 game1;
        static public GraphicsDeviceManager graphicsDevice;
        static public SpriteBatch spriteBatch;
        static public CollisionManager collisionManager;
        static public EntityManagear entityManager;
        static public ScreenManager screenManager;
        static public CreationManager creationManager;
        static public Vector2 player1Position;
        static public Rectangle Player1TextureSize;
        static public bool player1IsFacingRight;
        static public Vector2 viewportPosition;
        static public VisionManager visionManager;
        static public GameInformationSystem gameInformationSystem; 
        static public GameTime gameTime;
        static public Vector2 bossPosition;
        static public int playerOneCurrentHealth;



        #region kommentar
        /*        static public void Initialize()
                {
                    graphicsDevice = new GraphicsDeviceManager(game1);


                }

                static public GraphicsDeviceManager GraphicsManager()
                {

                    return graphicsDevice;

                }

                static public EntityManagear EntityManager()
                {
                    object entityManager;
                    entityManager = new EntityManagear();

                    return (EntityManagear)entityManager;

                }

                public static CollisionManager CollisionManager()
                {
                    object collisionManager;
                    collisionManager = new CollisionManager();

                    return (CollisionManager)collisionManager;

                }

        */
        #endregion
    }

}
