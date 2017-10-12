using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureGame.Models.ItemRelated;
using System.IO;

namespace AdventureGame.Models
{
    static class GameStory
    {
        static public CharacterClass StoryStart()
        {
            string nameInput;
            
            int raceAnswer = 0;
            string answerInput;
            bool choiceMade = false;
            
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Environment.CurrentDirectory + @"\Shorebirds.wav";
            player.PlayLooping();
            Console.WriteLine("(Boy)...heeey.. stranger...");
            Console.ReadKey();
            Console.WriteLine("You open your eyes... and get blinded by the sun...");
            Console.WriteLine("Are you okey???");
            Console.WriteLine("(Answer):......");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("(Boy) I hear my dad calling for me... he looks over his shoulder...");
            do
            {
                Console.WriteLine("I have to go, but what is your name?");
                Console.Write("(Answer):");
                nameInput = Console.ReadLine();
                Console.WriteLine("Are you sure? It is not possible to change after this...\nDo you want to change? (y/n)");
                answerInput = Console.ReadLine().ToLower();
                switch (answerInput)
                {
                    case "y":
                        Console.WriteLine("Okey try again..");
                        answerInput = "y";
                        break;
                    case "n":
                        Console.WriteLine($"Okey lets go, {nameInput}.");
                        answerInput = "n";
                        break;

                    default:
                        Console.WriteLine("I dont get that but lets try this again..");
                        answerInput = "y";
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (answerInput =="y");
            Console.WriteLine($"Nice to meet you {nameInput}.. he runs up the beach out of sight");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("You start looking around and the only thing you see is water, \nyou realize that your stranded on a beach and have no idea where you are...");
            Console.WriteLine("You try to stand up and decide to..");
            Console.WriteLine("(Decision)\n1. Follow the footsteps of the boy and see if he can help you.. ");
            Console.WriteLine("2. Try to get home you go in to the water and try to swim home (you drown and die, game ends)");
            answerInput = Console.ReadLine();
            switch (answerInput)
            {
                case "1":
                    Console.WriteLine("Good choice!");
                    break;
                case "2":
                default:
                    Console.WriteLine("Dont think so!!");
                    break;
            }

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You decide to follow the boy and you see him talking to a man.. you approach with care.");
            Console.WriteLine("(Man's voice) Stop right there stranger..");
            Console.WriteLine($"(Boy) Father dont worry its {nameInput},i meet him on the beach he is a friend");
            Console.WriteLine("(Man's voice)Stand back son i will decide if he is to be trusted or not..");
            Console.WriteLine("From your clothes i can tell that you are along way from home stranger, where are you from?");
            do
            {
                Console.WriteLine("(Race Decison): \n1. From the Great Northen Kingdome (Dwarf) \n2. From the Darklands (Elf) \n3. From the Highlands (Highlander)   \n4. (more details over decision) ");
                answerInput = Console.ReadLine();
                switch (answerInput) // behöver dubbelkollas
                {
                    case "1":
                    case "2":
                    case "3":
                        raceAnswer = int.Parse(answerInput);
                        choiceMade = true;
                        break;
                    case "4":
                        RaceDefinition();
                        break;
                    default:
                        Console.WriteLine("There is no such choice..");
                        Console.WriteLine("Are you sure you are okey? Lets try this again");
                        Console.WriteLine("Press any key to try again...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (!choiceMade);

            CharacterClass character = new CharacterClass(nameInput, raceAnswer);

            if (raceAnswer == 1)
            {
                Console.WriteLine("(Man's voice) Yes should of known.. What are you doing here anyway? ");
                
            }
            else if (raceAnswer == 2)
            {
                Console.WriteLine("(Man's voice) Ofcourse your pointy ears is a give away.. I should of known.. What are you doing here anyway? ");
            }
            else if (raceAnswer == 3)
            {
                Console.WriteLine("(Man's voice) Oh im sorry.. you must be a Highlander we dont get so many from the great lands around here.. \nWhat are you doing here are you lost?");
            }
            do
            {
                choiceMade = false;
            
                Console.WriteLine("(Answer) \n1. I dont Remember.. \n2. Thats none of your business");
                answerInput = Console.ReadLine();
                Console.Clear();
                switch (answerInput)
                {
                    case "1":
                        Console.WriteLine("(Man) Something terrible must of happend to you.. \nYou should visit the city and ask for the healer maybe he can help you.");
                        Console.WriteLine("The man points you in the direction of the city..");
                        Console.WriteLine("You will need something for the road it can be dangerous.. ");
                        if (raceAnswer == 1)
                        {
                            Console.WriteLine("Gives you a Kids Sword");
                        }
                        else if (raceAnswer == 2)
                        {
                            Console.WriteLine("Give you a Kids Axe");
                        }
                        else if (raceAnswer == 3)
                        {
                            Console.WriteLine("Give you a Kids Mace");
                        }
                        choiceMade = true;
                        character.AddWeaponToInventory(new Weapon((int)raceAnswer, 1));
                        Console.WriteLine("(Answer) Thank you.. ");
                        break;
                    case "2":
                        Console.WriteLine("(Man) Oh im sorry, you are right we must be going now anyway.. \nThe man hurries up on his wagon and leaves with his son..");
                        choiceMade = true;
                        break;
                    default:
                        Console.WriteLine("hmm i dont understand you...");
                        break;
                }
            } while (!choiceMade);
                
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("You start walking towards the city..");
            player.Stop();

            FirstTimeInCity(character);
            return character;
        }

        static public void RaceDefinition()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("|      1. The Dwarf             |        2. The Elf             |      3. The Highlander          |");
            Console.WriteLine("|  ---------------------------  |  ---------------------------  |  -----------------------------  |");
            Console.WriteLine("| Stats                         | Stat:                         | Stat                            |");
            Console.WriteLine("| Main:      Strength (10p/lvl) | Main:      Dexterity (7p/lvl) | Main:      Intelligence (5p/lvl)|");
            Console.WriteLine("| Secondary: Dexterity (1p/lvl) | Secondary: Strength  (2p/lvl) | Secondary: Dexterity    (5p/lvl)|");
            Console.WriteLine("|                               |                               |                                 |");
            Console.WriteLine("| The Dwarf is a warrior, his   | The Elf makes a great hunter  | The Highlander is a Paladin     |");
            Console.WriteLine("| main stat beeing strength.    | beeing hard to hit and        | beeing both harder to hit and   |");
            Console.WriteLine("| He strikes down his enemies   | lightning fast with the sword.| alot more intelleigent than the |");
            Console.WriteLine("| with brute force.             |                               | Dwarf.                          |");
            Console.WriteLine("|                               |                               |                                 |");
            Console.WriteLine("| Drawback                      | Drawback                      | Drawback                        |");
            Console.WriteLine("| Needs 3points on both         | We know little of the elf race| Harder character to start with  |");
            Console.WriteLine("| intelligent & charisma,       |                               |                                 |");
            Console.WriteLine("| to increase 1 skillpoint.     |                               |                                 |");
            Console.WriteLine("|                               |                               |                                 |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("| Each Level you get extra points on the race main and secondary stat.                            |");
            Console.WriteLine("| Also you will get gets 3 skill points to distribute on stat of choice.                          |");
            Console.WriteLine("|                                                                                                 |");
            Console.WriteLine("| Mainstats explanation                                                                           |");
            Console.WriteLine("| Strength: For hitting with meele weapons                                                        |");
            Console.WriteLine("| Dexterity: Makes you very sneacky and hard to hit.                                              |");
            Console.WriteLine("| Intelligens: This is the main stat for the Highlander.                                          |");
            Console.WriteLine("|                                                                                                 |");
            Console.WriteLine("| Secondary                                                                                       |");
            Console.WriteLine("| Charisma: To get favour at the merchant, some might not want to talk to you if it is to low.    |");
            Console.WriteLine("| Intelligence: If to low some parts of the game might not be activated.                          |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.Write("Press anykey..");
            Console.ReadKey();
        }

        static public void FirstTimeInCity(CharacterClass character)
        {
            Console.WriteLine("Enter City (press any key)");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Infront you see a Tavern.. You enter..");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Environment.CurrentDirectory + @"\Taverna.wav";
            player.PlayLooping();
            Console.WriteLine("It is almost empty you look around .. and go to talk to a man at the bar.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("(Man asks) How may i help you..");
            Console.WriteLine($"({character.Name})I would like to find the local healer..");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("(Man) Starts laughing.. ");
            Console.WriteLine("(Man) There is no healer in this town, some call me the healer but the only thing i serve is licur.");
            Console.WriteLine("(Man) Listen here stranger.. How can i help you..?");
            Console.WriteLine("You reach down in your pants pocket and notice a letter...");
            Console.WriteLine("You look at the man and say nothing right now, thank you...");
            Console.ReadKey();
            Console.Clear();
            int howToProcced = ReadLetter(character); //Klippt ut en method som är längre ner
            if (howToProcced == 1)
            {
                switch (character.CharRace)
                {
                    case CharRace.Dwarf:
                        Console.WriteLine($"({character.Name}) Could you translate this for me? ");
                        Console.WriteLine("(Man) This you are gonna have to translate by yourself there is not much help around here for a Dwarf..");
                        Console.WriteLine("(Man) But if you want to survive in this place you will need a proper weapon.");
                        Console.WriteLine("(Man) If you have gold you can go either to the blacksmith or the vendor both can get you what you need if you have sufficient gold.");
                        Console.WriteLine("(Man) If you dont have any gold you can start by going to the wood to look for loot or fighting in the pits. \nFor the pits i would recommend you to get better gear first.");
                        Console.WriteLine("(Man) But if i was you i would just try to find the first boat out of this place.");
                        Console.WriteLine("(Man) Now leave!");
                        break;
                    case CharRace.Elf:
                        Console.WriteLine($"({character.Name}) Could you translate this for me? ");
                        Console.WriteLine("(Man) I might be able to help you with that.. Come back and see me at a later time.");
                        Console.WriteLine("(Man) But before you do anything i would recommend you to get your hands on some new equipment.");
                        Console.WriteLine("(Man) Right outside here there is a Blacksmith and a equiptment Vendor they will surely help you.");
                        Console.WriteLine("(Man) But if i was you i would just try to find the first boat out of this place.");
                        break;
                    case CharRace.Highlander:
                        Console.WriteLine($"({character.Name}) You know how i can get to the High Vulcanic Mountains?");
                        Console.WriteLine("(Man) Yes you will see them when you leave the tavern to the east from here.");
                        Console.WriteLine("(Man) But before you go anywhere near that place i would recommend you to buy new equipment.");
                        Console.WriteLine("(Man) Visit the Blacksmith or the local vendor they might have someting for you.");
                        Console.WriteLine("(Man) Anyway if you are asking for advice, i would recommend you to find the first boat out of this place.");
                        break;
                    default:
                        break;
                }
            }
            else if (howToProcced == 2)
            {
                Console.WriteLine($"({character.Name}) Could you help me to get out of from this island");
                Console.WriteLine("(Man) The only way from here is to buy a boat thats gonna cost about 10k gold, you will see it when you go from the tavern..");
                Console.WriteLine("Its next to the Blacksmith and Local Vendor..");
            }
            Console.ReadKey();
            Console.WriteLine("You decide to leave and get some freash air...");
            Console.ReadKey();
            Console.Clear();
            
            player.Stop();
        }

        static public int ReadLetter(CharacterClass mainCharacter)
        {
            int howToProcced = 0;
            bool checkAnswer= false;
            Console.WriteLine("You walk away to a corner table and take out the letter again and try to read it..");
            switch (mainCharacter.CharRace)
            {
                case CharRace.Dwarf:
                    Console.WriteLine("I dont understand this.. ");
                    Console.WriteLine("Need to find someone that can translate this.. Maybe it has something to do with why im here. (new quest added)"); // russian quest letter
                    mainCharacter.MainQuest = "Find someone to translate letter";
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case CharRace.Elf:
                    Console.WriteLine("I dont understand this.. ");
                    Console.WriteLine("Need to find someone that can translate this.. Maybe it has something to do with why im here. (new quest added)"); 
                    mainCharacter.MainQuest = "Find someone to translate letter"; // russian quest letter
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case CharRace.Highlander:
                    Console.WriteLine("Please i need help im beeing keept captive in the High Vulcanic Mountains please hurry \nKind Regards Princess Zelda");
                    Console.WriteLine("(new quest added)"); // English quest letter
                    mainCharacter.MainQuest = "Find the Princess";
                    Console.ReadKey();
                    Console.Clear();
                    break;
                default:
                    break;
            }
            do
            {
                Console.Clear();
                Console.WriteLine("How would you like to preceed?");
                Console.WriteLine("1. Ask the man at the bar for help.");
                Console.WriteLine("2. Ask the man how to get home...");
                checkAnswer = int.TryParse(Console.ReadLine(), out howToProcced);
            
            } while (!checkAnswer);
            return howToProcced;
        }
           
        static public void StoryMiddle(int partOfStory,CharacterClass character)
        {
            Console.WriteLine("You won the battle");
            switch (partOfStory)
            {
                case 1:
                    Console.WriteLine("You start looking around for the princess...");
                    Console.WriteLine("There is nothing here.. except..");
                    Console.WriteLine("Some footprints in the snow that leads higher up the mountains...");
                    break;
                case 2:
                    Console.WriteLine("What where is she.. ");
                    Console.WriteLine("You manage to find a shoe half burrid in the snow...");
                    Console.WriteLine("And relize that she must be in the top of the mountain...");
                    break;
                case 3:
                    Console.WriteLine("You defeted the Boss holding the princess capative.(new quest added)");
                    Console.WriteLine("Take the princess of the island (new quest added)");
                    character.MainQuest = "Take the princess of the island";
                    var p1 = new System.Windows.Media.MediaPlayer();
                    p1.Open(new System.Uri(Environment.CurrentDirectory + @"\WinLastBoss.wav"));
                    p1.Play();
                    break;
                default:
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }
       
        static public string Ending(CharacterClass character)
        {
            string stayOnIsland = "";
            string doesGameEnd;
            Console.WriteLine("Do you wish to leave the island? ");
            Console.WriteLine("1. Yes (cost 10k gold)");
            Console.WriteLine("2. no I wish to stay a bit longer");
            stayOnIsland = Console.ReadLine();
            switch (stayOnIsland)
            {
                case "1":
                    if (character.Gold >= 10000)
                    {
                        if (character.MainQuest == "Find someone to transle letter")
                        {
                            Console.WriteLine("You bought a boat and are on your way out of here..");
                            Console.WriteLine("On the boat you show the letter to one in the crew..");
                            Console.WriteLine("He reads it and sais wow you didnt look for the princess???");
                            Console.WriteLine("She is probably dead by now.. lets go home..");
                            Console.WriteLine("");
                            Console.WriteLine("Game over...");
                        }
                        if (character.MainQuest == "Find the Princess")
                        {
                            Console.WriteLine("You manage to escape the island but didnt try to find the princess..");
                            Console.WriteLine("Great job, you will probably be killed when you arrive home..");
                            Console.WriteLine("");
                            Console.WriteLine("Game over...");
                        }
                        if (character.MainQuest == "Take the princess of the island")
                        {
                            Console.WriteLine("Congratulations, you won the game!!!");
                            Console.WriteLine("You survived and saved the princess...");
                            Console.WriteLine("Game over...");
                            var p1 = new System.Windows.Media.MediaPlayer();
                            p1.Open(new System.Uri(Environment.CurrentDirectory + @"\WinGame.wav"));
                            p1.Play();
                        }
                        doesGameEnd = "0";
                    }
                    else
                    {
                        Console.WriteLine("Come back when you have enough, dont waste my time..");
                        doesGameEnd = "1";
                    }
                    break;
                case "2":
                    Console.WriteLine("Stop wasting my time..");
                    doesGameEnd = "1";
                    break;

                default:
                    Console.WriteLine("Come back when you have decided...");
                    doesGameEnd = "1";
                    break;
            }
            
            Console.ReadLine();
            Console.Clear();
            return doesGameEnd;
            //If he dosent have the princess and goes by boat then it should say something like you should of stayed and read the letter
            //now princess died,, good job.. 
        }
        
       
    }
}
