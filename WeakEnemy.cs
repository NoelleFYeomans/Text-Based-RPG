using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class WeakEnemy : Enemy
    {
        bool canAct = true;

        public void Update(Map map, Player player, NormalEnemy normalE, StrongEnemy strongE)
        {
            if (health <= 0)
            {
                isAlive = false;
            }

            //enemy's intended position before moving
            priorPositionX = x;
            priorPositionY = y;

            //resetting the deltas of the movement
            deltaX = 0;
            deltaY = 0;

            int detectionRange = 5;

            if (isAlive)
            {
                if (player.x >= x - detectionRange && player.x <= x + detectionRange && canAct)
                {
                    if (player.y >= y - detectionRange && player.y <= y + detectionRange)
                    {
                        if (x < player.x)
                        {
                            deltaX = -1; //runs away
                        }
                        else if (x > player.x)
                        {
                            deltaX = 1; //runs away
                        }
                        else
                        {
                            if (y < player.y)
                            {
                                deltaY = -1; //runs away
                            }
                            else if (y > player.y)
                            {
                                deltaY = 1; //runs away
                            }
                            else
                            {

                            }
                        }
                        canAct = false;
                    }
                }
                else if (!canAct)
                {
                    canAct = true; //can't move every other turn
                }

                deltaX = Clamp(deltaX, -1, 1);
                deltaY = Clamp(deltaY, -1, 1);

                CalculateAction(map, player, normalE, strongE);
                ApplyAction();
            }
        }
    }
}
