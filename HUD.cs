using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class HUD
    {
        public void UpdateHUD(Player player, EnemyManager enemyManager, ShopManager shopManager, QuestManager qManager) //this is ALL temp code
        {
            ClearHUD();
            DisplayPlayerStats(player);
            DisplayEnemyStats(enemyManager);
            DisplayShop(shopManager);
            DisplayQuests(qManager);
        }

        public void ClearHUD()
        {
            for (int i = 17; i < 27; i++)
            {
                Console.SetCursorPosition(Console.WindowLeft, i);
                Console.Write(new string(' ', Console.BufferWidth));
            }
        }

        public void DisplayQuests(QuestManager qManager)
        {
            for (int i = 0; i < qManager.quests.Count; i++)
            {
                Console.SetCursorPosition(30, 5 + i);
                Quest quest = qManager.quests[i];
                if (quest.complete)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(quest.message + " (" + quest.achieved + "/" + quest.amount + ")");
                if(quest.complete)
                {
                    Console.Write(" ☺");
                    Console.ResetColor();
                }
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

        public void DisplayShop(ShopManager shopManager)
        {

            Console.SetCursorPosition(0, 23);
            if (shopManager.inShop)
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to buy a " + shopManager.latestShop.merchName + " for " + shopManager.latestShop.cost + " Gold Coins?");
                Console.WriteLine("1: Yes");
                Console.WriteLine("2: No");
            }
            else if(shopManager.exitingShop)
            {
                Console.WriteLine();
                Console.WriteLine("You can't afford a " + shopManager.latestShop.merchName + " They cost " + shopManager.latestShop.cost + " Gold Coins.");
            }
        }
    }
}
