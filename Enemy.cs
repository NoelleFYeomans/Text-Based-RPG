using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Enemy : GameCharacter //NEEDS TO BE UPDATED BY STANDARD OF PLAYER
    {
        public void Update(Map map, Enemy enemy, Player player)
        {

            if (enemy.health <= 0)
            {
                isAlive = false;
            }

            //enemy's intended position before moving
            priorPositionX = x;
            priorPositionY = y;

            //resetting the deltas of the movement
            deltaX = 0;
            deltaY = 0;

            Random tar = new Random();
            int target = tar.Next(0, 3);

            if (isAlive)
            {
                if (target <= 1) //avoid cursor position
                {
                    if (x < player.x) 
                    {
                        deltaX = 1;
                    }
                    else if (x > player.x)
                    {
                        deltaX = -1;
                    }
                    else
                    {
                        if (y < player.y) //need to use console.cursorleft without public x/y
                        {
                            deltaY = +1;
                        }
                        else if (y > player.y)
                        {
                            deltaY = -1;
                        }
                        else
                        {
                            //nothing //could be improved
                        }
                    }
                }

                else if (target >= 2)
                {
                    Random rnd = new Random();
                    int dir = rnd.Next(1, 6);

                    if (dir == 1)
                    {
                        deltaY = -1;
                    }
                    else if (dir == 2)
                    {
                        deltaY = +1;
                    }
                    else if (dir == 3)
                    {
                        deltaX = +1;
                    }
                    else if (dir == 4)
                    {
                        deltaX = -1;
                    }
                    else if (dir == 5)
                    {
                        //doesn't move
                    }
                }

                x = Clamp(x, 0, 100);
                y = Clamp(y, 0, 100);

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
                }
            }

        }

        public void Draw()
        {
            if (spawning)
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
            else if (!isAlive) //hack-ey
            {
                x = 0;
                y = 0;
            }
        }
    }
}
