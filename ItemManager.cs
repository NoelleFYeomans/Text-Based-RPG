using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class ItemManager
    {
        public Items[] itemArray = new Items[50]; //same polymorphism issue as enemyManager
        QuestManager qManager;

        public ItemManager(Map map, GlobalSettings global, QuestManager qManager) 
        {
            CreateItems(global);
            InitItemPositions(map);
            this.qManager = qManager;
        }

        public static Random rand = new Random();

        public int GenerateRandNum(int maxValue)
        {
            int output = rand.Next(maxValue);
            return output;
        }

        public void InitPosProtection(Map map)
        {
            for (int i = 0; i <= itemArray.Length - 1; i++)
            {
                while (map.isImpassableObstacle(itemArray[i].y, itemArray[i].x) || map.isDoor(itemArray[i].y, itemArray[i].x) || map.isInsideStructure(itemArray[i].y, itemArray[i].x))
                {
                    itemArray[i].x = GenerateRandNum(map.mapRawData[0].Length);
                    itemArray[i].y = GenerateRandNum(map.mapRawData.Length);
                }
            }
        }

        private void CreateItems(GlobalSettings global)
        {
            for (int i = 0; i <= itemArray.Length - 1; i++)
            {
                if (i <= (itemArray.Length / 2))
                {
                    itemArray[i] = new HealthBoost(global); //25
                }
                else if (i <= itemArray.Length - 3) //23
                {
                    itemArray[i] = new AttackBoost(global);
                }
                else if (i >= itemArray.Length - 2) //2
                {
                    itemArray[i] = new DoorKey();
                }
            }
        }
        public void InitItemPositions(Map map) 
        {
            for (int i = 0; i <= itemArray.Length - 1; i++)
            {
                itemArray[i].ItemSpawnPosition(GenerateRandNum(map.mapRawData[0].Length), GenerateRandNum(map.mapRawData.Length));
                InitPosProtection(map);

                if (i == itemArray.Length - 1)
                {
                    itemArray[i].ItemSpawnPosition(17, 7);
                }
            }
        }

        public void UpdateItems(Player player)
        {
            for (int i = 0; i <= itemArray.Length - 1; i++) //rip Typecasting
            {
                itemArray[i].Update(player, qManager);
            }
        }

        public void DrawItems(Camera camera, Renderer renderer)
        {
            for (int i = 0; i <= itemArray.Length - 1; i++)
            {
                itemArray[i].Draw(camera, renderer);
            }
        }
    }
}
