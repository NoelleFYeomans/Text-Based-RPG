using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Enemy : GameCharacter
    {
        public void UpdatePosition()
        {
            Random tar = new Random();
            int target = tar.Next(0, 3);

            if (target <= 1)
            {
                //how do I access the player X & Y?
            }

            else if (target >= 2)
            {
                Random rnd = new Random();
                int dir = rnd.Next(1, 5);

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
            }
            ObeyBorder();
        }

        public void DrawPosition()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(x, y); //fix
            Console.Write("E");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
