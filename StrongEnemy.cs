using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class StrongEnemy : Enemy 
    {
        public void Update(Map map, Player player, NormalEnemy normalE, WeakEnemy weakE)
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

                CalculateAction(map, player, normalE, weakE);
                ApplyAction();
            }
        }
    }
}
