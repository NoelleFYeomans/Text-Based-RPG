using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class GameStateManager
    {
        public bool isGameLost(Player player)
        {
            if (player.health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isGameWon(EnemyManager enemyManager)
        {
            for (int i = 0; i <= enemyManager.enemyArray.Length - 1; i++)
            {
                if (enemyManager.enemyArray[i].health >= 1)
                {
                    return false;
                }
                else
                {

                }
            }
            return true;
        }

        public void GameOverMessage()
        {
            Console.Clear();
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("You have been killed. Game Over.");
        }

        public void GameWinMessage()
        {
            Console.Clear();
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("All enemies have been slain. You are a Hero!");
        }
    }
}
