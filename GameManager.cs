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
        static NormalEnemy normalEnemy = new NormalEnemy();
        static StrongEnemy strongEnemy = new StrongEnemy();
        static WeakEnemy weakEnemy = new WeakEnemy();
        static Map map = new Map();
        static HUD hud = new HUD();
        static ItemManager itemManager = new ItemManager();

        public void gameLoop()
        {
            player.InitializeCharacterPosition(5, 5); //positions temporarily managed here
            normalEnemy.InitializeCharacterPosition(7, 7);
            strongEnemy.InitializeCharacterPosition(65, 20);
            weakEnemy.InitializeCharacterPosition(20, 15);
            itemManager.InitAllItems();

            //game loop
            while (!gameOver)
            {

                map.Draw();
                hud.DrawHUD(normalEnemy, player, strongEnemy, weakEnemy);
                itemManager.DrawItems();
                player.Draw();
                enemyManager.DrawEnemies();
                normalEnemy.Draw(); // fix HUD display & method for displaying last enemy(requires enemy manager & instantiation to be in place)
                strongEnemy.Draw(); //the fucking camera & making the map bigger to prove it works
                weakEnemy.Draw(); // remember game/win state
                
                map.Update();
                itemManager.UpdateItems(player);
                player.Update(map, enemyManager);
                enemyManager.UpdateEnemies();
                normalEnemy.Update(map, player, enemyManager);
                strongEnemy.Update(map, player, enemyManager);
                weakEnemy.Update(map, player, enemyManager);
            }

            Console.ReadKey(true);
        }

    }
}
