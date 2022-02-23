using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Enemy : GameCharacter //NEEDS TO BE UPDATED BY STANDARD OF PLAYER
    {
        public void UpdatePosition(Map map, Enemy enemy, Player player)
        {

            if (enemy.health <= 0)
            {
                isAlive = false;
            }

            priorPositionX = x;
            priorPositionY = y;

            Random tar = new Random();
            int target = tar.Next(0, 3);

            if (isAlive)
            {
                if (target <= 1) //avoid cursor position
                {
                    if (x < player.x) 
                    {
                        x++;
                    }
                    else if (x > player.x)
                    {
                        x--;
                    }
                    else
                    {
                        if (y < player.y) //need to use console.cursorleft without public x/y
                        {
                            y++;
                        }
                        else if (y > player.y)
                        {
                            y--;
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
                        y -= 1;
                    }
                    else if (dir == 2)
                    {
                        y += 1;
                    }
                    else if (dir == 3)
                    {
                        x += 1;
                    }
                    else if (dir == 4)
                    {
                        x -= 1;
                    }
                    else if (dir == 5)
                    {
                        //doesn't move
                    }
                }

                x = Clamp(x, 0, 100);
                y = Clamp(y, 0, 100);

                if (map.isWall(y, x)) //this needs to be elsewhere, also, if I leave boundaries, it crashes because it's checking y and x vs map coordinates
                {
                    y = priorPositionY;
                    x = priorPositionX;
                }

                PreventOverlap(player, enemy);

                if (doAttack)
                {
                    player.TakeDamage(10); //temp hardcode
                    doAttack = false;
                }

            }

        }

        //getx method, and gety method, make public and feed into player

        public void DrawPosition()
        {
            if (spawning)
            {
                x = 7;
                y = 7;
                spawning = false;
            }
            if (isAlive)
            {
                Console.SetCursorPosition(2, 20);//temp code
                Console.WriteLine("Enemy health:" + health); //temp code
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(x, y); //fix
                Console.Write("E");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
