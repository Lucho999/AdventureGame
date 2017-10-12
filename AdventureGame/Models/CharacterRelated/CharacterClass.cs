using AdventureGame.Models.ItemRelated;
using AdventureGame.Models.Mobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventureGame.Models 
{
    enum CharRace
    {
        Dwarf = 1,
        Elf,
        Highlander
    }

    enum CharClass
    {
        Warrior = 1,
        Hunter,
        Paladin
    }

    class CharacterClass
    {
        #region Char spec and setup

        public List<Item> UserInventory { get; set; }
        public string Name { get; }
        public int Level { get; set; }
        public CharClass CharClass { get; }
        public CharRace CharRace { get; set; }
        public int Experience { get; set; }
        public int CraftingMaterial { get; set; }
        public int BossEncounter { get; set; }
        public int ExpBar { get; set; }
        public int Gold { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Dexerity { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public string MainQuest { get; set; }
        public int DmgUpperBound { get; set; }
        public int DmgLowerBound { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialAttackCounter { get; set; }
        public int Armour { get; set; }
        public int BlockRating { get; set; }
        public int PotionBag { get; set; }

        public CharacterClass(string name, int characterRace)
        {
            this.Name = name;
            this.Level = 1;
            this.Experience = 0;
            this.ExpBar = Level * Level * 100;
            UserInventory = new List<Item>();
            this.CharRace = (CharRace)characterRace;
            this.CharClass = (CharClass)characterRace;

            this.Gold = 10;
            this.MaxHealth = 100;
            this.Health = 50;
            this.PotionBag = 0;
            this.CraftingMaterial = 0;
            this.BossEncounter = 1;
            this.SpecialAttack = 0;
            switch (CharRace)
            {
                case CharRace.Dwarf:
                    this.Strength = 20;
                    this.Dexerity = 2;
                    this.Intelligence = 0;
                    this.Charisma = 3;
                    DmgLowerBound = Strength;
                    DmgUpperBound = Strength;
                    break;
                case CharRace.Elf:
                    this.Strength = 10;
                    this.Dexerity = 5;
                    this.Intelligence = 5;
                    this.Charisma = 4;
                    DmgLowerBound = Dexerity;
                    DmgUpperBound = Dexerity + Strength;
                    break;
                case CharRace.Highlander:
                    this.Strength = 0;
                    this.Dexerity = 10;
                    this.Intelligence = 10;
                    this.Charisma = 10;
                    DmgLowerBound = Intelligence;
                    DmgUpperBound = Intelligence + Dexerity;
                    break;
                default:
                    break;
            }
        }

        #endregion
        public void WarCry()
        {
            Random randomWarCry = new Random();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} warcry:");
            switch (randomWarCry.Next(1, 21))
            {
                case 1:
                    Console.WriteLine("YOU WILL NEVER TAKE ME ALIVE!!!!");
                    break;
                case 2:
                    Console.WriteLine("YOU SHALL NOT PASS!!!!");
                    break;
                case 3:
                    Console.WriteLine("I'M NOT DONE WITH YOU YET, PREPARE TO BE SLAIN!!!");
                    break;
                case 4:
                    Console.WriteLine("AAARRRRGGHHHH CHARGEEEE!!!");
                    break;
                case 5:
                    Console.WriteLine(@"CAN YOU JUST DIE ¤#%¤%%%%##¤");
                    break;
                case 6:
                    Console.WriteLine(@"I'm Getting to old for this %¤##");
                    break;
                case 7:
                    Console.WriteLine("Hasta la vista baby!!!!!");
                    break;
                case 8:
                    Console.WriteLine(" If you try to run, I’ve got six little friends and they can all run faster than you can");
                    break;
                case 9:
                    Console.WriteLine("Go ahead, punk, make my day");
                    break;
                case 10:
                    Console.WriteLine("Ever notice how you come across somebody once in a while you shouldn’t have f’ed with? That’s me");
                    break;
                case 11:
                    Console.WriteLine("Okay, my friend. It’s off to the next life for you. I guarantee you, you won’t be lonely.");
                    break;
                case 12:
                    Console.WriteLine("I ain’t got time to bleed.");
                    break;
                case 13:
                    Console.WriteLine("There are two types of people in the world – those with a gun, and those who dig. Now dig! ");
                    break;
                case 14:
                    Console.WriteLine("Losers always whine about their best.Winners go home and F * ck the prom queen");
                    break;
                case 15:
                    Console.WriteLine(" I’ll make him an offer he can’t refuse");
                    break;
                case 16:
                    Console.WriteLine("Say hello to my little friend ");
                    break;
                case 17:
                    Console.WriteLine("All I have in this world are my balls and my word, and I don’t break them for anybody.");
                    break;
                case 18:
                    Console.WriteLine("This is (not) SPARTAAAA!! ");
                    break;
                case 19:
                    Console.WriteLine("Yippee-ki-yay, motherf*cker. ");
                    break;
                case 20:
                    Console.WriteLine("None of you understand. I’m not locked up in here with you. You’re locked up in here with me. ");
                    break;

                default:
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;

        }
        public string LevelingPrint()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("-------------------------------------\n");
            sb.AppendFormat("|             Player Stats          |\n");
            sb.AppendFormat("-------------------------------------\n");
            sb.AppendFormat($"Name   {Name}\n");
            sb.AppendFormat($"Level  {Level} \n");
            sb.AppendFormat($"Health {Health}hp\n");
            sb.AppendFormat($"MaxHealth {MaxHealth}hp\n");
            sb.AppendFormat($"Strength      {Strength}\n");
            sb.AppendFormat($"Intelligence  {Intelligence}\n");
            sb.AppendFormat($"Dexterity     {Dexerity}\n");
            sb.AppendFormat($"Charisma      {Charisma}\n");
            sb.AppendFormat("-------------------------------------\n");
            return sb.ToString();
        }
        public string ClassPrintInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("-------------------------------------\n");
            sb.AppendFormat("|             Player Stats          |\n");
            sb.AppendFormat("-------------------------------------\n");
            sb.AppendFormat($"Name   {Name}\n");
            sb.AppendFormat($"Level  {Level} \n");
            sb.AppendFormat($"Health {Health}hp\n");
            sb.AppendFormat($"Tnl    {ExpBar - Experience}xp\n");
            sb.AppendFormat($"Gold   {Gold}\n");
            sb.AppendFormat($"Race   {CharRace} ({CharClass})\n\n");
            sb.AppendFormat($"Stats\n");
            sb.AppendFormat($"Dmg           {DmgLowerBound} - {DmgUpperBound}\n");
            sb.AppendFormat($"Armour        {Armour}\n");
            sb.AppendFormat($"Strength      {Strength}\n");
            sb.AppendFormat($"Intelligence  {Intelligence}\n");
            sb.AppendFormat($"Dexterity     {Dexerity}\n");
            sb.AppendFormat($"Charisma      {Charisma}\n");
            sb.AppendFormat($"MainQuest     {MainQuest}\n");
            sb.AppendFormat($"Equipment\n");
            var currentWeapon = UserInventory.OfType<Weapon>().FirstOrDefault(w => w.Equipped == true);
            var currentShield = UserInventory.OfType<Shield>().FirstOrDefault(s => s.Equipped == true);
            if (currentWeapon != null)
            {
                sb.AppendFormat($"Weapon        {currentWeapon.ItemQuality} {currentWeapon.TypeOfWeapon}\n");
                sb.AppendFormat($"Dmg           ({currentWeapon.DmgLowerBound} - {currentWeapon.DmgUpperBound}) dmg\n");
            }
            if (currentShield != null)
            {
                sb.AppendFormat($"Shield        {currentShield.ItemQuality} {currentShield.ShieldName} \n");
                sb.AppendFormat($"Armour        {currentShield.ArmourAmount} Rating: {currentShield.BlockRating} \n");
            }
            sb.AppendFormat("-------------------------------------\n");

            return sb.ToString();
        }
        public void ClassBattlePrint()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Player Stats");
            Console.WriteLine($"Name: {Name}");
            if (Health < 40)
            {
                Console.Write("Helth: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($">>> {Health} hp <<<");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine($"Health: {Health} hp ");
            }
            Console.WriteLine($"Damage: ({DmgLowerBound} - {DmgUpperBound}) dmg \nSpecialAttack {SpecialAttack} dmg \nArmour: {Armour} Block Rating: {BlockRating} \nPotion bag: {PotionBag}");
            Console.WriteLine("------------------------------------------------------------");
        }
        public void PrintInfoForShop()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Player");
            Console.WriteLine($"Name: {Name}\nLevel {Level} \nGold: {Gold} \nCrafting Material {CraftingMaterial}");
            Console.WriteLine("---------------------------------------------------------");
        }


        public void ExperienceGained(int exGained)
        {
            Experience += exGained;
            do
            {
                if (Experience >= ExpBar)
                {
                    Experience -= ExpBar;
                    Console.WriteLine("You have become more powerfull.");
                    Console.WriteLine("Press any key for leveling menu..");
                    Console.ReadKey();
                    Console.Clear();
                    LevelUp();
                }
               
                ExpBar = Level * Level * 100;
            } while (Experience >= ExpBar);
            Console.WriteLine($"You have {ExpBar - Experience}XP tnl.");
        }
        public void LevelUp()
        {
            this.Level++;
            var p1 = new System.Windows.Media.MediaPlayer();
            p1.Open(new System.Uri(Environment.CurrentDirectory + @"\Levelup.wav"));
            p1.Play();
            this.MaxHealth += 50 * Level;
            Console.WriteLine($"{50 * Level}hp has been added to you max Health.");

            switch (CharClass)
            {
                case CharClass.Warrior:
                    Strength += 10;
                    Dexerity += 1;
                    Console.WriteLine("Strenght increased by +10");
                    Console.WriteLine("Dexterity increased by +1");
                    break;
                case CharClass.Hunter:
                    Dexerity += 7;
                    Strength += 2;
                    Console.WriteLine("Dexterity increased by +7");
                    Console.WriteLine("Strength increased by +2");
                    break;
                case CharClass.Paladin:
                    Intelligence += 5;
                    Dexerity += 5;
                    Console.WriteLine("Intelligence increased by +5");
                    Console.WriteLine("Dexterity increased by +5");
                    break;
                default:
                    break;
            }

            AddSkillPoints();
        }
        public void AddSkillPoints()
        {
            int skillPointsToSpend = 3;

            do
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine(LevelingPrint());
                Console.WriteLine("Please chooose how to spend your 3 skill points.\n(1 point at the time, some skills cost more depending on class your class)");
                Console.WriteLine("1. Dexterity");
                Console.WriteLine("2. Strength");
                Console.WriteLine("3. Intelligence");
                Console.WriteLine("4. Charisma");
                    
                int skillPointChoice;
                bool controlVariable = int.TryParse(Console.ReadLine(), out skillPointChoice);
                if (controlVariable)
                {
                    switch (skillPointChoice)
                    {
                        case 1:
                            if ((int)CharRace == 1)
                            {
                                if (skillPointsToSpend == 3)
                                {
                                    Console.WriteLine("One point is added to Dexterity");
                                    this.Dexerity++;
                                    skillPointsToSpend = -3;
                                }
                                else
                                {
                                    Console.WriteLine("You need 3 points for this skill, please choose another..");
                                }
                            }
                            else
                            {
                                Console.WriteLine("One point is added to Dexterity");
                                this.Dexerity++;
                                skillPointsToSpend--;
                            }

                            break;
                        case 2:
                            Console.WriteLine("One point is added to Strength");
                            this.Strength++;
                            skillPointsToSpend--;
                            break;
                        case 3:
                            Console.WriteLine("One point is added to Intelligence");
                            this.Intelligence++;
                            skillPointsToSpend--;
                            break;
                        case 4:
                            if ((int)CharRace == 1)
                            {
                                if (skillPointsToSpend == 3)
                                {
                                    Console.WriteLine("One point is added to Charisma");
                                    this.Charisma++;
                                    skillPointsToSpend = -3;
                                }
                                else
                                {
                                    Console.WriteLine("You need 3 points for this skill, please choose another..");
                                }
                            }
                            else
                            {
                                Console.WriteLine("One point is added to Charisma");
                                this.Charisma++;
                                skillPointsToSpend--;
                            }
                            break;
                        default:
                            Console.WriteLine($"Number {skillPointChoice} is invalid, please choose a number between 1-4");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input please choose a number between 1-4");
                }

            } while (skillPointsToSpend > 0);
            Console.WriteLine("Skillpoints added..Press anykey");
            Console.Clear();
            Console.WriteLine(ClassPrintInformation());
        }
        
        public void Heal()
        {
            Health = MaxHealth;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You feel much better..\nYou are at max health ready for battle again...");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void TakePotion()
        {
            if (PotionBag > 0)
            {
                PotionBag--;
                Heal();
            }
            else
            {
                Console.WriteLine("You dont have any Health Potions.. they are sold at the vendor in the city.");
            }
        }


        public void TakeDmg(int dmgAmount)
        {
            Random randAvoid = new Random();
            Random randBlockedAmount = new Random();
            int amountBlocked = 0;
            if (dmgAmount > 0)
            {

                if (Dexerity < randAvoid.Next(1, 80))
                {
                    if (Block())
                    {
                        amountBlocked = randBlockedAmount.Next(1, Armour);
                        if (amountBlocked > dmgAmount)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;

                            


                            Console.WriteLine($"You block {dmgAmount} dmg points with your shield..");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            var p1 = new System.Windows.Media.MediaPlayer();
                            p1.Open(new System.Uri(Environment.CurrentDirectory + @"\ShieldBlock.wav"));
                            p1.Play();
                            Health -= (dmgAmount - amountBlocked);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"You block {amountBlocked} dmg points with your shield..");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"The Monster does {dmgAmount} points of dmg");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        
                        Health -= dmgAmount;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"The Monster does {dmgAmount} points of dmg");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                else
                {
                    Console.WriteLine($"You managed to oviod the monsters attack of {dmgAmount} hitpoints!!");
                }

                if (Health < 10)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You have low health!!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (Health <= 0)
                    {
                        Console.WriteLine("You get knocked out and cannot continue battle...");
                        Console.WriteLine("You lost half your gold... ");
                        Gold = Gold / 2;
                        Health = 1;
                        var p1 = new System.Windows.Media.MediaPlayer();
                        p1.Open(new System.Uri(Environment.CurrentDirectory + @"\Died.wav"));
                        p1.Play();
                    }
                }
            }
        }
        public int DoDmg()
        {
            Random rand = new Random();
            int dmgdealt = 0;
            dmgdealt = rand.Next(DmgLowerBound, DmgUpperBound);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} hits for {dmgdealt} points of dmg");
            Console.ForegroundColor = ConsoleColor.White;
            var p1 = new System.Windows.Media.MediaPlayer();
            p1.Open(new System.Uri(Environment.CurrentDirectory + @"\BattleSound.wav"));
            p1.Play();
            return dmgdealt;
            
        }
        public bool Block()
        {
            Random blockchance = new Random();
            if (BlockRating > blockchance.Next(1, 11))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SetDmg(Weapon weapon)
        {
            switch (CharClass)
            {
                case CharClass.Warrior:
                    DmgLowerBound = weapon.DmgLowerBound + Strength;
                    DmgUpperBound = weapon.DmgUpperBound + Strength;
                    SpecialAttack = DmgUpperBound + 10;
                    break;
                case CharClass.Hunter:
                    DmgLowerBound = weapon.DmgLowerBound + Dexerity + Strength;
                    DmgUpperBound = weapon.DmgUpperBound + Dexerity + Strength;
                    SpecialAttack = DmgUpperBound + 10;
                    break;
                case CharClass.Paladin:
                    DmgLowerBound = weapon.DmgLowerBound + Intelligence + Dexerity;
                    DmgUpperBound = weapon.DmgUpperBound + Intelligence + Dexerity;
                    SpecialAttack = DmgUpperBound + 10;
                    break;
                default:
                    break;
            }

        }
        public void SpecialAttackdmg(Monster monster)
        {
            if (SpecialAttackCounter < 1)
            {
                SpecialAttackCounter++;
                Console.WriteLine("counter" + SpecialAttackCounter);
                WarCry();
                Console.ForegroundColor = ConsoleColor.Red;
                monster.TakeDmg(SpecialAttack);
                Console.WriteLine("You blaze the monster with a special attack!!!!");
                Console.WriteLine($"You hit for {SpecialAttack}hitpoints...");
                Console.WriteLine("The monster is dazed.. ");
                Console.ForegroundColor = ConsoleColor.White;
                var p1 = new System.Windows.Media.MediaPlayer();
                p1.Open(new System.Uri(Environment.CurrentDirectory + @"\Special.wav"));
                p1.Play();
            }
            else if (SpecialAttackCounter == 3)
            {
                Console.WriteLine("Something in the woods seems to be blocking your special attacks..");
            }
            else
            {
                Console.WriteLine("You can only do one special attack per battle! \nTry running away if you are scared..");
            }

        }


        public void AddWeaponToInventory(Weapon newWeapon)
        {
            Weapon currentWeapon = UserInventory.OfType<Weapon>().FirstOrDefault(w => w.Equipped == true);
            if (currentWeapon == null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"you found a");
                Console.WriteLine(newWeapon);
                Console.WriteLine("Its now equiped.");
                Console.ForegroundColor = ConsoleColor.White;
                newWeapon.Equipped = true;
                UserInventory.Add(newWeapon);
                SetDmg(newWeapon);
            }
            else if (newWeapon.DmgUpperBound > currentWeapon.DmgUpperBound)
            {
                currentWeapon.Equipped = false;
                newWeapon.Equipped = true;
                SetDmg(newWeapon);
                UserInventory.Add(newWeapon);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"you found a");
                Console.WriteLine(newWeapon);
                Console.WriteLine("Its now equiped.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You found a..");
                Console.WriteLine(newWeapon);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You current one is better.. you add it to inventory..");
                UserInventory.Add(newWeapon);
            }
            Console.ReadKey();
        }
        public void AddShieldToInventory(Shield newShield)
        {
            Shield currentShield = UserInventory.OfType<Shield>().FirstOrDefault(w => w.Equipped == true);
            if (currentShield == null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"you found a... ");
                Console.WriteLine(newShield);
                Console.WriteLine("Its now equiped.");
                Console.ForegroundColor = ConsoleColor.White;
                newShield.Equipped = true;
                BlockRating = newShield.BlockRating;
                UserInventory.Add(newShield);
                Armour = newShield.ArmourAmount;
            }
            else if (newShield.BlockRating > currentShield.BlockRating)
            {
                currentShield.Equipped = false;
                newShield.Equipped = true;
                Armour = newShield.ArmourAmount;
                BlockRating = newShield.BlockRating;
                UserInventory.Add(newShield);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"you found a... ");
                Console.WriteLine(newShield);
                Console.WriteLine("Its now equiped.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You found a..");
                Console.WriteLine(newShield);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You current one is better.. you add it to inventory..");
                UserInventory.Add(newShield);
            }
            Console.ReadKey();
        }


    }
}
