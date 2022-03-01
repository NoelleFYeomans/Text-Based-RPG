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

        public void Update(Map map, Enemy enemy) //you can pass in a different class to access it
        {

            if (health <= 0)
            {
                isAlive = false;
            }

            key = Console.ReadKey(true);

            //I want to have the player's position before the move saved
            priorPositionX = x;
            priorPositionY = y;

            //resetting the values of the intended change in position
            deltaX = 0;
            deltaY = 0;

            if (isAlive)
            {

                canMove = true;
                doAttack = false;

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

                if (x + deltaX == enemy.x && y + deltaY == enemy.y)//ask
                {
                    canMove = false;
                    doAttack = true;
                }

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

        public void Draw()
        {
            if (spawning)
            {
                x = 5;
                y = 5;
                spawning = false;
            }
            if (isAlive)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
