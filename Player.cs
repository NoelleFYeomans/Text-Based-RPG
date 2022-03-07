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
        private int enemyAttacked = 0;
        public int hasKeys = 0;


        public void Update(Map map, NormalEnemy normalE, StrongEnemy strongE, WeakEnemy weakE, DoorKey doorKey) //you can pass in a different class to access it
        {

            if (health <= 0) //out of place?
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

            if (isAlive) //break this if statement if (!isAlive) return; then everything else
            {

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

                if (map.isDoor((y + deltaY), (x + deltaX)) && hasKeys <= 0 && !map.doorOpen) //DOORDOORDOORDOORDOOR
                {
                    canMove = false;
                    MakeBeep(500, 100);
                }
                else if (map.isDoor((y + deltaY), (x + deltaX)) && hasKeys >= 1 && !map.doorOpen)
                {
                    map.OpenDoor();
                    MakeBeep(1500, 100);
                    hasKeys--;
                }
                else
                {

                }

                if (x + deltaX == normalE.x && y + deltaY == normalE.y || x + deltaX == strongE.x && y + deltaY == strongE.y || x + deltaX == weakE.x && y + deltaY == weakE.y) //condense code, perhaps delegate to enemy
                {
                    canMove = false; //please fix all of this
                    doAttack = true;

                    if (x + deltaX == normalE.x && y + deltaY == normalE.y)//just to work for now, fix later
                    {
                        enemyAttacked = 1;
                    }
                    else if (x + deltaX == strongE.x && y + deltaY == strongE.y)
                    {
                        enemyAttacked = 2;
                    }
                    else if (x + deltaX == weakE.x && y + deltaY == weakE.y)
                    {
                        enemyAttacked = 3;
                    }
                }

                if (doAttack) // also move elsewhere eventually? idk maybe this does stay in update(); add sound to hitting wall
                {
                    MakeBeep(1000, 100);
                    if (enemyAttacked == 1) //temp
                    {
                        normalE.TakeDamage(initalizeStrength);
                        normalE.recentTarget = true;
                        strongE.recentTarget = false;
                        weakE.recentTarget = false;
                    }
                    else if (enemyAttacked == 2)
                    {
                        strongE.TakeDamage(initalizeStrength);
                        strongE.recentTarget = true;
                        weakE.recentTarget = false;
                        normalE.recentTarget = false;
                    }
                    else if (enemyAttacked == 3)
                    {
                        weakE.TakeDamage(initalizeStrength);
                        weakE.recentTarget = true;
                        strongE.recentTarget = false;
                        normalE.recentTarget = false;
                    }

                    doAttack = false;
                    enemyAttacked = 0;
                }

                ApplyAction();

            }  
        }
    }
}
