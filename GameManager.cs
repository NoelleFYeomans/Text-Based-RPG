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
        static ItemManager itemManager = new ItemManager();
        static Map map = new Map();
        static HUD hud = new HUD();

        public void gameLoop()
        {
            player.InitializeCharacterPosition(5, 5); //positions temporarily managed here

            //game loop
            while (!gameOver)
            {

                map.Draw();
                itemManager.DrawItems(); //potions/keys not drawing for some reason?
                player.Draw(); //remember to address the Polymorphism issue & the Random generation being the same for all normal enemies
                enemyManager.DrawEnemies(); //Recent enemy attacked, takeDamage, HUD, itemManager, gameover/win state, camera
                
                map.Update();
                itemManager.UpdateItems(player);
                player.Update(map, enemyManager);
                enemyManager.UpdateEnemies(map, player, enemyManager);
            }

            Console.ReadKey(true);
        }

    }
}
