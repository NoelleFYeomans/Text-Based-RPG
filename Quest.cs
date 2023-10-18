using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    //internal class Quest  
    public class Quest  
    {
        public enum Category
        {
            Elimination,
            Collection
        }

        public enum Target
        {
            WeakEnemies,
            NormalEnemies,
            StrongEnemies,
            AnyEnemies,
            Potions,
            AttackBoosts,
            Keys,
            AnyItems
        }

        public Category questType;
        public Target questTarget;
        public int amount;
        public string message; 
        public int rewardGold;
        public bool complete = false;

        public int achieved = 0;


        public Quest(Category questType, Target questTarget, int amount, string message, int goldReward)
        {
            this.questType = questType;
            this.questTarget = questTarget;
            this.amount = amount;
            this.message = message;
            rewardGold = goldReward;
        }

        public void EndQuest(Player player)
        {
            player.gainGold(rewardGold);
            complete = true;
        }

        public void Update()
        {

        }

        public void CheckAchieve(Category type, Target targ, Player player)
        {
            if(type == questType && targ == questTarget)
            {
                achieved++;
                if(achieved >= amount)
                {
                    EndQuest(player);
                }
            }
        }


    }
}
