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
        static NormalEnemy normalEnemy = new NormalEnemy();
        static Map map = new Map();
        static HUD hud = new HUD();

        public void gameLoop()
        {
            //game loop
            while (!gameOver)
            {

                map.Draw();
                normalEnemy.Draw();
                player.Draw();
                hud.DrawHUD(normalEnemy, player);
                
                player.Update(map, normalEnemy);
                normalEnemy.Update(map, player);
                map.Update();
            }

            Console.ReadKey(true);
        }

    }
}
