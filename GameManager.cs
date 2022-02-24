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
        static HUD hud = new HUD();

        public void gameLoop()
        {
            //game loop
            while (!gameOver)
            {

                map.Draw();
                enemy.Draw();
                player.Draw();
                hud.DrawHUD(enemy, player);
                
                player.Update(map, enemy, player);
                enemy.Update(map, enemy, player);
                map.Update();
            }

            Console.ReadKey(true);
        }

    }
}
