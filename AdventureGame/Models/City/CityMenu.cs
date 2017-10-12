using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models.City
{
    static class CityMenu
    {
        static public void InCityMenu(CharacterClass character, Vendor vendor) // Done
        {
            string inputAnswer = "";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            while (inputAnswer != "4")
            {
                
                player.SoundLocation = Environment.CurrentDirectory + @"\InCityMenu.wav";
                player.PlayLooping();
                Console.WriteLine("-------------------------------------".PadLeft(58));
                Console.WriteLine("|     Inside City                   |".PadLeft(58));
                Console.WriteLine("-------------------------------------".PadLeft(58));
                Console.WriteLine("|     Where to next:                |".PadLeft(58)); 
                Console.WriteLine("|     1. Tavern                     |".PadLeft(58));
                Console.WriteLine("|     2. Blacksmith                 |".PadLeft(58));
                Console.WriteLine("|     3. Vendor                     |".PadLeft(58));
                Console.WriteLine("|                                   |".PadLeft(58));
                Console.WriteLine("|     4. Back to Main Menu          |".PadLeft(58));
                Console.WriteLine("|                                   |".PadLeft(58));
                Console.WriteLine("-------------------------------------".PadLeft(58));

                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(27, 28);
                inputAnswer = Console.ReadLine();
                switch (inputAnswer)
                {
                    case "1":
                        Console.Clear();
                        TavernMainQuest.TavernaMenu(character);
                        break;
                    case "2":
                        
                        Blacksmith.BlacksmithMenu(character);
                        break;
                    case "3":
                        Console.Clear();
                        Vendor.VendorMenu(character, vendor);
                        break;
                    case "4":
                        
                        break;

                    default:
                        Console.WriteLine("Please select between 1 - 4");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                }
            }
            player.Stop();
        }
    }
}
