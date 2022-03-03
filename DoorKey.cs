using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class DoorKey : Items
    {        
        public void UseKey(Player player)
        {
            player.hasKeys--;
        }

        public void Update(Player player)
        {
            if (onGround == true && player.x == x && player.y == y)
            {
                onGround = false;
                player.hasKeys++;
            }
        }
    }
}
