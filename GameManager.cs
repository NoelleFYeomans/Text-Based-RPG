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
        static StrongEnemy strongEnemy = new StrongEnemy();
        static WeakEnemy weakEnemy = new WeakEnemy();
        static Map map = new Map();
        static HUD hud = new HUD();

        public void gameLoop()
        {
            normalEnemy.InitializeEnemy('E', 7, 7, 100, 10);
            strongEnemy.InitializeEnemy('S', 30, 10, 150, 20);
            weakEnemy.InitializeEnemy('W', 45, 6, 50, 1);

            //game loop
            while (!gameOver)
            {

                map.Draw();
                normalEnemy.Draw();
                strongEnemy.Draw();
                weakEnemy.Draw();
                player.Draw();
                hud.DrawHUD(normalEnemy, player, strongEnemy, weakEnemy);
                
                player.Update(map, normalEnemy, strongEnemy, weakEnemy);
                normalEnemy.Update(map, player, strongEnemy, weakEnemy);
                strongEnemy.Update(map, player, normalEnemy, weakEnemy);//please fix all of this
                weakEnemy.Update(map, player, normalEnemy, strongEnemy);
                map.Update();
            }

            Console.ReadKey(true);
        }

    }
}
