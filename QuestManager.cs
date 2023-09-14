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
        public QuestGiver[] givers = new QuestGiver[1];
        Player player;
        GlobalSettings global;

        public QuestManager(Player player, GlobalSettings global)
        {
            this.player = player;
            this.global = global;
            CreateQuests();
        }


        void CreateQuests()
        {
            //quests.Add(new Quest(Quest.Category.Collection, Quest.Target.Potions, 5, "Side Quest: Collect 5 Potions", 25));
            quests.Add(new Quest(Quest.Category.Elimination, Quest.Target.AnyEnemies, 50, "Main Quest: Defeat All Enemies", 50));
            givers[0] = new QuestGiver(new Quest(Quest.Category.Collection, Quest.Target.Potions, 5, "Side Quest: Collect 5 Potions", 25), 8, 21, global);
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

        public void DrawGivers(Camera camera, Renderer renderer)
        {
            for (int i = 0; i <= givers.Length - 1; i++)
            {
                givers[i].Draw(camera, renderer);
            }
        }

        public bool IsCoordinatesOccupied(int x, int deltaX, int y, int deltaY)
        {
            for (int i = 0; i <= givers.Length - 1; i++)
            {
                if (x + deltaX == givers[i].x && y + deltaY == givers[i].y)
                {
                    if (givers[i].given == false)
                    {
                        givers[i].setGiven(true);
                        quests.Add(givers[i].getQuest());
                    }
                    return true;
                }
            }
            return false;
        }


    }
}
