using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class GameCharacter
    {
        protected int health;
        protected int y = 5;
        protected int x = 5;

        protected void TakeDamage()
        {

        }

        protected void RespawnCharacter()
        {

        }

        protected void ObeyBorder()
        {
            if (Console.CursorLeft <= 2)
            {
                x = 2;
            }
            else if (Console.CursorTop <= 1)
            {
                y = 2;
            }
        }

    }
}
