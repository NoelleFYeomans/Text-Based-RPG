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
        public int hasKeys = 0;

        public Player()
        {
            objectIcon = '@';
            health = 100;
            initalizeStrength = 25;
            InitializeCharacterPosition(7, 7);
            x = 7;
            y = 7;
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

            while (Console.KeyAvailable) Console.ReadKey(true); //prevents hold buffering

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
                canMove = false;
                doAttack = true;
            }

            if (doAttack)
            {
                MakeBeep(1000, 100);

                for (int i = 0; i <= enemyManager.enemyArray.Length - 1; i++)
                {
                    enemyManager.enemyArray[i].recentTarget = false;
                }

                for (int i = 0; i <= enemyManager.enemyArray.Length - 1; i++)
                {
                    if (x + deltaX == enemyManager.enemyArray[i].x && y + deltaY == enemyManager.enemyArray[i].y)
                    {
                        enemyManager.enemyArray[i].TakeDamage(initalizeStrength);
                        enemyManager.enemyArray[i].recentTarget = true;
                        //Console.WriteLine("most recent enemy is enemy " + i + " It's health is " + enemyManager.enemyArray[i].health);
                    }
                }

                doAttack = false;
            }

            ApplyAction(map); 

        }
    }
}
