using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureGame.Models.Mobs;
using AdventureGame.Models.ItemRelated;

namespace AdventureGame.Models.Adventure
{
    class Adventure
    {

        static public void AdventureMenu(CharacterClass character) //Done
        {
            bool menuBool = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--------------------------------------------------------".PadLeft(69));
                Console.WriteLine("|                Adventure Menu                        |".PadLeft(69));
                Console.WriteLine("--------------------------------------------------------".PadLeft(69));
                Console.WriteLine("|   Chooce where your next adventure leads you?        |".PadLeft(69));
                Console.WriteLine("|   1. Find a low level monster in the woods           |".PadLeft(69));
                Console.WriteLine("|   2. Join the Pits and fight your way to the top.    |".PadLeft(69));
                Console.WriteLine("|   3. Go up the Vulcanic Mountain                     |".PadLeft(69));
                Console.WriteLine("|                                                      |".PadLeft(69));
                Console.WriteLine("|   4. Back To main Menu                               |".PadLeft(69));
                Console.WriteLine("|                                                      |".PadLeft(69));
                Console.WriteLine("--------------------------------------------------------".PadLeft(69));
                
                string userMenuInput = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
              
                switch (userMenuInput)
                {
                    case "1":
                        
                        Woods(character);
                        break;
                    case "2":
                        
                        Pits(character);
                        break;
                    case "3":
                        Boss(character);
                        break;
                    case "4":
                        menuBool = true;
                        break;
                    default:
                        Console.WriteLine("There is no such choice!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (!menuBool);
        }
        static public bool Battle(Monster monster, CharacterClass character, int whatheading) 
        {
            Console.Clear();
            bool fightContinue = true;
            bool fightOutCome = false;

            while (fightContinue)
            {
                if (character.Health < 10)
                {
                    Console.WriteLine("You cannot continue or start a fight with lower health than 10hp \nPlease visit The Tavern or vendor and buy potion");
                    fightContinue = false;
                    fightOutCome = false;
                }
                while (fightContinue)
                {

                    Console.Clear();
                    switch (whatheading)
                    {
                        case 1:
                            AsciiArt.WoodsArt();
                            AsciiArt.WoodsTitle();
                            break;
                        case 2:
                            AsciiArt.PitsTitle();
                            break;
                        case 3:
                            AsciiArt.MountainHeading();
                            AsciiArt.BossTitle();
                            break;
                    }
                    if (monster is Creature)
                    {
                        Creature tempCreature =(Creature)monster;
                        tempCreature.PrintMonsterInfo();
                    }
                    else if (monster is Boss)
                    {
                        Boss tempBoss = (Boss)monster;
                        tempBoss.PrintMonsterInfo();
                    }
                    character.ClassBattlePrint();

                    //make method that returns 2 values
                    Console.WriteLine("1. Standard Attack");
                    Console.WriteLine("2. Special Attack");
                    Console.WriteLine("3. Take Health Potion");
                    Console.WriteLine("4. Flee");
                    string battleInput = Console.ReadLine();
                    switch (battleInput)
                    {
                        case "1":
                            monster.TakeDmg(character.DoDmg());
                            character.TakeDmg(monster.DoDmg());
                            break;
                        case "2":
                            character.SpecialAttackdmg(monster);
                            break;
                        case "3":
                            character.TakePotion();
                            
                            break;
                        case "4":
                            if (character.DmgUpperBound > monster.DmgHigherBound)
                            {
                            Console.WriteLine("You managed to flee the battle... you coward...");
                            fightContinue = false;
                            fightOutCome = false;
                            }
                            else
                            {
                                Console.WriteLine("You cannot flee you must stay and face the consequences");
                            }
                            break;
                        default:
                            Console.WriteLine("There is no such alternativ, try to focus.. \nIf your nervous you can always flee..");
                            break;
                    }
                    if (monster.Health <= 0)
                    {
                        monster.MonsterDied(monster, character);

                        fightContinue = false;
                        fightOutCome = true;

                    }
                    else if (character.Health <= 10)
                    {
                        Console.WriteLine("Your health is to low you cannot continue..");
                        fightContinue = false;
                        fightOutCome = false;
                    }
                    Console.WriteLine("Press anykey..");
                    Console.ReadKey();
                    Console.Clear();
                };
            };
            return fightOutCome;

        }


        static public void Woods(CharacterClass character) // Done
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            

            character.SpecialAttackCounter = 3;
            bool battleOutcome = false;
            string keepMoving;
            Random rand1 = new Random();
            int creatureType = rand1.Next(1, 4);
            Console.WriteLine("Going out in the woods to find a monster.");
            Console.ReadKey();
            
            int monsterSize = rand1.Next(1, 4);
            
            
            Console.WriteLine("Look ahead... You see a monster.. ");
            Console.ReadKey();
            Console.Clear();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Environment.CurrentDirectory + @"\Woods.wav";
            player.PlayLooping();
            Console.ForegroundColor = ConsoleColor.White;
            Creature monster = new Creature(monsterSize, creatureType);
            battleOutcome = Battle(monster,character,1);
            if (battleOutcome)
            {
                Console.WriteLine("Do you want to go deeper in the woods?? (y/n)"); // kanske hoppar över denna checken och så får han möta en ny direkt..
                keepMoving = Console.ReadLine();
                if (keepMoving == "y")
                {
                    Console.WriteLine("get ready..");
                    Woods(character);
                }
                else
                {
                    Console.WriteLine("you seem nervous, you should probably head back to the city...");
                    Console.Read();
                    Console.Clear();
                }
            }
            player.Stop();
        }
        static public void Pits(CharacterClass character)  // Done
        {
            
            Console.WriteLine("Now its time to display your power see how long you can last...");
            int pitsBattleCounter = 0;
            character.SpecialAttackCounter = 0;
            bool battleOutCome = false;
            bool battleContinue = true;
            Console.ReadKey();
            Console.Clear();
            Random monsterSizeRand = new Random();
            Creature pitsMonster;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Environment.CurrentDirectory + @"\Pits.wav";
            player.PlayLooping();

            while (battleContinue)
            {
                battleOutCome = false;
                AsciiArt.PitsTitle();
                Console.WriteLine($"This is your battle no {pitsBattleCounter + 1} of max 10 in a row.");
                Console.WriteLine("Next Monster is already ready.. ");
                Console.WriteLine("Get ready to fight!");
                Console.ReadKey();
                Console.Clear();

                if (pitsBattleCounter < 9)
                {
                    pitsMonster = new Creature(monsterSizeRand.Next(4, 7), pitsBattleCounter + 1);
                }
                else
                {
                    pitsMonster = new Creature(7, 10);
                }

                battleOutCome = Battle(pitsMonster, character, 2);
                if (battleOutCome)
                {
                    pitsBattleCounter++;
                }
                else
                {
                    battleContinue = false;
                    Console.WriteLine($"You manage to beat {pitsBattleCounter} Opponents, Get some better gear and you might climb to the top.");
                    
                }
                if (pitsBattleCounter == 10)
                {
                    Console.WriteLine($"Congratiulations {character.Name} You managed to fight your way up to the top of the pits. \nYour name will be remembered for all time!! "); // insert awesome reward
                    character.AddWeaponToInventory(new Weapon(1, 13));
                    battleContinue = false;
                }
            }
            Console.ReadKey();
            Console.Clear();
            player.Stop();
        }
        static public void Boss(CharacterClass character) // Done
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();

            character.SpecialAttackCounter = 0;
            bool battleOutCome = false;

            if (character.BossEncounter > 3)
            {
                Console.WriteLine("There are no more Bosses you are done, get of the island...");
            } 
            else
            {
                // background music choice
                if (character.BossEncounter <3) 
                {
                    
                    player.SoundLocation = Environment.CurrentDirectory + @"\Perfect Thunder Storm.wav";
                    player.PlayLooping();
                }
                else
                {
                    
                    player.SoundLocation = Environment.CurrentDirectory + @"\LastBossFight.wav";
                    player.PlayLooping();
                }

                
                Boss bossEncounter = new Boss(1, character.BossEncounter);
                battleOutCome = Battle(bossEncounter, character, 3);

                if (battleOutCome)
                {
                    player.Stop();
                    GameStory.StoryMiddle(character.BossEncounter, character);
                    character.BossEncounter++;
                    
                }
                else
                {
                    Console.WriteLine("Come back when you are stronger..!");
                }
               
            }
            player.Stop();
        }
        
        
    }
}
