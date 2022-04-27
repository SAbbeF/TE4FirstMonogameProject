using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{

    //if (firstTargetToCheck.Width + firstTargetToCheck.Height > secondTargetToCheck.X
    //    && firstTargetToCheck.Width + firstTargetToCheck.Height > secondTargetToCheck.Y
    //    && firstTargetToCheck.X < secondTargetToCheck.Width + secondTargetToCheck.Height
    //    && firstTargetToCheck.Y < secondTargetToCheck.Width + secondTargetToCheck.Height)
    //{
    //
    //
    //}

    //firstTargetToCheck.Width > secondTargetToCheck.X
    //&& firstTargetToCheck.Height > secondTargetToCheck.Y
    //&& firstTargetToCheck.X<secondTargetToCheck.Width
    //&& firstTargetToCheck.Y<secondTargetToCheck.Height


    //Städa if-satser
    //Pixelperfect
    //Distance

    // :D
    public class CollisionManager
    {
        public bool RectangleCollision(Rectangle firstTargetToCheck, Rectangle secondTargetToCheck)
        {

            if (firstTargetToCheck.X < secondTargetToCheck.X + secondTargetToCheck.Width
                && firstTargetToCheck.Y < secondTargetToCheck.Y + secondTargetToCheck.Height
                && firstTargetToCheck.X + firstTargetToCheck.Width > secondTargetToCheck.X
                && firstTargetToCheck.Y + firstTargetToCheck.Height > secondTargetToCheck.Y)
            {

                return true;

            }
            else
            {
                return false;

            }

            
        }


        //Kopierad kod
        //Problem att förstå matten bakom for-looparna
        public bool PixelPerfectCollision(Rectangle firstTargetRectangle, Color[] firstTargetColorData,
                                          Rectangle secondTargetRectangle, Color[] secondTargetColorData)
        {
            int top = Math.Max(firstTargetRectangle.Top, secondTargetRectangle.Top);
            int bottom = Math.Min(firstTargetRectangle.Bottom, secondTargetRectangle.Bottom);
            int left = Math.Max(firstTargetRectangle.Left, secondTargetRectangle.Left);
            int right = Math.Min(firstTargetRectangle.Right, secondTargetRectangle.Right);

            // i = Y
            // j = X
            Color firstColor;
            Color secondColor;

            for (int i = top; i < bottom; i++)
            {
                for (int j = left; j < right; j++)
                {

                    firstColor = firstTargetColorData[(j - firstTargetRectangle.Left) + 
                        (i - firstTargetRectangle.Top)/* * firstTargetRectangle.Width*/];

                    secondColor = secondTargetColorData[(j - secondTargetRectangle.Left) +
                        (i - secondTargetRectangle.Top)/* * secondTargetRectangle.Width*/];


                    if (firstColor.A != 0 && secondColor.A != 0)
                    {

                        return true;

                    }

                }

            }


            return false;
        }




        public void CollisionUpdate()
        {
            Entity stepEntity = GameInfo.entityManager.firstEntity;
            Entity secondStepEntity = null;
            //Entity tempEntity;

            while (stepEntity != null)
            {

                if (stepEntity.isActive && stepEntity.hasCollider)
                {

                    secondStepEntity = stepEntity.nextEntity;

                    while (secondStepEntity != null)
                    {
                        if (secondStepEntity.isActive && secondStepEntity.hasCollider)
                        {

                            if (RectangleCollision(stepEntity.collisionBox, secondStepEntity.collisionBox))
                            {
                                stepEntity.HasCollidedWith(secondStepEntity);
                                secondStepEntity.HasCollidedWith(stepEntity);
                            }

                        }

                        secondStepEntity = secondStepEntity.nextEntity;

                    }

                }

                stepEntity = stepEntity.nextEntity;

            }

        }

    }

}

