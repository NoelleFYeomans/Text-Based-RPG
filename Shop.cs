using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Shop : GameObject
    {

        GlobalSettings global;

        public Shop(GlobalSettings global)
        {
            this.global = global;
            objectIcon = global.shopObjectIcon;
            x = global.shopPosX;
            y = global.shopPosY;
        }

        public void DrawShop(Camera camera, Renderer renderer)
        {
            renderer.Draw(x, y, objectIcon, camera, ConsoleColor.DarkYellow);
        }

    }
}
