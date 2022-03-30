using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    abstract class Items : GameObject //cap health & attack, nerf enemy damage
    {
        protected bool onGround = true;
        protected bool initPositon = true;

        public void ItemSpawnPosition(int initalX, int initialY)
        {
            x = initalX;
            y = initialY;
        }

        public virtual void Update(Player player)
        {
            if (onGround == true && player.x == x && player.y == y)
            {
                onGround = false;
            }
        }

        public void Draw(Camera camera, Renderer renderer)
        {
            if (onGround)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                renderer.Draw(x, y, objectIcon, camera);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
