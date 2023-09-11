using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class NormalEnemy : Enemy
    {

        public NormalEnemy(GlobalSettings global)
        {
            objectIcon = global.normalObjectIcon;
            health = global.normalHealth;
            initalizeStrength = global.normalInitStrength;
        }

        public override void Update(Map map, Player player, EnemyManager enemyManager) //test static update & virtual instead of new
        {
            if (health <= 0)
            {
                isAlive = false;
            }

            //enemy's intended position before moving
            priorPositionX = x;
            priorPositionY = y;

            //resetting relevent values before movement
            deltaX = 0;
            deltaY = 0;
            canMove = true;

            int target = GenerateRandNum(0, 3); 

            if (!isAlive) return;

            if (target <= 1) 
            {
                if (x < player.x)
                {
                    deltaX = 1;
                }
                else if (x > player.x)
                {
                    deltaX = -1;
                }
                else
                {
                    if (y < player.y) 
                    {
                        deltaY = +1;
                    }
                    else if (y > player.y)
                    {
                        deltaY = -1;
                    }
                    else
                    {
                        //nothing //could be improved
                    }
                }
            }

            else if (target >= 2)
            {
                int dir = GenerateRandNum(1, 6);

                if (dir == 1)
                {
                    deltaY = -1;
                }
                else if (dir == 2)
                {
                    deltaY = +1;
                }
                else if (dir == 3)
                {
                    deltaX = +1;
                }
                else if (dir == 4)
                {
                    deltaX = -1;
                }
                else if (dir == 5)
                {
                    //doesn't move
                }
            }

            deltaX = Clamp(deltaX, -1, 1);
            deltaY = Clamp(deltaY, -1, 1);

            CalculateAction(map, player, enemyManager); //StrongEnemy strongE, WeakEnemy weakE
            ApplyAction(map);
        }
    }
}