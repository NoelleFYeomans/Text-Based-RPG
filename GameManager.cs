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
            player.InitializeCharacter('@', 5, 5, 100, 25);
            normalEnemy.InitializeCharacter('E', 7, 7, 100, 10);
            strongEnemy.InitializeCharacter('S', 65, 20, 150, 20);
            weakEnemy.InitializeCharacter('W', 20, 15, 50, 1);
            itemManager.InitAllItems();
            DoorKey tempKey = new DoorKey();

            //game loop
            while (!gameOver)
            {

                map.Draw();
                hud.DrawHUD(normalEnemy, player, strongEnemy, weakEnemy);
                itemManager.DrawItems();
                player.Draw(); //if player dies, they need to despawn before player.update
                normalEnemy.Draw();
                strongEnemy.Draw();
                weakEnemy.Draw();
                
                map.Update();
                itemManager.UpdateItems(player);
                player.Update(map, normalEnemy, strongEnemy, weakEnemy, tempKey);
                normalEnemy.Update(map, player, strongEnemy, weakEnemy);
                strongEnemy.Update(map, player, normalEnemy, weakEnemy);
                weakEnemy.Update(map, player, normalEnemy, strongEnemy);
            }

            Console.ReadKey(true);
        }

    }
}
