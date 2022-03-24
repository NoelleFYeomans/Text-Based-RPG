using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class AttackBoost : Items
    {
        public AttackBoost()
        {
            objectIcon = 'A';
        }

        public int boost = 25; //global settings

        public override void Update(Player player)
        {
            if (onGround == true && player.x == x && player.y == y)
            {
                onGround = false;
                MakeBeep(300, 100);
                player.initalizeStrength = player.initalizeStrength + boost;
            }
        }
    }
}
