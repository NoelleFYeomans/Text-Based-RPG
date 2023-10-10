﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class HealthBoost : Items
    {
        public int boost;

        public HealthBoost(GlobalSettings global)
        {
            objectIcon = global.hBoostIcon;
            boost = global.healthBoost;
        }

        public override void Update(Player player, QuestManager qManager)
        {
            if (onGround == true && player.x == x && player.y == y)
            {
                onGround = false;
                MakeBeep(300, 100);
                if (player.health < 100)
                {
                    player.health = player.health + boost;
                    player.health = Clamp(player.health, 0, 100); //double checking to make sure health is clamped
                }
                else
                {
                    player.potionsHeld++;
                }

                qManager.CheckQuests(Quest.Category.Collection, Quest.Target.Potions);
                qManager.CheckQuests(Quest.Category.Collection, Quest.Target.AnyItems);
            }
        }
    }
}
