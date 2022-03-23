using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class EnemyManager //same logic here applies to Items. do this, then items. also make constructor
    {
        //declaration & instantiation
        public Enemy[] enemyArray = new Enemy[50]; //hardcoded?

        //needed for update //probably wrong
        Player player = new Player();
        Map map = new Map();
        EnemyManager enemyManager = new EnemyManager();


        public EnemyManager() //this is the constructor
        {
            CreateEnemies();
            InitializeEnemyPositions();
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

        private void InitializeEnemyPositions()
        {
            for (int i = 0; i <= enemyArray.Length - 1; i++)
            {
                if (i <= (enemyArray.Length - enemyArray.Length/2)) 
                {
                    enemyArray[i].InitializeCharacterPosition(1, 1); //need a way to handle position
                }
                else if (i <= enemyArray.Length - 3) 
                {
                    enemyArray[i].InitializeCharacterPosition(10, 10); 
                }
                else if (i >= enemyArray.Length - 2)
                {
                    enemyArray[i].InitializeCharacterPosition(25, 25);
                }
            }
        }

        public void UpdateEnemies()
        {
            for (int i = 0; i <= enemyArray.Length - 1; i++)
            {
                if (enemyArray[i] is WeakEnemy)
                {
                    ((WeakEnemy)enemyArray[i]).Update(map, player, enemyManager);
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
                if (x + deltaX == enemyArray[i].x && y + deltaY == enemyArray[i].y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
