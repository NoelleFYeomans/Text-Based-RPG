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
        static Map map = new Map();
        static Player player = new Player();
        static EnemyManager enemyManager = new EnemyManager(map);
        static ItemManager itemManager = new ItemManager(map);
        static HUD hud = new HUD();

        public void gameLoop()
        {

            //game loop
            while (!gameOver)
            {

                map.Draw();
                itemManager.DrawItems(); 
                player.Draw(); //redo map colour method
                enemyManager.DrawEnemies(); //HUD!!, gameover/win state!!, camera!!, GlobalSettings setup
                
                map.Update();
                itemManager.UpdateItems(player);
                hud.DrawHUD(player, enemyManager);
                player.Update(map, enemyManager);
                //hud.DrawHUD(player, enemyManager);
                enemyManager.UpdateEnemies(map, player, enemyManager);
            }

            Console.ReadKey(true);
        }

    }
}
