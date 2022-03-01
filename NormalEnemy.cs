using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class NormalEnemy : Enemy
    {
        private char enemyIcon = 'E';

        public void Update(Map map, Player player)
        {
            if (health <= 0)
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

                deltaX = Clamp(deltaX, -1, 1);
                deltaY = Clamp(deltaY, -1, 1);

                ApplyInput(map, player);
            }
        }

        public void DrawNormal()
        {
            if (spawning) //needs to be changed/moved elsewhere
            {
                x = 7;
                y = 7;
                spawning = false;
            }
            if (isAlive)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(x, y);
                Console.Write(enemyIcon);
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
