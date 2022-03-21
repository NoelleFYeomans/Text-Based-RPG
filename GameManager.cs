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
                player.Draw(); //enemy.iscoordinatesoccupied > enemymanager > enemy array instantiation
                normalEnemy.Draw(); // fix HUD display(requires enemy manager & instantiation to be in place) & list of wall chars
                strongEnemy.Draw(); //the fucking camera & making the map bigger to prove it works
                weakEnemy.Draw(); // remember game/win state
                
                map.Update();
                itemManager.UpdateItems(player);
                player.Update(map, normalEnemy, strongEnemy, weakEnemy);
                normalEnemy.Update(map, player, strongEnemy, weakEnemy);
                strongEnemy.Update(map, player, normalEnemy, weakEnemy);
                weakEnemy.Update(map, player, normalEnemy, strongEnemy);
            }

            Console.ReadKey(true);
        }

    }
}
