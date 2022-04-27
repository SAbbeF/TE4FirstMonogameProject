using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TE4TwoDSidescroller
{
    public class CharacterInput
    {
        public Character character;

        public CharacterInput(Character character)
        {
            this.character = character;
        }

        public virtual void Update(GameTime gameTime)
        {

        }
    }
}
