using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class GameCharacter : GameObject
    {
        public int health = 100; //protected, needs to be public to visibly test
        public int y; //protected, needs to be public to visibly test
        public int x; //protected, needs to be public to visibly test

        protected bool doAttack = false;
        protected bool canMove = true;
        protected bool isAlive = true;
        protected bool spawning = true;

        public int priorPositionX;
        public int priorPositionY;
        public int deltaX;
        public int deltaY;

        public void TakeDamage(int atk) //has to be public
        {
            atk = Clamp(atk, 0, 1000);
            health = health - atk; //expand
            health = Clamp(health, 0, 100);
        }

        //protected void PreventOverlap(Player player, Enemy enemy) //too "convoluted"
        //{
        //    if (player.x == enemy.x && player.y == enemy.y)
        //    {
        //        if (enemy.isAlive)// feels kinda hack-ey?
        //        {
        //            x = priorPositionX;
        //            y = priorPositionY;
        //            doAttack = true;
        //        }
        //        else if (!isAlive)
        //        {
        //            //nothing, perhaps put something else here
        //        }
        //    }
        //}
        //protected bool isGameCharacterAt(Player player, Enemy enemy) //working on this // maybe I am being too modular
        //{
        //    if (player.x == enemy.x && player.y == enemy.y)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

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
