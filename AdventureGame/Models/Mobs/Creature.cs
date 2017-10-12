using AdventureGame.Models.ItemRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models.Mobs
{
    enum CreatureType 
    {
        Bull =1,
        Troll,
        Scorpion,
        Piccachu,
        Specter,
        Angel,
        Warrior,
        Wurm,
        Murloc,
        Vader,
    }
    class Creature : Monster
    {

        public string Name { get; set; }
        public CreatureType MyCreatureType { get; set; }

        public Creature(int monsterSize, int creatureType) : base(monsterSize)
        {
            MyCreatureType = (CreatureType)creatureType;
            Name = base.MycreatureSize+ " " +MyCreatureType;
            if (monsterSize < 4)
            {
                base.Health = 40 * monsterSize;
                base.DmgLowerbound = 2 * creatureType + monsterSize;
                base.DmgHigherBound = 4 * creatureType + monsterSize;
            }
            
        }

        public override void PrintMonsterInfo()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Monster Stats");
            Console.WriteLine($"{Name} \nHealth: {Health} hp \nDamage: {DmgLowerbound} - {DmgHigherBound} dmg ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------------------");
        }

        public override void MonsterDied(Monster monster, CharacterClass character)
        {
            Creature temporaryCreature = (Creature)monster;
            Random typeOfLoot = new Random();
            Console.WriteLine($"You vanquised {Name}, and looted {monster.GoldValue} Gold and {monster.ExperienceValue}xp");
            Console.WriteLine($"And a random item .... ");
            if (typeOfLoot.Next(1, 3) == 1)
            {
                Weapon weaponLoot = RandomWeapon(QualityGenerator(monster));
                character.AddWeaponToInventory(weaponLoot);
            }
            else
            {
                Shield shieldLoot = RandomShield(QualityGenerator(monster));
                character.AddShieldToInventory(shieldLoot);
            }
            character.ExperienceGained(monster.ExperienceValue);
            character.Gold += monster.GoldValue;
        }
    }
}
