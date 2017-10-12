using AdventureGame.Models.ItemRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models.Mobs
{
    enum Bosses
    {
        Diablo = 1,
        IceKing,
        LarryTheDragon
    }
    class Boss : Monster
    {

        public Bosses BossName { get; set; }
        public int AttackCounter { get; set; }

        public Boss(int monsterType, int bossName) : base(monsterType)
        {
            BossName = (Bosses)bossName;
            switch ((Bosses)bossName)
            {
                case Bosses.Diablo:
                    base.Health = 2000 * bossName;
                    base.DmgLowerbound = 100 * bossName;
                    base.DmgHigherBound = 150 * bossName;
                    base.GoldValue = 1000;
                    base.ExperienceValue = 1000;
                    break;
                case Bosses.IceKing:
                    base.Health = 5000 * bossName;
                    base.DmgLowerbound = 150 * bossName;
                    base.DmgHigherBound = 200 * bossName;
                    base.GoldValue = 5000;
                    base.ExperienceValue = 2500;
                    break;
                case Bosses.LarryTheDragon:
                    base.Health = 10000 * bossName;
                    base.DmgLowerbound = 150 * bossName;
                    base.DmgHigherBound = 250 * bossName;
                    base.GoldValue = 10000;
                    base.ExperienceValue = 4000;
                    break;
                default:
                    break;
            }

        }

        public override int DoDmg()
        {
            
            int dmgAmount = 0;
            Random rand = new Random();
            if (AttackCounter == 2)
            {
                var p1 = new System.Windows.Media.MediaPlayer();
                p1.Open(new System.Uri(Environment.CurrentDirectory + @"\BossAttack.wav"));
                p1.Play();
                
                Console.WriteLine($"({BossName}) Raaaaaaaggghhhwwwww!!!!");
                dmgAmount = rand.Next(DmgLowerbound, DmgHigherBound);
                AttackCounter = 0;
            }
            else
            {
                Console.WriteLine($"{BossName} is charging attack...");
                AttackCounter++;
            }
            return dmgAmount;
        }
        public override void MonsterDied(Monster monster, CharacterClass character)
        {
            Random typeOfLoot = new Random();
            
            Boss temporaryBoss = (Boss)monster;
            Console.WriteLine($"You vanquised {temporaryBoss.BossName}, and looted {monster.GoldValue} Gold and {monster.ExperienceValue}xp");
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
        public override void PrintMonsterInfo()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Monster Stats");
            Console.WriteLine($">>> {BossName} <<<\nHealth: {Health} hp \nSpecial Damage: {DmgLowerbound} - {DmgHigherBound} dmg ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------------------");
        }
    
    }
    
}
