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
        public int potionsHeld = 0;
        public int goldHeld = 0;

        private int potionValue;
        private GlobalSettings global;
        //private Shop shop;
        //private QuestManager questManager;

        public Player(GlobalSettings global)
        {
            objectIcon = global.playerObjectIcon;
            health = global.playerHealth;
            initalizeStrength = global.playerInitStrength;
            InitializeCharacterPosition(global.playerSpawnX, global.playerSpawnY);
            potionValue = global.healthBoost;
            this.global = global;
        }

        private void UsePotion()
        {
            if (potionsHeld > 0)
            {
                health = health + potionValue;
                health = Clamp(health, 0, 100);
                potionsHeld--;
            }
            else
            {
                //nothing
            }
        }

        public void gainGold(int amount)
        {
            goldHeld += amount;
        }

        /*public void setShop(Shop shop)
        {
            this.shop = shop;
        }*/

        public void Update(Map map, EnemyManager enemyManager, QuestManager qManager, ShopManager shopManager, Camera camera)
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
                case ConsoleKey.P:
                    UsePotion();
                    break;
                case ConsoleKey.D1:
                    if (shopManager.inShop)
                    {
                        buyMerch(shopManager);
                        shopManager.exitShop();
                    }
                    break;
                case ConsoleKey.D2:
                    if(shopManager.inShop)
                        shopManager.exitShop();
                    break;
            }

            while (Console.KeyAvailable) Console.ReadKey(true); //prevents hold buffering

            if (shopManager.inShop)
            {
                canMove = false;
            }

            if (map.isImpassableObstacle(y + deltaY, x + deltaX)) //perform checks before movement
            {
                canMove = false;
                MakeBeep(500, 100);
            }

            if (map.isDoor((y + deltaY), (x + deltaX)))
            {
                if (hasKeys >= 1 && map.mapRawData[y + deltaY][x + deltaX] == 'D' && !map.doorOpen)
                {
                    map.OpenDoor();
                    MakeBeep(1500, 100);
                    hasKeys--;
                }
                else if (hasKeys >= 1 && map.mapRawData[y + deltaY][x + deltaX] == 'I' && !map.ironDoorOpen)
                {
                    map.OpenIronDoor();
                    MakeBeep(1500, 100);
                    hasKeys--;
                }
                else if ((map.mapRawData[y + deltaY][x + deltaX] == 'D' && !map.doorOpen) || (map.mapRawData[y + deltaY][x + deltaX] == 'I' && !map.ironDoorOpen))
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

            if(qManager.IsCoordinatesOccupied(x, deltaX, y, deltaY))
            {
                canMove = false;
            }

            if(shopManager.IsCoordinatesOccupied(x, deltaX, y, deltaY))
            {
                canMove = false;
                shopManager.enterShop();
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

        public void buyMerch(ShopManager shopManager)
        {
            goldHeld -= shopManager.latestShop.cost;
            //potionsHeld++;
            switch(shopManager.latestShop.merch)
            {
                case Shop.Merch.Potion:
                    potionsHeld++;
                    break;
                case Shop.Merch.Attack:
                    initalizeStrength = initalizeStrength + global.attackBoost;
                    initalizeStrength = Clamp(initalizeStrength, 0, 50); //double checking to make sure health is clamped
                    break;
                case Shop.Merch.Key:
                    hasKeys++;
                    break;
            }
        }

    }
}
