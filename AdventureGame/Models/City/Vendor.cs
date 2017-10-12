using AdventureGame.Models.ItemRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models.City
{
    class Vendor
    {
        public List<Weapon> StoreWeaponInventory { get; set; }
        public List<Shield> StoreShieldInventory { get; set; }

        public Vendor()
        {
            Random rand = new Random();
            StoreWeaponInventory = new List<Weapon>
            {
               new Weapon(1,2),new Weapon(1,3),new Weapon(1,9),new Weapon(2,2),new Weapon(2,3),new Weapon(2,4),new Weapon(3,2),new Weapon(3,3),new Weapon(3,4)
            };
            StoreShieldInventory = new List<Shield>
            {
               new Shield(1,2),new Shield(1,3),new Shield(1,4),new Shield(2,2),new Shield(2,3),new Shield(2,4),new Shield(3,2),new Shield(3,3),new Shield(3,4)
            };
        }
        static public void VendorMenu(CharacterClass character, Vendor vendor)
        {
            string answer = "";
            if (character.Charisma > 5)
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Clear();
                    Console.WriteLine("**********************************************************");
                    Console.WriteLine("                       Vendor ");
                    Console.WriteLine("**********************************************************");
                    Console.WriteLine($"- How may i help you {character.Name}?\n");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("(Answer) ");
                    Console.WriteLine("1. I have items to sell.");
                    Console.WriteLine("2. I would like to buy Weapons.");
                    Console.WriteLine("3. I would like to buy Shields.");
                    Console.WriteLine("4. I would like to buy a Potion (150 gold).");
                    Console.WriteLine();
                    Console.WriteLine("5. Bye... (Go back to city menu).");
                    character.PrintInfoForShop();
                    answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "1":
                            vendor.SellItems(character); // fix this menu
                            break;
                        case "2":
                            vendor.BuyWeapons(character); 
                            break;
                        case "3":
                            vendor.BuyDefensive(character);
                            break;
                        case "4":
                            vendor.BuyPotion(character);
                            break;
                        case "5":
                            Console.WriteLine("Hope to see you soon..");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Please try again I didnt understand..");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                
                } while (answer != "5");
            }
            else
            {
                Console.WriteLine("Im sorry just get out of here, i cant look at you even..");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void SellItems(CharacterClass character) // Done
        {
            int value = 0;
            Console.WriteLine("Would you like to sell all your unusable items?");
            for (int i = 0; i < character.UserInventory.Count; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine("yes \\ no");

            string answerInput = Console.ReadLine().ToLower();
            switch (answerInput)
            {
                case "yes":
                    for (int i = character.UserInventory.Count - 1; i >= 0; i--)
                    {
                        if (!character.UserInventory[i].Equipped)
                        {
                            value += character.UserInventory[i].Value;
                            character.UserInventory.RemoveAt(i);
                        }
                    }
                    if (value == 0)
                    {
                        Console.WriteLine("You have no equipment to sell..");
                    }
                    else
                    {
                        Console.WriteLine($"You have sold your unusable items and added {value}, to your Goldsack!");
                        character.Gold += value;
                    }
                    break;
                case "no":
                    Console.WriteLine("Maybe you want something else?");
                    Console.WriteLine("Have you should visited the city's local blacksmith, maybe he has what you need..");
                    
                    break;
                default:
                    Console.WriteLine("Im guess you want something else..");
                    break;
            }
            Console.WriteLine("Press Any Key..");
            Console.ReadKey();
            Console.Clear();
        }
        public void BuyWeapons(CharacterClass character) // Done
        {

            string buyWep = "y";
            int whatWeaponID;
            do
            {
                
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine("This is what i have for you..");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("                 Weapons Inventory");
                Console.WriteLine("---------------------------------------------------------");
                for (int i = 0; i < StoreWeaponInventory.Count; i++)
                {
                    Console.WriteLine($"Id:{i + 1}. {StoreWeaponInventory[i].ItemQuality} {StoreWeaponInventory[i].TypeOfWeapon}".PadRight(25) +
                       $"Dmg ({StoreWeaponInventory[i].DmgLowerBound} - {StoreWeaponInventory[i].DmgUpperBound})".PadRight(16) + $"Price: {StoreWeaponInventory[i].Price}");
                }
                Console.WriteLine("");
                Console.WriteLine("0. Not Interested");
                Console.WriteLine("---------------------------------------------------------");
                character.PrintInfoForShop();

                Weapon currentWeapon = character.UserInventory.OfType<Weapon>().FirstOrDefault(w => w.Equipped == true);
                
               
                if (currentWeapon != null)
                {
                    Console.WriteLine("Equipped Weapon");
                    Console.WriteLine($"{currentWeapon.ItemQuality} {currentWeapon.TypeOfWeapon} Dmg: ({currentWeapon.DmgLowerBound} - {currentWeapon.DmgUpperBound})");
                    Console.WriteLine("---------------------------------------------------------");
                }
                
                Console.WriteLine("What ID number would you like to purchase?");
                    if (int.TryParse(Console.ReadLine(), out whatWeaponID))
                    {
                        if (whatWeaponID <= StoreWeaponInventory.Count && whatWeaponID > 0)
                        {
                            if (character.Gold >= StoreWeaponInventory[whatWeaponID - 1].Price)
                            {
                                if (character.Charisma >=10)
                                {
                                Console.WriteLine("(Vendor) -You know what I like you, i will give it to you for half price.. ");
                                Console.WriteLine("Dont tell anyone..");
                                character.Gold -= StoreWeaponInventory[whatWeaponID - 1].Price/2;
                                Console.WriteLine($"{StoreWeaponInventory[whatWeaponID - 1].Price / 2} gold has been removed..");
                                
                                }
                                else
                                {
                                character.Gold -= StoreWeaponInventory[whatWeaponID - 1].Price;
                                Console.WriteLine($"{StoreWeaponInventory[whatWeaponID - 1].Price} has been removed..");
                                }
                                var p1 = new System.Windows.Media.MediaPlayer();
                                p1.Open(new System.Uri(Environment.CurrentDirectory + @"\cash.wav"));
                                p1.Play();
                                Console.WriteLine("Congratulations you have bought a new Item");
                                character.AddWeaponToInventory(StoreWeaponInventory[whatWeaponID - 1]);
                                buyWep = "n";
                                StoreWeaponInventory.RemoveAt(whatWeaponID-1);
                                
                            }
                            else
                            {
                                Console.WriteLine("You cannot afford this.. Maybe start out with something smaller?");
                            Console.ReadKey();
                            }
                        }
                        else if (whatWeaponID == 0)
                        {
                        Console.WriteLine("Okeeeeey So what are you doing in here?????");
                        Console.ReadKey();
                        buyWep = "n";
                        }
                        else
                        {
                            Console.WriteLine($"Please try a number between 1-{StoreWeaponInventory.Count}, or 0 to exit..");
                        Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"I didnt understand that, Please try a number between 1-{StoreWeaponInventory.Count}, or 0 to exit..");
                        Console.ReadKey();
                    }
                
            } while (buyWep != "n" );
        }
        public void BuyDefensive(CharacterClass character) // Done
        {
            string buyDef = "y";
            int whatShieldID;
            do
            {
                Console.Clear();

                Console.WriteLine("This is what i have for you..");
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("                        Shield Inventory");
                Console.WriteLine("--------------------------------------------------------------------");
                for (int i = 0; i < StoreShieldInventory.Count; i++)
                {
                    Console.WriteLine($"Id:{i + 1}. {StoreShieldInventory[i].ItemQuality} {StoreShieldInventory[i].ShieldName}".PadRight(30) +
                       $"Armour ({StoreShieldInventory[i].ArmourAmount})".PadRight(16) + $"Rating {StoreShieldInventory[i].BlockRating}  " + $"Price: {StoreShieldInventory[i].Price}");
                }
                Console.WriteLine("");
                Console.WriteLine("0. Not Interested");
                Console.WriteLine("--------------------------------------------------------------------");
                character.PrintInfoForShop();

                Shield currentShield = character.UserInventory.OfType<Shield>().FirstOrDefault(w => w.Equipped == true);

                if (currentShield != null)
                {
                    Console.WriteLine("Equipped Shield");
                    Console.WriteLine($"{currentShield.ItemQuality} {currentShield.ShieldName} Armour: {currentShield.ArmourAmount} Rating: {currentShield.BlockRating}");
                    Console.WriteLine("---------------------------------------------------------");
                }

                Console.WriteLine("What ID number would you like to purchase?");
                if (int.TryParse(Console.ReadLine(), out whatShieldID))
                {
                    if (whatShieldID <= StoreShieldInventory.Count && whatShieldID > 0)
                    {
                        if (character.Gold > StoreShieldInventory[whatShieldID - 1].Price)
                        {
                            var p1 = new System.Windows.Media.MediaPlayer();
                            p1.Open(new System.Uri(Environment.CurrentDirectory + @"\cash.wav"));
                            p1.Play();
                            Console.WriteLine("Congratulations you have bought a new Item");
                            Console.WriteLine($"{StoreShieldInventory[whatShieldID - 1].Price} gold has been removed..");
                            character.AddShieldToInventory(StoreShieldInventory[whatShieldID - 1]);
                            character.Gold -= StoreShieldInventory[whatShieldID - 1].Price;
                            buyDef = "n";
                            StoreShieldInventory.RemoveAt(whatShieldID - 1);
                            
                        }
                        else
                        {
                            Console.WriteLine("You cannot afford this.. Maybe start out with something smaller?");
                            Console.ReadKey();
                        }
                    }
                    else if (whatShieldID == 0)
                    {
                        Console.WriteLine("Im getting really tiered of this..");
                        buyDef = "n";
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"Please try a number between 1-{StoreWeaponInventory.Count} Or 0 to exit..");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine($"I didnt understand that, Please try a number between 1-{StoreWeaponInventory.Count} Or 0 to exit..");
                    Console.ReadKey();
                }
            } while (buyDef != "n");
        }
        public void BuyPotion(CharacterClass character) // Done
        {
            if (character.PotionBag >= 3)
            {
                Console.WriteLine("(Vendor) Im sorry but you cannot carry more than 3 Health potions");
            }
            else
            {
                if (character.Gold >= 150)
                {
                    character.Gold -= 150;
                    character.PotionBag += 1;
                    Console.WriteLine("150 gold has been removed..");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("One Health Potion has been added to your bag...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("(Vendor) Im sorry you dont have enough gold each bottle cost 150 Gold..");
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
