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

        protected void TakeDamage(int atk)
        {
            health = health - atk; //expand
        }

        protected void RespawnCharacter()
        {

        }

        protected void ObeyBorder()
        {
            if (x < 1)
            {
                x = 1;
                
            }
            if (y < 1)
            {
                y = 1;
            }
        }

    }
}
