using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class HealthBoost : Items
    {
        public HealthBoost()
        {
            objectIcon = 'P';
        }

        public int boost = 25;

        public override void Update(Player player)
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
