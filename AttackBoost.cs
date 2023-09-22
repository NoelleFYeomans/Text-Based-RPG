using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class AttackBoost : Items
    {
        public int boost;

        public AttackBoost(GlobalSettings global)
        {
            objectIcon = global.aBoostIcon;
            boost = global.attackBoost;
        }

        public override void Update(Player player, QuestManager qManager)
        {
            if (onGround == true && player.x == x && player.y == y)
            {
                onGround = false;
                MakeBeep(300, 100);
                player.initalizeStrength = player.initalizeStrength + boost;
                player.initalizeStrength = Clamp(player.initalizeStrength, 0, 50); //double checking to make sure health is clamped
                qManager.CheckQuests(Quest.Category.Collection, Quest.Target.AttackBoosts);
                qManager.CheckQuests(Quest.Category.Collection, Quest.Target.AnyItems);
            }
        }
    }
}
