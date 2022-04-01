using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Renderer
    {


        public void Draw(int worldX, int worldY, char printChar, Camera camera, ConsoleColor color) //initial print is an issue
        {

            int screenX = worldX - camera.x; //camOffset x = player.x
            int screenY = worldY - camera.y;//camOffset y = player.y

            screenX += camera.width / 2; //centers camera on X axis
            screenY += camera.height / 2; //centers camera on Y axis

            if (screenX < 0 || screenX > camera.width || screenY < 0 || screenY > camera.height) return; //screenY < 2 fixed the north end screen jitter, I do not know exactly why

            Console.SetCursorPosition(screenX, screenY);
            Console.ForegroundColor = color;
            Console.Write(printChar);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
