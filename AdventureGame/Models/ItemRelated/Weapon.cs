using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models.ItemRelated
{
    enum WeaponType
    {
        Sword =1,
        Axe,
        Mace,
    }
    

    class Weapon : Item
    {
        public WeaponType TypeOfWeapon { get; set; }
        public int DmgLowerBound { get; set; }
        public int DmgUpperBound { get; set; }
        
        Random rand = new Random();

        public Weapon(int weaponType, int itemQuality)
            :base( itemQuality)
        {
            TypeOfWeapon = (WeaponType)weaponType;
            base.Equipped = false;
            DmgLowerBound = (int)itemQuality * (int)itemQuality * 2 + rand.Next((int)itemQuality, 20);
            DmgUpperBound =1 +rand.Next(DmgLowerBound, (DmgLowerBound + rand.Next((int)itemQuality * (int)itemQuality, (int)itemQuality * (int)itemQuality)));

            SetPrice();
            base.Value = Price / 2;
        }

        public void SetPrice()
        {
            Price = (int)ItemQuality * DmgUpperBound*10;
        }

        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat($"{ItemQuality} {TypeOfWeapon} dmg: ({DmgLowerBound}-{DmgUpperBound}) GoldValue {Value} \nMaterialvalue: {MaterialValue} ");
            return sb.ToString();
        }

      
    }
}
