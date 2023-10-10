using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG { 

    class DoorKey : Items
    {      
        public DoorKey()
        {
            objectIcon = 'K';
        }

        public void UseKey(Player player)
        {
            player.hasKeys--;
        }

        public override void Update(Player player, QuestManager qManager)
        {
            if (onGround == true && player.x == x && player.y == y)
            {
                onGround = false;
                MakeBeep(300, 100);
                player.hasKeys++;
                qManager.CheckQuests(Quest.Category.Collection, Quest.Target.Keys);
                qManager.CheckQuests(Quest.Category.Collection, Quest.Target.AnyItems);
            }
        }
    }
}
