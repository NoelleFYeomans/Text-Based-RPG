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
        int enemyAttacked = 0;

        public void Update(Map map, NormalEnemy normalE, StrongEnemy strongE, WeakEnemy weakE) //you can pass in a different class to access it
        {

            if (health <= 0)
            {
                isAlive = false;
            }

            key = Console.ReadKey(true);

            //I want to have the player's position before the move saved
            priorPositionX = x;
            priorPositionY = y;

            //resetting the values of the intended change in position
            deltaX = 0;
            deltaY = 0;

            if (isAlive)
            {

                canMove = true;
                doAttack = false;

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
                x = Clamp(x, 0, 100);
                y = Clamp(y, 0, 100);


                if (map.isWall(y + deltaY, x + deltaX)) //perform checks before movement
                {
                    canMove = false;
                }

                if (x + deltaX == normalE.x && y + deltaY == normalE.y || x + deltaX == strongE.x && y + deltaY == strongE.y || x + deltaX == weakE.x && y + deltaY == weakE.y)
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
                    if (enemyAttacked == 1) //temp
                    {
                        normalE.TakeDamage(25);
                    }
                    else if (enemyAttacked == 2)
                    {
                        strongE.TakeDamage(25); 
                    }
                    else if (enemyAttacked == 3)
                    {
                        weakE.TakeDamage(25);
                    }

                    doAttack = false;
                    enemyAttacked = 0;
                }

                //apply movements values
                if (canMove)
                {
                    x = x + deltaX;
                    y = y + deltaY;
                }
            }  
        }
    }
}
