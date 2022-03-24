using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class Items : GameObject
    {
        protected bool onGround = true;
        protected bool initPositon = true;

        public void InitializeItemPosition(int initalX, int initialY)
        {
            initializeX = initalX;
            initializeY = initialY;
        }

        public virtual void Update(Player player)
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
        }
    }
}
