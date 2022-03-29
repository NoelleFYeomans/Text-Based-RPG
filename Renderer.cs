using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Renderer
    {
        public void Draw(int x, int y, char printChar, Camera camera) //renderer && fix colour
        {
            Console.SetCursorPosition(x, y);
            
            Console.WriteLine(printChar);
        }
    }
}
