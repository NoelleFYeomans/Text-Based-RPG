using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Player : GameCharacter
    {
        ConsoleKeyInfo key = new ConsoleKeyInfo();

        public void UpdatePosition(Map map, Enemy enemy, Player player) //you can pass in a different class to access it
        {

            if (player.health <= 0)
            {
                isAlive = false;
            }

            key = Console.ReadKey(true);

            //I want to have the player's position before the move saved
            priorPositionX = x;
            priorPositionY = y;

            deltaX = 0;
            deltaY = 0;

            if (isAlive)
            {

                canMove = true;

                //obtain player input/desired movement
                switch (key.Key) 
                {
                    case ConsoleKey.W:
                        deltaY = -1;
                        break;
                    case ConsoleKey.S:
                        deltaY = +1;
                        break;
                    case ConsoleKey.D:
                        deltaX = +1;
                        break;
                    case ConsoleKey.A:
                        deltaX = -1;
                        break;
                }

                //clamps, collisions, & other checks
                x = Clamp(x, 0, 100);
                y = Clamp(y, 0, 100);


                if (map.isWall(y + deltaY, x + deltaX)) //perform checks before movement
                {
                    canMove = false;
                }

                
                PreventOverlap(player, enemy); // move elsewhere eventually, also maybe replace fully?

                if (doAttack) // also move elsewhere eventually? idk maybe this does stay in update(); add sound to hitting wall
                {
                    enemy.TakeDamage(25); //hardcoded temporarily
                    doAttack = false;
                }

                //apply movements values
                if (canMove)
                {
                    x = x + deltaX;
                    y = y + deltaY;
                }
            }
          
        }

        public void DrawPosition()
        {
            if (spawning)
            {
                x = 5;
                y = 5;
                spawning = false;
            }
            if (isAlive)
            {
                Console.SetCursorPosition(2, 21);//temp code
                Console.WriteLine("Player health:" + health); //temp code
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
