using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Enemy : GameCharacter
    {

        //public void UpdatePosition()
        //{
        //    Random rnd = new Random();
        //    int dir = rnd.Next(1, 5);
  
        //    if (dir == 1)
        //    {
        //        y -= 1;
        //    }
        //    else if (dir == 2)
        //    {
        //        y += 1;
        //    }
        //    else if (dir == 3)
        //    {
        //        x += 1;
        //    }
        //    else if (dir == 4)
        //    {
        //        x -= 1;
        //    }
        //}

        public void DrawPosition()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(x - 2, y - 2); //fix
            Console.Write("E");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
