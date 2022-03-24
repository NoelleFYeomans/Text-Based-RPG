using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class Player : GameCharacter
    {
        ConsoleKeyInfo key = new ConsoleKeyInfo();
        private int enemyAttacked = 0; //probably removing this
        public int hasKeys = 0;

        public Player()
        {
            objectIcon = '@';
            health = 100;
            initalizeStrength = 25;
        }

        public void Update(Map map, EnemyManager enemyManager) //properly implement enemy manager
        {

            if (health <= 0) //this is where the player dies
            {
                isAlive = false;
            }


            key = Console.ReadKey(true);

            //I want to have the player's position before the move saved
            priorPositionX = x;
            priorPositionY = y;

            //resetting the values relevent variables
            deltaX = 0;
            deltaY = 0;
            canMove = true;

            if (!isAlive) return; //implement guard clause around here

            //obtain player input/desired movement
            switch (key.Key) 
            {
                case ConsoleKey.W:
                    deltaY = -1;
                    break;
                case ConsoleKey.S:
                    deltaY = +1;
                    break;
                case ConsoleKey.D:
                    deltaX = +1;
                    break;
                case ConsoleKey.A:
                    deltaX = -1;
                    break;
            }

            //clamps, collisions, & other checks
            x = Clamp(x, 0, 100); //woops
            y = Clamp(y, 0, 100);


            if (map.isImpassableObstacle(y + deltaY, x + deltaX)) //perform checks before movement
            {
                canMove = false;
                MakeBeep(500, 100);
            }

            if (map.isDoor((y + deltaY), (x + deltaX)) && !map.doorOpen)
            {
                if (hasKeys >= 1)
                {
                    map.OpenDoor();
                    MakeBeep(1500, 100);
                    hasKeys--;
                }
                else
                {
                    canMove = false;
                    MakeBeep(500, 100);
                }

            }

            if (enemyManager.IsCoordinatesOccupied(x, deltaX, y, deltaY))
            {
                canMove = false; //please fix all of this
                doAttack = true;

                //recentTarget
                //if (x + deltaX == normalE.x && y + deltaY == normalE.y)//just to work for now, fix later
                //{
                //    enemyAttacked = 1;
                //}
                //else if (x + deltaX == strongE.x && y + deltaY == strongE.y)
                //{
                //    enemyAttacked = 2;
                //}
                //else if (x + deltaX == weakE.x && y + deltaY == weakE.y)
                //{
                //    enemyAttacked = 3;
                //}
            }

            if (doAttack)
            {
                MakeBeep(1000, 100);
                if (enemyAttacked == 1) //temp
                {
                    //in this case, i is the value in the array that stores the enemy I interacted with last
                    enemyManager.enemyArray[i].TakeDamage(initalizeStrength); //how do I get specific enemy from player class

                    for (int i = 0; i <= enemyManager.enemyArray[i].Length - 1; i++) //why?
                    {
                        enemyManager.enemyArray[i].recentTarget = false;
                    }

                    enemyManager.enemyArray[i].recentTarget = true;
                }
                else if (enemyAttacked == 2)
                {
                    //strongE.TakeDamage(initalizeStrength);
                    //strongE.recentTarget = true;
                    //weakE.recentTarget = false;
                    //normalE.recentTarget = false;
                }
                else if (enemyAttacked == 3)
                {
                    //weakE.TakeDamage(initalizeStrength);
                    //weakE.recentTarget = true;
                    //strongE.recentTarget = false;
                    //normalE.recentTarget = false;
                }

                doAttack = false;
                enemyAttacked = 0;
            }

            ApplyAction(); 

        }
    }
}
