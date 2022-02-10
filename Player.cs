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
        
        //perhaps consider a series of booleans

        public void UpdatePosition(Map map, Enemy enemy, Player player) //you can pass in a different class to access it
        {

            if (player.health <= 0)
            {
                isAlive = false;
            }

            key = Console.ReadKey(true);

            //I want to have the player's position before the move saved
            priorPositionX = x; //these needs to be elsewhere maybe?
            priorPositionY = y; 
            if (isAlive)
            {
                switch (key.Key) //make move separate from the want to move. Playerinput/enemyAI
                {


                    case ConsoleKey.W: //input
                        y -= 1; //move
                        break;
                    case ConsoleKey.S:
                        y += 1;
                        break;
                    case ConsoleKey.D:
                        x += 1;
                        break;
                    case ConsoleKey.A:
                        x -= 1;
                        break;
                }

                x = Clamp(x, 0, 100);
                y = Clamp(y, 0, 100);


                if (Map.mapArray[y, x] == '#') //this needs to be elsewhere, also, if I leave boundaries, it crashes because it's checking y and x vs map coordinates
                {
                    y = priorPositionY;
                    x = priorPositionX;
                }

                PreventOverlap(player, enemy); // move elsewhere eventually

                if (doAttack) // also move elsewhere eventually? idk maybe this does stay in update();
                {
                    enemy.TakeDamage(25);
                    doAttack = false;
                }

            }
          
        }

        public void DrawPosition()
        {
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
