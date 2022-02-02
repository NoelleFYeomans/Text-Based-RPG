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
            //tbd
        }

        public void DrawPosition()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(x - 2, y - 2); //fix
            Console.Write("E");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
