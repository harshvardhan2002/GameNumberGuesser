using GameAppLayered.Controller;
using GameAppLayered.Model;
using System;

namespace GameAppLayered.Presentation
{
    internal class GameMenu
    {
        static GameManager manager;

        public static void DisplayMenu()
        {
            manager = new GameManager();
            while (true)
            {
                DisplayWelcomeMessage();
                MakeChoice();
            }
        }

        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Number Guessing Game!\n");
            Console.WriteLine("Do you want to start a new game? (yes/no):");
        }

        public static void MakeChoice()
        {
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "yes":
                    PlayGame();
                    break;
                case "no":
                    DisplayReturnMessage();
                    break;
                default:
                    DisplayInvalidInputMessage();
                    break;
            }
        }

        private static void DisplayReturnMessage()
        {
            Console.WriteLine("Exiting!");
            Environment.Exit(0);
        }

        private static void DisplayInvalidInputMessage()
        {
            Console.WriteLine("Invalid input, try again!");
        }

        public static void PlayGame()
        {
            Console.WriteLine("Enter the minimum range:");
            int minRange = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the maximum range:");
            int maxRange = Convert.ToInt32(Console.ReadLine());

            manager.StartGame(minRange, maxRange);
            Console.WriteLine($"Guess a number between {minRange} and {maxRange}:");

            bool correctGuess = false;
            while (!correctGuess)
            {
                int userGuess = Convert.ToInt32(Console.ReadLine());
                correctGuess = manager.GuessNumber(userGuess);

                if (!correctGuess)
                {
                    Console.WriteLine("Do you want a hint? (yes/no):");
                    string continueChoice = Console.ReadLine().ToLower();
                    TakeHintOrNot(userGuess, minRange, maxRange, continueChoice);
                }
                else
                {
                    Console.WriteLine("Congrats! You have guessed the right number!");
                }
            }
        }

        public static void TakeHintOrNot(int userGuess, int minRange, int maxRange, string continueChoice)
        {
            switch (continueChoice)
            {
                case "yes":
                    string hint = manager.GetHint(userGuess);
                    Console.WriteLine(hint);
                    break;

                case "no":
                    Console.WriteLine($"Guess a number between {minRange} and {maxRange}:");
                    break;

                default:
                    Console.WriteLine("Invalid! Input either 'yes' or 'no'.");
                    break;
            }
        }
    }
}
