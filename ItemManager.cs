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

        public ItemManager(Map map) 
        {
            CreateItems();
            InitItemPositions(map);
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
                if (map.isImpassableObstacle(itemArray[i].y, itemArray[i].x) || map.isDoor(itemArray[i].y, itemArray[i].x))
                {
                    itemArray[i].x = GenerateRandNum(110);
                    itemArray[i].y = GenerateRandNum(22);
                }
            }
        }

        private void CreateItems()
        {
            for (int i = 0; i <= itemArray.Length - 1; i++)
            {
                if (i <= (itemArray.Length / 2))
                {
                    itemArray[i] = new HealthBoost(); //25
                }
                else if (i <= itemArray.Length - 3) //23
                {
                    itemArray[i] = new AttackBoost();
                }
                else if (i >= itemArray.Length - 2) //2
                {
                    itemArray[i] = new DoorKey();
                }
            }
        }
        public void InitItemPositions(Map map) //nothing stops items from occupying same position
        {
            for (int i = 0; i <= itemArray.Length - 1; i++)
            {
                itemArray[i].ItemSpawnPosition(GenerateRandNum(110), GenerateRandNum(22));
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
                itemArray[i].Update(player);
            }
        }

        public void DrawItems()
        {
            for (int i = 0; i <= itemArray.Length - 1; i++)
            {
                itemArray[i].Draw();
            }
        }
    }
}
