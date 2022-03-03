﻿using System;
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
                player.health = player.health + boost;
            }
        }
    }
}
