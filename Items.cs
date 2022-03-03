using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class Items : GameObject //add sounds jfc
    {
        protected bool onGround = true;
        protected bool initPositon = true;

        public void InitializeItem(char itemIcon, int initalX, int initialY)
        {
            objectIcon = itemIcon;
            initializeX = initalX;
            initializeY = initialY;
        }

        public void Update(Player player)
        {
            if (onGround == true && player.x == x && player.y == y)
            {
                onGround = false;
            }
        }

        public void Draw()
        {
            if (initPositon)
            {
                x = initializeX;
                y = initializeY;
                initPositon = false;
            }
            if (onGround)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(x, y); //fix
                Console.Write(objectIcon);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {

            }
        }
    }
}
