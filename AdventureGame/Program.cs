using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureGame.Models;
using AdventureGame.Models.Adventure;
using AdventureGame.Models.City;
using AdventureGame.Models.Mobs;
using AdventureGame.Models.ItemRelated;

namespace AdventureGame
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Welcome To stranded";
            Vendor localVendor = new Vendor();
            string menuChoice = "";
                        
            do
            {
                Console.Clear();

                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("Welcome".PadLeft(55));
                Console.WriteLine("");
                Console.WriteLine("1. Story Mode".PadLeft(58));
                
                Console.WriteLine("0. Quit Game!".PadLeft(58));
                menuChoice = Console.ReadLine();
                switch (menuChoice.ToLower())
                {
                    case "1":
                        Console.Clear();
                        GameMenu(GameStory.StoryStart(), localVendor);
                        menuChoice = "0";
                        break;
                    case "god mode": // CHEAT !!!!
                        CharacterClass character = new CharacterClass("James The Great", 3);
                        character.Gold = 100000;
                        character.MaxHealth = 10000;
                        character.Health = 10000;
                        character.MainQuest = "Find the Princess";
                        GameMenu(character, localVendor);
                        break;
                    case "0":

                    default:
                        break;
                }
            } while (menuChoice != "0");
        }

        static public void GameMenu(CharacterClass character, Vendor vendor)
        {
            string inputAnswer = "";
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(AsciiArt.MainHeading());
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("-------------------------------------".PadLeft(58));
                Console.WriteLine("|     Main Menu                     |".PadLeft(58));
                Console.WriteLine("-------------------------------------".PadLeft(58));
                Console.WriteLine("|     Where to next:                |".PadLeft(58)); 
                Console.WriteLine("|     1. City                       |".PadLeft(58));
                Console.WriteLine("|     2. Adventure Menu             |".PadLeft(58));
                Console.WriteLine("|     3. Character Information      |".PadLeft(58));
                Console.WriteLine("|                                   |".PadLeft(58));
                Console.WriteLine("|     9. Try and leave island       |".PadLeft(58));
                Console.WriteLine("|     0. Quit Game                  |".PadLeft(58));
                Console.WriteLine("|                                   |".PadLeft(58));
                Console.WriteLine("-------------------------------------".PadLeft(58));

                Console.SetCursorPosition(27, 18);
                inputAnswer = Console.ReadLine();
                switch (inputAnswer)
                {
                    case "1":
                        
                        CityMenu.InCityMenu(character, vendor);
                        break;
                    case "2":
                        
                        Adventure.AdventureMenu(character);
                        
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine(character.ClassPrintInformation());
                        Console.ReadKey();
                        break;
                    case "9":
                        Console.Clear();
                        inputAnswer= GameStory.Ending(character);
                        
                        
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Maybe be able to save.. then we have to have a menu in the biggining start game and load");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }

            } while (inputAnswer != "0");
        }
    }
}
