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
        public bool exitingShop = false;
        public int cost;

        public Shop latestShop;


        public ShopManager(GlobalSettings global, Player player)
        {
            this.global = global;
            //potionCost = global.potionCost;
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
                if (x + deltaX == shops[i].x && y + deltaY == shops[i].y) //maybe I get the enemyArray x/y out of manager somehow?
                {
                    latestShop = shops[i];
                    return true;
                }
            }
            return false;
        }

        public bool canAfford()
        {
            if (player.goldHeld >= latestShop.cost)
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
            exitingShop = true;
        }

        public void enterShop()
        {
            inShop = true;
        }

        public void Update()
        {


            if (exitingShop)
            {
                exitingShop = false;
            }

            if (inShop)
            {
                if (canAfford() == false)
                {
                    exitShop();
                }
            }           

        }
    }
}
