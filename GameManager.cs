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
        static EnemyManager enemyManager = new EnemyManager();
        static Map map = new Map();
        static HUD hud = new HUD();
        static ItemManager itemManager = new ItemManager();

        public void gameLoop()
        {
            player.InitializeCharacterPosition(5, 5); //positions temporarily managed here
            itemManager.InitAllItems();

            //game loop
            while (!gameOver)
            {

                map.Draw();
                itemManager.DrawItems();
                player.Draw();
                enemyManager.DrawEnemies();
                
                map.Update();
                itemManager.UpdateItems(player);
                player.Update(map, enemyManager);
                enemyManager.UpdateEnemies(map, player, enemyManager);
            }

            Console.ReadKey(true);
        }

    }
}
