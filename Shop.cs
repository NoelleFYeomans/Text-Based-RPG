using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Text_Based_RPG.ShopManager;

namespace Text_Based_RPG
{
    internal class Shop : GameObject
    {
        //Player player;
        //GlobalSettings global;
        public enum Merch
        {
            Potion,
            Attack,
            Key
        }

        public Merch merch;

        public int cost;
        public bool inShop = false;
        public bool exitingShop = false;
        public string merchName;

        public Shop(GlobalSettings global, Player player, int x, int y, Merch merch, int cost)
        {
            //this.global = global;
            objectIcon = global.shopObjectIcon;
            this.x = x;
            this.y = y;
            this.merch = merch;
            this.cost = cost;

            switch (merch)
            {
                case Merch.Potion:
                    merchName = "Potion";
                    break;
                case Merch.Attack:
                    merchName = "Attack Boost";
                    break;
                case Merch.Key:
                    merchName = "Key";
                    break;
            }

            //potionCost = global.potionCost;
            //this.player = player;
        }

        /*public bool canAfford()
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
        */

        public void DrawShop(Camera camera, Renderer renderer)
        {
            renderer.Draw(x, y, objectIcon, camera, ConsoleColor.DarkYellow);
        }

    }
}
