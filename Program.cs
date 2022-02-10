using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Program
    {
        //bool for game loop
        static private bool gameOver = false;

        //declaration & instantiation
        static Player player = new Player();
        static Enemy enemy = new Enemy();
        static Map map = new Map();

        static void Main(string[] args)
        {
            //game loop
            while (!gameOver)
            {
                Console.Clear();

                map.Draw();
                enemy.DrawPosition();
                player.DrawPosition();

                //temporary ingame text
                Console.SetCursorPosition(35, 3);
                Console.WriteLine("<---------------");
                Console.SetCursorPosition(35, 4);
                Console.WriteLine("This hole in the map is intentional, I am aware that");
                Console.SetCursorPosition(35, 5);
                Console.WriteLine("the game crashes if you leave the bounds since the collison detection");
                Console.SetCursorPosition(35, 6);
                Console.WriteLine("looks for map X/Y coords. this is just for testing & is not permanent :)");

                player.UpdatePosition(map, enemy, player);
                enemy.UpdatePosition(map, enemy, player);
                map.Update();
            }

            Console.ReadKey(true);

        }
    }
}
