using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Based_RPG
{
    class ItemManager
    {
        //declaration & instantiation
        DoorKey key = new DoorKey();
        HealthBoost potion = new HealthBoost();
        AttackBoost sword = new AttackBoost();

        public void InitAllItems()
        {
            key.InitializeItem('K', 2, 2);
            potion.InitializeItem('P', 20, 3);
            sword.InitializeItem('A', 23, 3);
        }

        public void UpdateItems(Player player)
        {
            key.Update(player);
            potion.Update(player, 50);
            sword.Update(player, 25);
        }

        public void DrawItems()
        {
            key.Draw();
            potion.Draw();
            sword.Draw();
        }
    }
}
