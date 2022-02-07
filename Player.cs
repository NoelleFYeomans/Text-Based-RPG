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
        
        public void UpdatePosition()
        {

            key = Console.ReadKey(true);

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

            x = Clamp(x, 1, 100);
            y = Clamp(y, 1, 100);

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
