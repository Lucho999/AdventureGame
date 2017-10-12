using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    enum ItemQuality
    {
        Kids = 1,
        Wooden ,
        Practice,
        Metall,
        Speed,
        Dark,
        Uncommon,
        Rare,
        Diamond,
        Shadow,
        Flame,
        Slayer,
        Legendary,
    }
   
    class Item 
    {
        
        public ItemQuality ItemQuality { get; set; }
        public int Value { get; set; }
        public int Price { get; set; }
        public int MaterialValue { get; set; }
        public bool Equipped { get; set; }

        public Item(int itemQuality)
        {
            this.MaterialValue = 30*(int)itemQuality;
            ItemQuality = (ItemQuality)itemQuality;
        }
    }
}
