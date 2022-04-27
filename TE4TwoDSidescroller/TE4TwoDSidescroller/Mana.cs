using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    class Mana 
    {
       
        public int UseMana(int manaPool, int amountOfManaUsed)
        {

            if (CanYouUseMana(manaPool, amountOfManaUsed))
            {

                manaPool = manaPool - amountOfManaUsed;
           
                return manaPool;

            }

            return manaPool;
        }

        public bool CanYouUseMana(int currentMana, int manaUsage)
        {

            if (currentMana < manaUsage)
            {
                return false;
            }

            return true;
        }

            //detta behövs inte men ifall man senare vill ha ett item som ökar ens manaregen så kan detta 
            //var ett bra sätt att göra det men det kan också bero på ifall det skulle vara ett permanent eller temporärt item
            /*if (manaPool < 100 && manaRegenAmount != 1)
            {
                manaRegenAmount = 1;
            }
            else if (manaPool == 100)
            {
                manaRegenAmount = 0;
            }*/


    }
}
