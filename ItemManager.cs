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
        
        public static Random rand = new Random();

        public ItemManager() 
        {
            CreateItems();
            InitItemPositions();
        }

        public int GenerateRandNum(int minValue, int maxValue)
        {
            int output = rand.Next(minValue, maxValue);
            return output;
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
        public void InitItemPositions() //nothing stops items from occupying same position
        {
            for (int i = 0; i <= itemArray.Length - 1; i++)
            {
                itemArray[i].ItemSpawnPosition(GenerateRandNum(80, 110), GenerateRandNum(4, 22));
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
