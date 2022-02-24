using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class HUD
    {
        public void DrawHUD(Enemy enemy, Player player) //temp
        {
            Console.SetCursorPosition(2, 20);//temp code
            Console.WriteLine("                                                            "); //temp cod
            Console.SetCursorPosition(2, 21);//temp code
            Console.WriteLine("                                                            "); //temp code
            Console.SetCursorPosition(2, 20);//temp code
            Console.WriteLine("Enemy health:" + enemy.health); //temp cod
            Console.SetCursorPosition(2, 21);//temp code
            Console.WriteLine("Player health:" + player.health); //temp code
        }
    }
}
