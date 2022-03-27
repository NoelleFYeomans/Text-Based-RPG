using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class HUD
    {
        public void DrawHUD(Player player, EnemyManager enemyManager) //this is ALL temp code
        {
            ClearHUD();
            DisplayPlayerStats(player);
            DisplayEnemyStats(enemyManager);

        }

        public void ClearHUD()
        {
            Console.SetCursorPosition(0, 26);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, 27);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, 28);
            Console.Write(new string(' ', Console.BufferWidth));
        }

        public void DisplayEnemyStats(EnemyManager enemyManager)
        {
            for (int i = 0; i <= enemyManager.enemyArray.Length - 1; i++)
            {
                if (enemyManager.enemyArray[i].recentTarget == true)
                {
                    Console.SetCursorPosition(50, 26);
                    Console.WriteLine("Enemy health: " + enemyManager.enemyArray[i].health);
                }
            }
        }
        
        public void DisplayPlayerStats(Player player)
        {
            Console.SetCursorPosition(0, 26);
            Console.WriteLine("Player health: " + player.health);
            Console.WriteLine("Player strength: " + player.initalizeStrength);
            Console.WriteLine("# of keys: " + player.hasKeys);
        }
    }
}
