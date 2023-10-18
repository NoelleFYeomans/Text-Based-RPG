using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    public class QuestGiver : GameObject
    {
        private Quest quest;
        public bool given = false;

        public QuestGiver(Quest quest, int x, int y, GlobalSettings global) { 
            this.quest = quest;
            this.x = x;
            this.y = y;
            objectIcon = global.questGiverObjectIcon;
        }

        public void setGiven(bool given) { this.given = given;}

        public Quest getQuest()
        {
            return quest;
        }

        public void Draw(Camera camera, Renderer renderer)
        {
            renderer.Draw(x, y, objectIcon, camera, ConsoleColor.DarkYellow);
        }

    }
}
