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
        Enemy[] enemyArray = new Enemy[50]; //hardcoded?

        //Fills Array
        public void CreateEnemies() 
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

        public void InitializeEnemyPositions()
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
                    
                }
                else if (enemyArray[i] is NormalEnemy)
                {

                }
                else if (enemyArray[i] is StrongEnemy)
                {

                }
            }
        }

        public void DrawEnemies()
        {
            for (int i = 0; i <= enemyArray.Length - 1; i++)
            {
                if (enemyArray[i] is WeakEnemy)
                {

                }
                else if (enemyArray[i] is NormalEnemy)
                {

                }
                else if (enemyArray[i] is StrongEnemy)
                {

                }
            }
        }


    }
}
