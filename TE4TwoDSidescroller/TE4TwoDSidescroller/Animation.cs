using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    public class Animation
    {
        #region Old Code
        //public int CurrentFrame { get; set; }

        //public int FrameCount { get; private set; }

        //public int FrameHeight { get { return Texture.Height; } }

        //public float FrameSpeed { get; set; }

        //public int FrameWidth { get { return (Texture.Width / FrameCount); } }

        //public bool IsLooping { get; set; }

        //public Texture2D Texture { get; private set; }

        //public Animation(Texture2D texture, int frameCount)
        //{
        //    Texture = texture;
        //    FrameCount = frameCount;
        //    IsLooping = true;
        //    FrameSpeed = 0.2f;
        //}
        #endregion

        #region New Code

        //Texture2D texture;
        //Rectangle rectangle;
        //Vector2 position;
        //Vector2 origin;
        ////Vector2 velocity;

        //int currentFrame;
        //int frameHeight;
        //int frameWidth;

        //float timer;
        //float frameSpeed = 50f;

        //public Animation(Texture2D newTexture, Vector2 newPosition, int newFrameHeight, int newFrameWidth)
        //{
        //    texture = newTexture;
        //    position = newPosition;
        //    frameHeight = newFrameHeight;
        //    frameWidth = newFrameWidth;
        //}

        //public virtual void Update(GameTime gameTime)
        //{
        //    rectangle = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
        //    origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);


        //}

        //public void AnimateRight(GameTime gameTime)
        //{
        //    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
        //    if (timer > frameSpeed)
        //    {
        //        currentFrame++;
        //        timer = 0;

        //        if (currentFrame > 3)
        //        {
        //            currentFrame = 0;
        //        }
        //    }
        //}

        //public virtual void Draw(GameTime gameTime)
        //{
        //    GameInfo.spriteBatch.Draw(texture, position, rectangle, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);

        //}

        #endregion

        #region newer code

        public float timeElapsed;
        public bool isLooping;
        private float timeToUpdate; //frameSpeed
        public int FramePerSecond
        {
            set
            {
                timeToUpdate = (1f / value);

            }
        }

        protected Texture2D currentTexture;
        public Vector2 position;
        public Vector2 origin;
        public float rotation;
        public float scale;
        public SpriteEffects spriteEffects;
        protected Rectangle[] rectangles;
        public int frameIndex;

        public Animation(Texture2D texture, int frames)
        {
            currentTexture = texture;
            int width = texture.Width / frames;
            rectangles = new Rectangle[frames];

            for (int currentFrame = 0; currentFrame < frames; currentFrame++)
            {
                rectangles[currentFrame] = new Rectangle(
                    currentFrame * width, 0, width, texture.Height);
            }

            position = Vector2.Zero;
            rotation = 0.0f;
            scale = 1f;
            frameIndex = 0;
        }

        public void Draw(GameTime gameTime)
        {
            //timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //if (timeElapsed > timeToUpdate)
            //{
            //    timeElapsed -= timeToUpdate;

            //    if (frameIndex < rectangles.Length - 1)
            //    {
            //        frameIndex++;
            //    }
            //    else if (isLooping)
            //    {
            //        frameIndex = 0;
            //    }
            //}

            GameInfo.spriteBatch.Draw(currentTexture, position, rectangles[frameIndex], Color.White, rotation, origin, scale, spriteEffects, 0f);
        }

        public void Update(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                if (frameIndex < rectangles.Length - 1)
                {
                    frameIndex++;
                }
                else if (isLooping)
                {
                    frameIndex = 0;
                }
            }
        }

        #endregion

        #region newest code

        #endregion
    }
}
