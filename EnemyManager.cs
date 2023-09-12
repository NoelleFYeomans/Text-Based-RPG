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
        Shop shop;

        public EnemyManager(GlobalSettings global, Shop shop) //this is the constructor
        {
            CreateEnemies(global);
            InitializeEnemyPositions();
            this.shop = shop;
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
        private void CreateEnemies(GlobalSettings global) 
        {
            for(int i = 0; i <= enemyArray.Length - 1; i++)
            {
                if (i <= (enemyArray.Length - enemyArray.Length / 2)) 
                {
                    enemyArray[i] = new WeakEnemy(global);
                }
                else if (i <= enemyArray.Length - 3) 
                {
                    enemyArray[i] = new NormalEnemy(global);
                }
                else if (i >= enemyArray.Length - 2)
                {
                    enemyArray[i] = new StrongEnemy(global);
                }
            }
        }

        private void InitializeEnemyPositions() 
        {
            for (int i = 0; i <= enemyArray.Length - 1; i++)
            {
                if (i <= enemyArray.Length - 2)
                {
                    enemyArray[i].InitializeCharacterPosition(GenerateRandNum(80, 110), GenerateRandNum(4, 22));
                }
                else if (i <= enemyArray.Length - 1)
                {
                    enemyArray[i].InitializeCharacterPosition(70, 4);
                }
            }
        }

        public void UpdateEnemies(Map map, Player player, EnemyManager enemyManager)
        {
            if(shop.inShop == false)
            {
                for (int i = 0; i <= enemyArray.Length - 1; i++)
                {
                    enemyArray[i].Update(map, player, enemyManager);
                }
            }
        }

        public void DrawEnemies(Camera camera, Renderer renderer)
        {
            for (int i = 0; i <= enemyArray.Length - 1; i++)
            {
                enemyArray[i].Draw(camera, renderer);
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
