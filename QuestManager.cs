using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    internal class QuestManager
    {

        public List<Quest> quests = new List<Quest>();
        Player player;

        public QuestManager(Player player)
        {
            this.player = player;
            CreateQuests();
        }


        void CreateQuests()
        {
            quests.Add(new Quest(Quest.Category.Collection, Quest.Target.Potions, 5, "Collect 5 Potions", 25));
            quests.Add(new Quest(Quest.Category.Elimination, Quest.Target.AnyEnemies, 50, "Defeat All Enemies", 50));
        }

        public void CheckQuests(Quest.Category category, Quest.Target target)
        {
            foreach (Quest quest in quests)
            {
                if (quest.complete == false)
                {
                    quest.CheckAchieve(category, target, player);
                }
            }
        }


    }
}
