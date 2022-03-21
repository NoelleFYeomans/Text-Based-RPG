using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class EnemyManager //same logic here applies to Items. do this, then items
    {
        //declaration & instantiation
        Enemy[] enemyArray = new Enemy[50]; //hardcoded?

        //Fills Array
        public void CreateAllEnemies() //may name better?
        {
            for(int i = 0; i <= enemyArray.Length - 1; i++)
            {
                if (i <= 35) //hardcoded?
                {
                    enemyArray[i] = new WeakEnemy();
                }
                else if (i <= 49) //hardcoded?
                {
                    enemyArray[i] = new NormalEnemy();
                }
                else if (i >= enemyArray.Length - 1)
                {
                    enemyArray[i] = new StrongEnemy();
                }
            }
        }

        public void InitializeAllEnemies()
        {
            for (int i = 0; i <= enemyArray.Length - 1; i++)
            {
                if (i <= 35) //hardcoded?
                {
                    //enemyArray[i].InitializeCharacter()
                }
                else if (i <= 48) //hardcoded?
                {
                    //I need a getter for specific enemy stats
                    //enemyArray[i].InitializeCharacter('E', 7, 7, 100, 10);
                }
                else if (i >= enemyArray.Length - 2)
                {
                    //enemyArray[i].InitializeCharacter()
                }
            }
        }

        public void UpdateAllEnemies()
        {
            for (int i = 0; i <= enemyArray.Length - 1; i++)
            {
                //enemyArray[i].Update(); //doesn't work, need a way to access enemy subclass methods/functions
            }
        }

        public void DrawAllEnemies()
        {
            for (int i = 0; i <= enemyArray.Length - 1; i++)
            {
                //same issue as Update();
            }
        }


    }
}
