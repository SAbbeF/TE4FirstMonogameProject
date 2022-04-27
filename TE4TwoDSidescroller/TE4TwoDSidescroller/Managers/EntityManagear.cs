 using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    public class EntityManagear
    {
        public Entity firstEntity;
        public Entity lastEntity;
        public int uniqeCounter;


        public EntityManagear()
        {
            firstEntity = null;
            lastEntity = null;
            uniqeCounter = 0;

        }

        public void AddEntity(Entity entityToAdd)
        {

            uniqeCounter++;
            entityToAdd.uniqeId = uniqeCounter;


            if (firstEntity != null)
            {

                lastEntity.nextEntity = entityToAdd;

            }
            else
            {
                firstEntity = entityToAdd;
            }

            lastEntity = entityToAdd;

        }

        public Entity ChoseEntity(int uniqeId)
        {
            Entity tempEntity = firstEntity;
            while (tempEntity != null)
            {

                if (tempEntity.uniqeId == uniqeId)
                {
                    return tempEntity;
                }

                tempEntity = tempEntity.nextEntity;
            }

            return null;
        }

        public bool RemoveEntity(int id)
        {

            Entity stepEntity = firstEntity;
            if (firstEntity.uniqeId == id)
            {

                firstEntity = firstEntity.nextEntity;
                return true;

            }
            else
            {

                while (stepEntity.nextEntity != null && stepEntity.nextEntity.uniqeId != id)
                {

                    stepEntity = stepEntity.nextEntity;

                }

                if (stepEntity.nextEntity != null && stepEntity.nextEntity.uniqeId == id)
                {

                    stepEntity.nextEntity = stepEntity.nextEntity.nextEntity;
                    if (stepEntity.nextEntity == null)
                    {
                        lastEntity = stepEntity;
                    }
                    return true;

                }

            }
            return false;

        }

        public void RemoveAllEntities()
        {

            firstEntity = null;
            lastEntity = null;

            GC.Collect();
        }

        public void Update(GameTime gameTime)
        {
            //gå igenom varje objekt och kör update på det
            Entity tempEntity = firstEntity;
            while (tempEntity != null)
            {
                if (tempEntity.isActive)
                {

                    tempEntity.Update(gameTime);

                    tempEntity = tempEntity.nextEntity;

                }

            }

        }

        public void Draw(GameTime gameTime)
        {


            //gå igenom varje objekt och kör update på det
            Entity tempEntity = firstEntity;
            while (tempEntity != null)
            {
                if (tempEntity.isActive)
                {

                    tempEntity.Draw(gameTime);

                    tempEntity = tempEntity.nextEntity;

                }

            }
        }
    }
}
