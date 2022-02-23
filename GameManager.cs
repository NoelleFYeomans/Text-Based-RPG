using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class GameManager
    {
        //bool for game loop
        static private bool gameOver = false;

        //declaration & instantiation
        static Player player = new Player();
        static Enemy enemy = new Enemy();
        static Map map = new Map();

        public void gameLoop()
        {
            //game loop
            while (!gameOver)
            {
                Console.Clear();

                map.Draw();
                enemy.DrawPosition();
                player.DrawPosition();

                player.UpdatePosition(map, enemy, player);
                enemy.UpdatePosition(map, enemy, player);
                map.Update();
            }

            Console.ReadKey(true);
        }

    }
}
