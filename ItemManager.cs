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

        public int GenerateRandNum(int minValue, int maxValue)
        {
            int output = rand.Next(maxValue);
            return output;
        }

        public void TempMethod(Map map)
        {
            for (int i = 0; i <= itemArray.Length - 1; i++)
            {
                while (map.isImpassableObstacle(itemArray[i].x, itemArray[i].y) || map.isDoor(itemArray[i].x, itemArray[i].y))
                {
                    itemArray[i].x = GenerateRandNum(80, 110);
                    itemArray[i].y = GenerateRandNum(4, 22);
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
                itemArray[i].ItemSpawnPosition(GenerateRandNum(80, 110), GenerateRandNum(4, 22));
                TempMethod(map);
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
