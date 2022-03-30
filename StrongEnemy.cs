using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class StrongEnemy : Enemy 
    {
        public StrongEnemy()
        {
            objectIcon = 'S';
            health = 150;
            initalizeStrength = 10;
        }

        public new void Update(Map map, Player player, EnemyManager enemyManager) //StrongEnemy strongE, WeakEnemy weakE
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

            int detectionRange = 5;

            if (!isAlive) return; //guard clause

            if (player.x >= x - detectionRange && player.x <= x + detectionRange)
            {
                if (player.y >= y - detectionRange && player.y <= y + detectionRange)
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

                        }
                    }
                }
            }

            deltaX = Clamp(deltaX, -1, 1);
            deltaY = Clamp(deltaY, -1, 1);

            CalculateAction(map, player, enemyManager);
            ApplyAction(map);
        }
    }
}
