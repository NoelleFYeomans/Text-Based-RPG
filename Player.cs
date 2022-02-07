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
        
        public void UpdatePosition(Map map)//you can pass in class
        {

            key = Console.ReadKey(true);

            //I want to have the player's position before the move saved
            int priorPositionX = x; //this needs to be elsewhere
            int priorPositionY = y; //this needs to be elsewhere

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


            if (Map.mapArray[y, x] == '#') //this needs to be elsewhere
            {
                y = priorPositionY;
                x = priorPositionX;
            }

        }

        public void DrawPosition()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
