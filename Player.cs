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

        public Player(GlobalSettings global)
        {
            objectIcon = global.playerObjectIcon;
            health = global.playerHealth;
            initalizeStrength = global.playerInitStrength;
            InitializeCharacterPosition(global.playerSpawnX, global.playerSpawnY);
        }

        public void Update(Map map, EnemyManager enemyManager, Camera camera)
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

            camera.PositionCam(x + deltaX, y + deltaY);

            while (Console.KeyAvailable) Console.ReadKey(true); //prevents hold buffering

            if (map.isImpassableObstacle(y + deltaY, x + deltaX)) //perform checks before movement
            {
                canMove = false;
                MakeBeep(500, 100);
            }

            if (map.isDoor((y + deltaY), (x + deltaX)) && (!map.doorOpen || !map.ironDoorOpen))
            {
                if (hasKeys >= 1 && map.mapRawData[y + deltaY][x + deltaX] == 'D')
                {
                    map.OpenDoor();
                    MakeBeep(1500, 100);
                    hasKeys--;
                }
                else if (hasKeys >= 1 && map.mapRawData[y + deltaY][x + deltaX] == 'I')
                {
                    map.OpenIronDoor();
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
                    }
                }

                doAttack = false;
            }

            if (canMove)
            {
                camera.PositionCam(x + deltaX, y + deltaY);
            }
            else
            {
                camera.PositionCam(x, y);
            }

            ApplyAction(map); 

        }
    }
}
