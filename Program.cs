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

        //initialization
        static Player player = new Player();
        static Enemy enemy = new Enemy();
        static Map map = new Map();

        static void Main(string[] args)
        {
            //initial draw to screen
            map.Draw();
            enemy.DrawPosition();
            player.DrawPosition();

            while (!gameOver)
            {
                player.UpdatePosition();
                enemy.UpdatePosition();
                map.Update();


                Console.Clear();
                map.Draw();
                enemy.DrawPosition();
                player.DrawPosition();
            }

            Console.ReadKey(true);
        }
    }
}
