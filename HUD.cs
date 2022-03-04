using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class HUD
    {
        public void DrawHUD(NormalEnemy normalE, Player player, StrongEnemy strongE, WeakEnemy weakE) //this is ALL temp code
        {
            Console.SetCursorPosition(2, 27);
            Console.WriteLine("                                                            "); 
            Console.SetCursorPosition(2, 28);
            Console.WriteLine("                                                            "); 

            Console.SetCursorPosition(2, 27);
            Console.WriteLine("Player health:" + player.health); 

            if (normalE.recentTarget)
            {
                Console.SetCursorPosition(2, 28);
                Console.WriteLine("Normal Enemy health:" + normalE.health); 
            }
            else if (strongE.recentTarget)
            {
                Console.SetCursorPosition(2, 28);
                Console.WriteLine("Strong Enemy health:" + strongE.health); 
            }
            else if (weakE.recentTarget)
            {
                Console.SetCursorPosition(2, 28);
                Console.WriteLine("Weak Enemy health:" + weakE.health); 
            }
            else
            {
                Console.SetCursorPosition(2, 28);
                Console.WriteLine("                                                            "); 
            }
        }
    }
}
