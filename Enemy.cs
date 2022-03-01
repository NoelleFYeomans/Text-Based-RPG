using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class Enemy : GameCharacter //NEEDS TO BE UPDATED BY STANDARD OF PLAYER
    {
        public void ApplyInput(Map map, Player player)
        {
            if (map.isWall(y + deltaY, x + deltaX)) //perform checks before movement
            {
                canMove = false;
            }

            if (x + deltaX == player.x && y + deltaY == player.y)
            {
                canMove = false;
                doAttack = true;
            }

            if (doAttack)
            {
                player.TakeDamage(10); //temp hardcode
                doAttack = false;
            }

            if (canMove) //enemy stops moving when attacked or if it attacks
            {
                x = x + deltaX;
                y = y + deltaY;
                //temp code
                x = Clamp(x, 0, 100);
                y = Clamp(y, 0, 100);
            }
        }

        public void Draw()
        {
            if (spawning) //needs to be changed
            {
                x = 7;
                y = 7;
                spawning = false;
            }
            if (isAlive)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(x, y); //fix
                Console.Write("E");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (!isAlive) //needs to be changed
            {
                x = 0;
                y = 0;
            }
        }
    }
}

