using AdventureGame.Models.ItemRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models.Mobs
{
    enum Creatures
    {
        Small =1,
        Medium,
        Large,
        Fire,
        Shadow,
        Deamon,
        Darth,
    }
    class Monster
    {
        public int Health { get; set; }
        public Creatures MycreatureSize { get; set; }
        public int DmgLowerbound { get; set; }
        public int DmgHigherBound { get; set; }
        public int GoldValue { get; set; }
        public int ExperienceValue { get; set; }
       

        public Monster(int monsterSize)
        {
            MycreatureSize = (Creatures)monsterSize;
            Health = 10 * monsterSize* monsterSize;
            DmgLowerbound = monsterSize* monsterSize;
            DmgHigherBound = 3 * monsterSize*monsterSize;
            GoldValue = monsterSize * 40;
            ExperienceValue = monsterSize * 30;
        }
        public void TakeDmg(int dmgTaken)
        {
            Health -= dmgTaken;
        }
        public virtual int DoDmg()
        {
            Random rand = new Random();
            int dmgAmount = rand.Next(DmgLowerbound, DmgHigherBound);

            return dmgAmount;
        }
        public virtual void MonsterDied(Monster monster, CharacterClass character)
        {
            Console.WriteLine("Has not been overwriten");
        }

        public virtual void PrintMonsterInfo()
        {
            Console.WriteLine("Has not been overwriten");
        }

        static public int QualityGenerator(Monster monster)
        {
            Random randQuality = new Random();
            return randQuality.Next(2,(int) monster.MycreatureSize+1);
        }
        static public Shield RandomShield(int quality)
        {
            Random randShield = new Random();
            Shield randomShield = new Shield(randShield.Next(1, 3), quality);
            return randomShield;
        }
        static public Weapon RandomWeapon(int quality)
        {
            Random randWeap = new Random();
            Weapon randomWeapon = new Weapon(randWeap.Next(1, 4), quality);
            return randomWeapon;
        }

    }
}
