using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class GameCharacter
    {
        protected int health = 100;
        protected int y = 5;
        protected int x = 5;

        protected int priorPositionX; //consider protected (int, int) priorPosition
        protected int priorPositionY;

        protected void TakeDamage(int atk)
        {
            health = health - atk; //expand
            Clamp(atk, 0, 1000);
            Clamp(health, 0, 100);
        }

        protected void PreventOverlap(Player player, Enemy enemy) //too "convoluted"
        {
            if (player.x == enemy.x && player.y == enemy.y)
            {
                x = priorPositionX;
                y = priorPositionY;
            }
        }

        protected void RespawnCharacter()
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
