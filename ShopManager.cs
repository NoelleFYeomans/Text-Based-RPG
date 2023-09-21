using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class ShopManager
    {

        public Shop[] shops;
        private GlobalSettings global;
        private Player player;
        public bool inShop = false;
        public int currentSelection;

        public Shop latestShop;


        public ShopManager(GlobalSettings global, Player player)
        {
            this.global = global;
            this.player = player;
            CreateShops();
        }

        private void CreateShops()
        {
            shops = new Shop[global.shopCount];
            for (int i = 0; i <= shops.Length - 1; i++)
            {
                shops[i] = new Shop(global, player, global.shopPosX[i], global.shopPosY[i], global.shopMerchs[i], global.shopCosts[i]);
            }
        }

        public void DrawShops(Camera camera, Renderer renderer)
        {
            foreach (Shop shop in shops)
            {
                shop.DrawShop(camera, renderer);
            }
        }

        public bool IsCoordinatesOccupied(int x, int deltaX, int y, int deltaY)
        {
            for (int i = 0; i <= shops.Length - 1; i++)
            {
                if (x + deltaX == shops[i].x && y + deltaY == shops[i].y)
                {
                    latestShop = shops[i];
                    return true;
                }
            }
            return false;
        }

        public bool canAfford()
        {
            if (player.goldHeld >= latestShop.costs[currentSelection])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void exitShop()
        {
            inShop = false;
        }

        public void enterShop()
        {
            inShop = true;
            currentSelection = 0;
        }

        public void goUp()
        {
            if(currentSelection > 0)
            {
                currentSelection--;
            }
        }
        
        public void goDown()
        {
            if(currentSelection < latestShop.merchs.Count)
            {
                currentSelection++;
            }
        }

        public void select()
        {
            if(currentSelection == latestShop.merchs.Count)
            {
                exitShop();
            }
            else
            {
                if(canAfford())
                    player.buyMerch(latestShop.merchs[currentSelection], latestShop.costs[currentSelection]);
            }
        }
    }
}
