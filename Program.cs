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

                player.UpdatePosition(map, enemy);
                enemy.UpdatePosition();
                map.Update();
            }

            Console.ReadKey(true);

        }
    }
}
