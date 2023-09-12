using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class HUD
    {
        public void UpdateHUD(Player player, EnemyManager enemyManager, Shop shop) //this is ALL temp code
        {
            ClearHUD();
            DisplayPlayerStats(player);
            DisplayEnemyStats(enemyManager);
            if (shop.inShop)
            {
                DisplayShop(shop, shop.canAfford());
            }
        }

        public void ClearHUD()
        {
            for (int i = 17; i < 27; i++)
            {
                Console.SetCursorPosition(Console.WindowLeft, i);
                Console.Write(new string(' ', Console.BufferWidth));
            }
        }

        public void DisplayEnemyStats(EnemyManager enemyManager)
        {
            for (int i = 0; i <= enemyManager.enemyArray.Length - 1; i++)
            {
                if (enemyManager.enemyArray[i].recentTarget == true)
                {
                    Console.SetCursorPosition(20, 17);
                    Console.WriteLine("Enemy health: " + enemyManager.enemyArray[i].health);
                }
            }
        }
        
        public void DisplayPlayerStats(Player player)
        {
            Console.SetCursorPosition(0, 17);
            Console.WriteLine("Player health: " + player.health);
            Console.WriteLine("Player strength: " + player.initalizeStrength);
            Console.WriteLine("# of Gold Coins: " + player.goldHeld);
            Console.WriteLine("# of keys: " + player.hasKeys);
            Console.WriteLine("# of potions held: " + player.potionsHeld);
            Console.WriteLine("Press 'P to use held potions");
        }

        public void DisplayShop(Shop shop, bool canAfford)
        {

            Console.SetCursorPosition(0, 23);

            if (canAfford)
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to buy a Potion for " + shop.potionCost + " Gold Coins?");
                Console.WriteLine("1: Yes");
                Console.WriteLine("2: No");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You can't afford a Potion. They cost " + shop.potionCost + " Gold Coins.");
            }
        }
    }
}
