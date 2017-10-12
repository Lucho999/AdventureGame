using AdventureGame.Models.ItemRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models.City
{
    static class Blacksmith
    {
        static public void BlacksmithMenu(CharacterClass character)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Environment.CurrentDirectory + @"\Blacksmith.wav";
            player.PlayLooping();
            bool ContinueInMenu = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("***************************************************");
                Console.WriteLine("                  BlackSmith");
                Console.WriteLine("***************************************************");
                Console.WriteLine("- I might be able to help you... for some gold... ");
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("(Answer) I would like to ...");
                Console.WriteLine("1. Upgrade Item ");
                Console.WriteLine("2. Get crafting materials for my items");
                Console.WriteLine();
                Console.WriteLine("4. No thanks.. (go back to city menu)");
                Console.WriteLine("---------------------------------------------------");
                
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        UpgradeItem(character);
                        break;
                    case "2":
                        DestoryItem(character);
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("(BlackSmith) -You wont survive without me, i will see you soon");
                        ContinueInMenu = false;
                        Console.ReadKey();
                        Console.Clear();
                        
                        break;
                    default:
                        Console.WriteLine("(BlackSmith) -I'm sure you are to drunk to be in here...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (ContinueInMenu);
            Console.ForegroundColor = ConsoleColor.White;
            
            player.Stop();
        }

        static public void UpgradeItem(CharacterClass character) // Done
        {
            string upgradeChoice = "";
            int shieldCraftingCost =0;
            int weaponCraftingCost =0;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Weapon currentWeapon = character.UserInventory.OfType<Weapon>().FirstOrDefault(w => w.Equipped == true);
                Shield currentShield = character.UserInventory.OfType<Shield>().FirstOrDefault(w => w.Equipped == true);

                Console.WriteLine("Anything you want to upgrade? \nCurrently wearing these Items: ");
                Console.WriteLine("----------------------------------------");
                if (currentWeapon != null)
                {
                    weaponCraftingCost = (int)currentWeapon.ItemQuality * 100;
                    Console.WriteLine($"1. {currentWeapon.ItemQuality} {currentWeapon.TypeOfWeapon} Dmg: ({currentWeapon.DmgLowerBound} - {currentWeapon.DmgUpperBound})");
                    Console.WriteLine($"   Upgrade Cost Gold: {weaponCraftingCost} Material: {weaponCraftingCost}");
                }
                if (currentShield != null)
                {
                    shieldCraftingCost = (int)currentShield.ItemQuality * 100;
                    Console.WriteLine($"2. {currentShield.ItemQuality} {currentShield.ShieldName} Armour: {currentShield.ArmourAmount}");
                    Console.WriteLine($"   Upgrade Cost Gold: {shieldCraftingCost} Material: {shieldCraftingCost}");
                }
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("3. Dont want to upgrade.. Anything");
                Console.WriteLine("----------------------------------------");
                character.PrintInfoForShop();
                upgradeChoice = Console.ReadLine();

                switch (upgradeChoice)
                {
                    case "1":
                        UpgradeWeapon(character, currentWeapon, weaponCraftingCost);
                        break;
                    case "2":
                        UpgradeShield(character, currentShield, shieldCraftingCost);
                        break;
                    case "3":
                        Console.WriteLine("(BlackSmith) -Okey i have others that want help, what do you want!!!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Again with this???");
                        break;
                }
                
            } while (upgradeChoice != "3");
        }
        static public void UpgradeWeapon(CharacterClass character, Weapon currentWeapon, int weaponCraftingCost) // Done
        {
            string reRollItem = "";

            if ((int)currentWeapon.ItemQuality < 12)
            {
                if (character.Gold >= weaponCraftingCost && character.CraftingMaterial >= weaponCraftingCost)
                {
                    character.Gold -= weaponCraftingCost;
                    character.CraftingMaterial -= weaponCraftingCost;
                    Weapon newWeapon = UpgradeWeapon(currentWeapon);

                    Console.WriteLine($"Old Weapon \n" + currentWeapon);
                    character.UserInventory.Remove(currentWeapon);
                    character.AddWeaponToInventory(newWeapon);

                    var p1 = new System.Windows.Media.MediaPlayer();
                    p1.Open(new System.Uri(Environment.CurrentDirectory + @"\cash.wav"));
                    p1.Play();
                }
                else
                {
                    Console.WriteLine("You cannot afford that... \nCheck that you have enough gold or materials");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("You cannot upgrade that its fully upgraded.");
                Console.WriteLine("Would you like to reroll the stats for the current weapon? ");
                Console.WriteLine("Cost: 1000g");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                reRollItem = Console.ReadLine();
                switch (reRollItem)
                {
                    case "1":
                        if (character.Gold >= 1000)
                        {
                            character.Gold -= 1000;
                            Weapon newWeapon = new Weapon((int)currentWeapon.TypeOfWeapon, (int)currentWeapon.ItemQuality);
                            Console.WriteLine($"Old Weapon \n" + currentWeapon);
                            character.UserInventory.Remove(currentWeapon);
                            character.AddWeaponToInventory(newWeapon);
                        }
                        else
                        {
                            Console.WriteLine("Come Back When you can pay me..");
                        }
                        break;
                    case "2":
                        Console.WriteLine("(The Blacksmith) -Maybe you should, never know what can happen!!!");
                        break;
                    default:
                        Console.WriteLine("(Luis) -Stop trying to ruin the game!!!");
                        break;
                }
            }
        }
        static public void UpgradeShield(CharacterClass character, Shield currentShield, int shieldCraftingCost) // Done
        {
            string reRollItem = "";
            if ((int)currentShield.ItemQuality < 12)
            {
                if (character.Gold >= shieldCraftingCost && character.CraftingMaterial >= shieldCraftingCost)
                {
                    character.Gold -= shieldCraftingCost;
                    character.CraftingMaterial -= shieldCraftingCost;
                    Shield newShield = UpgradeShield(currentShield);
                    Console.WriteLine($"Old shield \n" + currentShield);
                    character.UserInventory.Remove(currentShield);
                    character.AddShieldToInventory(newShield);
                }
                else
                {
                    Console.WriteLine("You cannot afford that... \nCheck that you have enough gold or materials");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("You cannot upgrade that its fully upgraded.");
                Console.WriteLine("Would you like to reroll the stats for the current shield? ");
                Console.WriteLine("Cost: 1000g");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                reRollItem = Console.ReadLine();
                switch (reRollItem)
                {
                    case "1":
                        if (character.Gold >= 1000)
                        {
                            character.Gold -= 1000;
                            Shield newShield = new Shield((int)currentShield.TypeOfShield, (int)currentShield.ItemQuality);
                            Console.WriteLine($"Old shield \n" + currentShield);
                            character.UserInventory.Remove(currentShield);
                            character.AddShieldToInventory(newShield);
                        }
                        else
                        {
                            Console.WriteLine("Come Back When you can pay me..");
                        }
                        break;
                    case "2":
                        Console.WriteLine("(The Blacksmith) -Maybe you should, never know what can happen!!!");
                        break;
                    default:
                        Console.WriteLine("(Luis) -Stop trying to ruin the game!!!");
                        break;
                }

            }
        }

        static public void DestoryItem(CharacterClass character) // Done
        {
            Console.Clear();
            int value = 0;
            Console.WriteLine("I might be able to do that for you.. Lets see what you have..");
            Console.WriteLine("Do you want to destroy all your unusable equipment for materials? (yes/no)");
            string answerInput = Console.ReadLine();
            switch (answerInput.ToLower())
            {
                case "yes":
                    for (int i = character.UserInventory.Count - 1; i >= 0; i--)
                    {
                        if (!character.UserInventory[i].Equipped)
                        {
                            value += character.UserInventory[i].MaterialValue;
                            character.UserInventory.RemoveAt(i);
                        }
                    }
                    if (value == 0)
                    {
                        Console.WriteLine("You have no equipment to destroy..");
                    }
                    else
                    {
                        Console.WriteLine($"You have added {value} materials to your bag!");
                        character.CraftingMaterial += value;
                    }
                    break;
                case "no":
                    Console.WriteLine("Are you sure? hmm i guess you dont have a plan..");

                    break;
                default:
                    Console.WriteLine("hmmm you seam confused..");
                    break;
            }
            
        }
        static public Weapon UpgradeWeapon(Weapon currentWeapon) // Done
        {
            int quality = (int)currentWeapon.ItemQuality + 1;
            Weapon newWeapon = new Weapon((int)currentWeapon.TypeOfWeapon, quality);
            return newWeapon;
        }
        static public Shield UpgradeShield(Shield currentShield) // Done
        {
            int quality = (int)currentShield.ItemQuality + 1;
            Shield newShield = new Shield((int)currentShield.TypeOfShield, quality);
            return newShield;
        }
    }
}

