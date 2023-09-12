using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class Shop : GameObject
    {
        Player player;
        GlobalSettings global;
        public int potionCost;
        public bool inShop = false;
        public bool exitingShop = false;

        public Shop(GlobalSettings global, Player player)
        {
            this.global = global;
            objectIcon = global.shopObjectIcon;
            x = global.shopPosX;
            y = global.shopPosY;
            potionCost = global.potionCost;
            this.player = player;
        }

        public bool canAfford()
        {
            if (player.goldHeld >= global.potionCost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update()
        {

            if(inShop)
            {
                if (canAfford() == false)
                {
                    exitShop();
                }
            }


            if(player.x == x &&  player.y == y && !inShop && !exitingShop)
            {
                inShop = true;
            }

            if((player.x != x || player.y != y) && exitingShop)
            {
                exitingShop = false;
            }

        }

        public void exitShop()
        {
            inShop = false;
            exitingShop = true;
        }

        public void DrawShop(Camera camera, Renderer renderer)
        {
            renderer.Draw(x, y, objectIcon, camera, ConsoleColor.DarkYellow);
        }

    }
}
