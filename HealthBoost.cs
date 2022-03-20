using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class HealthBoost : Items
    {
        public void Update(Player player, int boost)
        {
            if (onGround == true && player.x == x && player.y == y)
            {
                onGround = false;
                MakeBeep(300, 100);
                player.health = player.health + boost;
                Clamp(player.health, 0, 100); //consider not hardcoding in future
                
            }
        }
    }
}
