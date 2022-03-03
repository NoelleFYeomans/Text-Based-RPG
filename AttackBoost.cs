using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class AttackBoost : Items
    {
        public void Update(Player player, int boost)
        {
            if (onGround == true && player.x == x && player.y == y)
            {
                onGround = false;
                player.initalizeStrength = player.initalizeStrength + boost;
            }
        }
    }
}
