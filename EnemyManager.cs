using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class EnemyManager //same logic here applies to Items. do this, then items.
    {
        //declaration & instantiation
        public Enemy[] enemyArray = new Enemy[50]; //hardcoded?

        public EnemyManager(Map map) //this is the constructor
        {
            CreateEnemies();
            InitializeEnemyPositions(map);
        }

        static Random rand = new Random();

        public int GenerateRandNum(int minValue, int maxValue)
        {
            int output = rand.Next(minValue, maxValue);
            return output;
        }

        public void InitPosProtection(Map map)
        {
            for (int i = 0; i <= enemyArray.Length - 1; i++)
            {
                while (map.isImpassableObstacle(enemyArray[i].y, enemyArray[i].x) || map.isDoor(enemyArray[i].y, enemyArray[i].x))
                {
                    enemyArray[i].x = GenerateRandNum(0, map.mapRawData[0].Length);
                    enemyArray[i].y = GenerateRandNum(0, map.mapRawData.Length);
                }
            }
        }

        //Fills Array
        private void CreateEnemies() 
        {
            for(int i = 0; i <= enemyArray.Length - 1; i++)
            {
                if (i <= (enemyArray.Length - enemyArray.Length / 2)) 
                {
                    enemyArray[i] = new WeakEnemy();
                }
                else if (i <= enemyArray.Length - 3) 
                {
                    enemyArray[i] = new NormalEnemy();
                }
                else if (i >= enemyArray.Length - 2)
                {
                    enemyArray[i] = new StrongEnemy();
                }
            }
        }

        private void InitializeEnemyPositions(Map map) //nothing stops items from occupying same position
        {
            for (int i = 0; i <= enemyArray.Length - 1; i++)
            {
                enemyArray[i].InitializeCharacterPosition(GenerateRandNum(80, 110), GenerateRandNum(4, 22));
                //InitPosProtection(map); //enemies spawn in impassable objects, why?
            }
        }

        public void UpdateEnemies(Map map, Player player, EnemyManager enemyManager)
        {
            for (int i = 0; i <= enemyArray.Length - 1; i++)
            {
                if (enemyArray[i] is WeakEnemy)
                {
                    ((WeakEnemy)enemyArray[i]).Update(map, player, enemyManager); //check into it
                    //(enemyArray[i] as WeakEnemy).Update(map, player, enemyManager); //this also works, and might be easier to read
                }
                else if (enemyArray[i] is NormalEnemy)
                {
                    ((NormalEnemy)enemyArray[i]).Update(map, player, enemyManager);
                }
                else if (enemyArray[i] is StrongEnemy)
                {
                    ((StrongEnemy)enemyArray[i]).Update(map, player, enemyManager);
                }
            }
        }

        public void DrawEnemies()
        {
            for (int i = 0; i <= enemyArray.Length - 1; i++)
            {
                if (enemyArray[i] is WeakEnemy)
                {
                    ((WeakEnemy)enemyArray[i]).Draw();
                }
                else if (enemyArray[i] is NormalEnemy)
                {
                    ((NormalEnemy)enemyArray[i]).Draw();
                }
                else if (enemyArray[i] is StrongEnemy)
                {
                    ((StrongEnemy)enemyArray[i]).Draw();
                }
            }
        }

        public bool IsCoordinatesOccupied(int x, int deltaX, int y, int deltaY) 
        {
            for (int i = 0; i <= enemyArray.Length - 1; i++)
            {
                if (x + deltaX == enemyArray[i].x && y + deltaY == enemyArray[i].y) //maybe I get the enemyArray x/y out of manager somehow?
                {
                    return true;
                }
            }
            return false;
        }
    }
}
