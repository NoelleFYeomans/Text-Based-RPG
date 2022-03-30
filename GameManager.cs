using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class GameManager
    {
        //declaration & instantiation
        static GlobalSettings global = new GlobalSettings();
        static Map map = new Map();
        static Player player = new Player();
        static Camera camera = new Camera(player);
        static Renderer renderer = new Renderer();
        static EnemyManager enemyManager = new EnemyManager(map);
        static ItemManager itemManager = new ItemManager(map);
        static GameStateManager gameStateManager = new GameStateManager();
        static HUD hud = new HUD();

        public void gameLoop()
        {
            //game loop
            while (!gameStateManager.isGameLost(player) && !gameStateManager.isGameWon(enemyManager))
            {
                map.Draw(camera, renderer);
                itemManager.DrawItems(camera, renderer); 
                player.Draw(camera, renderer);//map colour & renderer colour & health/attack clamps. Nerf enemy damage
                enemyManager.DrawEnemies(camera, renderer); //camera print outside walls, GlobalSettings settup

                map.Update();
                itemManager.UpdateItems(player);
                hud.UpdateHUD(player, enemyManager); //postive Y camera stutter caused by HUD, negative Y camera stutter cause unk
                player.Update(map, enemyManager, camera);
                enemyManager.UpdateEnemies(map, player, enemyManager);
            }

            if (gameStateManager.isGameLost(player))
            {
                gameStateManager.GameOverMessage();
            }
            else if (gameStateManager.isGameWon(enemyManager))
            {
                gameStateManager.GameWinMessage();
            }
            else
            {
                Console.WriteLine("GameState Error.");
            }

            Console.ReadKey(true);
        }

    }
}
