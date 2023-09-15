using System;
using System.Collections.Generic;
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
                shops[i] = new Shop(global, player, global.shopPosX[i], global.shopPosY[i]);
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
                    return true;
                }
            }
            return false;
        }

    }
}
