using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TE4TwoDSidescroller
{
    public class EntityAnimation
    {

        protected Texture2D currentTexture;
        protected Vector2 currentOrigin;
        protected Rectangle sourceRectangle;
        protected Vector2 currentPosition; 
        protected Vector2 scale;
        protected SpriteEffects spriteEffects;
        protected int currentFrame;
        protected int currentFrameCount;
        protected float timeElapsed;
        protected float timeToUpdateFrame;
        protected float layerDepth;
        protected float rotation;

        protected bool isLooping; //hmm?


        public EntityAnimation(Texture2D currentTexture, int currentFrame, int currentFrameCount,
            Vector2 currentOrigin, Vector2 currentPosition ,Rectangle sourceRectangle, Vector2 scale,
             float layerDepth, SpriteEffects spriteEffects, float rotation = 0)
        {
            this.currentTexture = currentTexture;
            this.currentFrame = currentFrame;
            this.currentFrameCount = currentFrameCount;
            this.currentOrigin = currentOrigin;
            this.currentPosition = currentPosition;
            this.sourceRectangle = sourceRectangle;
            this.scale = scale;
            this.layerDepth = layerDepth;
            this.spriteEffects = spriteEffects;
            this.rotation = rotation; //hmm?
        }

        public void UpdateDraw(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeElapsed > timeToUpdateFrame)
            {
                timeElapsed = 0;
                currentFrame++;
                if (currentFrame > currentFrameCount - 1)
                {
                    if (isLooping)
                    {
                        currentFrame = 0;
                    }
                    else
                    {
                        currentFrame = currentFrameCount - 1;
                    }
                }
            }
        }

    }
}
