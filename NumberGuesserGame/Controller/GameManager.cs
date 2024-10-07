using System;
using GameAppLayered.Model;

namespace GameAppLayered.Controller
{
    internal class GameManager
    {
        Game game;

        public void StartGame(int minRange, int maxRange)
        {
            game = new Game(minRange, maxRange);
        }

        public bool GuessNumber(int userGuess)
        {
            return userGuess == game.NumberToGuess;
        }

        public string GetHint(int userGuess)
        {
            if (userGuess < game.NumberToGuess)
            {
                return "the number is too low, try again!";
            }
            else if (userGuess > game.NumberToGuess)
            {
                return "the number is too high, try again";
            }
            else
            {
                return "Congrats! u have guessed the right number!";
            }
        }

        public int NumberToGuess()
        {
            return game.NumberToGuess;
        }
    }
}
