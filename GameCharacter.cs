using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class GameCharacter
    {
        protected int health = 100; //protected, needs to be public to visibly test
        protected int y = 5; //protected, needs to be public to visibly test
        protected int x = 5; //protected, needs to be public to visibly test
        protected bool doAttack = false;
        protected bool isAlive = true;

        protected int priorPositionX; //consider protected (int, int) priorPosition
        protected int priorPositionY;

        public void TakeDamage(int atk) //has to be public
        {
            atk = Clamp(atk, 0, 1000);
            health = health - atk; //expand
            health = Clamp(health, 0, 100);
        }

        protected void PreventOverlap(Player player, Enemy enemy) //too "convoluted"
        {
            if (player.x == enemy.x && player.y == enemy.y)
            {
                if (enemy.isAlive)// feels kinda hack-ey?
                {
                    x = priorPositionX;
                    y = priorPositionY;
                    doAttack = true;
                }
                else if (!isAlive)
                {
                    //nothing, perhaps put something else here
                }
            }
        }

        protected void RespawnCharacter() //future use
        {

        }

        protected int Clamp(int value, int minValue, int maxValue)
        {
            if (value > maxValue)
            {
                value = maxValue;
            }
            if (value < minValue)
            {
                value = minValue;
            }
            return value;
        }

    }
}
