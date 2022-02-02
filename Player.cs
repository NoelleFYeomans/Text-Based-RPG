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

            switch (key.Key)
            {
                case ConsoleKey.W:
                    y -= 1;
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
        }
        public void DrawPosition()
        {
            //Console.Clear(); works but is slow
            //Console.Write("\b"); doesn't work
            Console.SetCursorPosition(x, y);
            Console.Write("@");
        }
    }
}
