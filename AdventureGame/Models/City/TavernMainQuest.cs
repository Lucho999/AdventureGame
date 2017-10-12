using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Models
{
    static class TavernMainQuest 
    {
        static public void TavernaMenu(CharacterClass character) // Done
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Environment.CurrentDirectory + @"\Taverna.wav";
            player.PlayLooping();

            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"                Welcome to the Tavern {character.Name}");
            Console.WriteLine("----------------------------------------------------------------------");
            if (character.MainQuest == "Find someone to translate letter")
            {
                if (character.Charisma > 5)
                {
                    if (character.Intelligence < 5)
                    {
                        Console.WriteLine("Im sorry you are not smart enough to translate your letter yet i cannot help you in anyway...");
                    }
                    else
                    {
                        Console.WriteLine("I Think you should try to translate your letter now..");
                        Console.WriteLine("Please i need help im beeing keept captive in the High Vulcanic Mountains please hurry \nKind Regards Princess Zelda");

                        Console.WriteLine("(quest updated)");
                        character.MainQuest = "Find the Princess";
                    }
                }
                else
                {
                    Console.WriteLine("Im sorry we dont serve your kind here...\nMaybe you should come back when you are a bit more charasmatic..");
                }
            }
            else
            {
                Console.WriteLine("You should try and find the princess on High Vulcanic Mountains \nIf you climb high enough you should be able to find her.");
                Console.WriteLine("Dont forget to come back to the city in order to imporove your equipment \nsince its gonna get harder the more you climb");
            }
            if (character.Health < character.MaxHealth)
            {
                HealInTavern(character);
            }
            Console.ReadKey();
            Console.Clear();
            player.Stop();
        }
        
        static public void HealInTavern(CharacterClass character) // Done
        {
            Console.ReadKey();
            Console.Clear();
            string inputAnswer;

            Console.WriteLine("(Man at Tavern)...wait..");
            Console.WriteLine($"{character.Name} you look like hell.. I might have something if you are interested.");
            Console.WriteLine("1. Yes please...");
            Console.WriteLine("2. NO i dont need anything from your filthy taverna!!!");
            inputAnswer = Console.ReadLine();
            switch (inputAnswer)
            {
                case "1":
                    Console.WriteLine("The man gives you a secret blend.. looks fishy...");
                    character.Heal();
                    Console.WriteLine("(Man at Tavern) Come back if you need something else..\nAnd remember i work on referals so dont forget to mention my name to your friends.");
                    break;
                case "2":
                    Console.WriteLine("Okey so why are you in here.. Leave..!");
                    break;

                default:
                    Console.WriteLine("Hmm come back when you can answer normally..");
                    break;
            }
        }

    }
}
