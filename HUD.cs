using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class HUD
    {
        public void DrawHUD(NormalEnemy normalE, Player player, StrongEnemy strongE, WeakEnemy weakE) //temp
        {
            Console.SetCursorPosition(2, 27);//temp code
            Console.WriteLine("                                                            "); //temp code
            Console.SetCursorPosition(2, 28);//temp code
            Console.WriteLine("                                                            "); //temp code

            Console.SetCursorPosition(2, 27);//temp code
            Console.WriteLine("Player health:" + player.health); //temp code

            if (normalE.recentTarget)
            {
                Console.SetCursorPosition(2, 28);//temp code
                Console.WriteLine("Normal Enemy health:" + normalE.health); //temp code
            }
            else if (strongE.recentTarget)
            {
                Console.SetCursorPosition(2, 28);//temp code
                Console.WriteLine("Strong Enemy health:" + strongE.health); //temp code
            }
            else if (weakE.recentTarget)
            {
                Console.SetCursorPosition(2, 28);//temp code
                Console.WriteLine("Weak Enemy health:" + weakE.health); //temp code
            }
            else
            {
                Console.SetCursorPosition(2, 28);//temp code
                Console.WriteLine("                                                            "); //temp code
            }
        }
    }
}
