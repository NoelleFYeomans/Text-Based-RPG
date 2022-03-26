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
            Console.SetCursorPosition(2, 27);
            Console.WriteLine("                                                            "); 
            Console.SetCursorPosition(2, 28);
            Console.WriteLine("                                                            "); 

            Console.SetCursorPosition(0, 26);
            Console.WriteLine("Player health:" + player.health);
            Console.WriteLine("Player strength:" + player.initalizeStrength);
            Console.WriteLine("# of keys:" + player.hasKeys);
        }
    }
}
