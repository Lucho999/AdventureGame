using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models.ItemRelated
{
    enum SizeOfShield
    {
        small = 1,
        medium,
        Large
    }
    class Shield : Item
    {
        public String ShieldName { get; set; } 
        public int TypeOfShield { get; set; }
        public int ArmourAmount { get; set; }
        public int BlockRating { get; set; }
        
        public Shield(int sizeOfShield,int itemQuality) : base(itemQuality)
        {
            Random armourAmount = new Random();
            ArmourAmount = itemQuality * sizeOfShield;
            TypeOfShield = sizeOfShield;
            switch ((SizeOfShield)sizeOfShield)
            {
                case SizeOfShield.small:
                    ShieldName = "Buckel Shield";
                    ArmourAmount *= armourAmount.Next(20, 41);
                    BlockRating = 2;
                    break;
                case SizeOfShield.medium:
                    ShieldName = "Kite Shield";
                    ArmourAmount *= armourAmount.Next(40, 71);
                    BlockRating = 5;
                    break;
                case SizeOfShield.Large:
                    ShieldName = "Heater Shield";
                    ArmourAmount *= armourAmount.Next(70, 101);
                    BlockRating = 8;
                    break;
                default:
                    break;
            }
            SetPrice(sizeOfShield);
            base.Value = Price / 2;
        }

        public void SetPrice(int sizeOfShield)
        {
            Price = ArmourAmount*(int)ItemQuality*sizeOfShield;

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{ItemQuality} {ShieldName} Armour: {ArmourAmount} BlockRating: {BlockRating} GoldValue {Value} \nMaterialvalue: {MaterialValue}");
            return sb.ToString();
        }
        
        
    }
}
