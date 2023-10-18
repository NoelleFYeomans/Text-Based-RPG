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
        static GlobalSettings global = GlobalSettings.LoadFromJson(@"C:\Users\w0423300\Documents\GitHub\Text-Based-RPG\data.json");
        static Map map = new Map(global);
        static Player player = new Player(global);
        static Camera camera = new Camera(player, global);
        static Renderer renderer = new Renderer();
        static ShopManager shopManager = new ShopManager(global, player);
        //static Shop shop = new Shop(global, player);
        static QuestManager questManager = new QuestManager(player, global);
        static EnemyManager enemyManager = new EnemyManager(global, shopManager, questManager);
        static ItemManager itemManager = new ItemManager(map, global, questManager);
        static GameStateManager gameStateManager = new GameStateManager();
        static HUD hud = new HUD();

        public void gameLoop()
        {

            //game loop
            while (!gameStateManager.isGameLost(player) && !gameStateManager.isGameWon(enemyManager)) //gameOver state instead
            {
                map.Draw(camera, renderer);
                itemManager.DrawItems(camera, renderer); 
                player.Draw(camera, renderer);
                shopManager.DrawShops(camera, renderer);
                questManager.DrawGivers(camera, renderer);
                enemyManager.DrawEnemies(camera, renderer); //Camera print outside walls(LAST BUG)

                map.Update();
                itemManager.UpdateItems(player);
                hud.UpdateHUD(player, enemyManager, shopManager, questManager);
                player.Update(map, enemyManager, questManager, shopManager, camera);
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
                Console.WriteLine("GameState Error. Please Contact Developer.");
            }

            Console.ReadKey(true);
        }

    }
}
