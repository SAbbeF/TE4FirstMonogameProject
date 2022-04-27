using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    public class AnimationManager
    {
        //    public Animation animation;

        //    private float timer;

        //    public Vector2 Position { get; set; }

        //    public AnimationManager(Animation newAnimation)
        //    {
        //        animation = newAnimation;
        //    }

        //    public void Draw(SpriteBatch spriteBatch)
        //    {
        //        spriteBatch.Draw(animation.Texture, Position,
        //            new Rectangle(animation.CurrentFrame * animation.FrameWidth, 0, animation.FrameWidth, animation.FrameHeight),
        //            Color.White);
        //    }
        //    public void Play(Animation newAnimation)
        //    {
        //        if(animation == newAnimation)
        //        {
        //            return;
        //        }

        //        animation = newAnimation;

        //        animation.CurrentFrame = 0;

        //        timer = 0f;
        //    }

        //    public void Stop()
        //    {
        //        timer = 0;

        //        animation.CurrentFrame = 0;
        //    }

        //    public void Update(GameTime gameTime)
        //    {
        //        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

        //        if(timer > animation.FrameSpeed)
        //        {
        //            timer = 0f;

        //            animation.CurrentFrame++;

        //            if(animation.CurrentFrame >= animation.FrameCount)
        //            {
        //                animation.CurrentFrame = 0;
        //            }
        //        }
        //    }

        protected Texture2D currentTexture;
        public Vector2 position;
        public Vector2 origin;
        public float rotation;
        public float scale;
        protected Rectangle[] rectangles;
        protected int frameIndex;

        public AnimationManager(Texture2D Texture, int frames)
        {
            currentTexture = Texture;
            int width = Texture.Width / frames;
            rectangles = new Rectangle[frames];

            for (int currentFrame = 0; currentFrame < frames; currentFrame++)
            {
                rectangles[currentFrame] = new Rectangle(
                    currentFrame * width, 0, width, Texture.Height);
            }

            position = Vector2.Zero;
            rotation = 0.0f;
            scale = 1f;
            frameIndex = 0;
        }

        public void Draw(GameTime gameTime)
        {
            GameInfo.spriteBatch.Draw(currentTexture, position, rectangles[frameIndex], Color.White, rotation, origin, scale, SpriteEffects.None, 0f);
        }
        //public float timeElapsed;
        //public bool isLooping;
        //private float timeToUpdate; //frameSpeed
        //public int FramePerSecond
        //{
        //    set
        //    {
        //        timeToUpdate = (1f / value);

        //    }
        //}

        //public Animation(Texture2D texture, int frames) : base(texture, frames)
        //{

        //}

        //public void Update(GameTime gameTime)
        //{
        //    timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
        //    if (timeElapsed > timeToUpdate)
        //    {
        //        timeElapsed -= timeToUpdate;

        //        if (frameIndex < rectangles.Length - 1)
        //        {
        //            frameIndex++;
        //        }
        //        else if (isLooping)
        //        {
        //            frameIndex = 0;
        //        }
        //    }
        //}

    }
}
