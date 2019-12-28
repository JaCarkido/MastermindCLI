using System;
using System.Collections.Generic;

namespace MastermindCLI
{
    class Program
    {
    private const string MenuOptionPlay = "Play";
    private const string MenuOptionInstructions = "Instructions";
    private const string MenuOptionExit = "Exit";
    public static string[] menuOptions = {MenuOptionPlay, MenuOptionInstructions, MenuOptionExit};
 
        static void Main(string[] args)
        {
            Mastermind mastermindGame = new Mastermind();
            Menu mastermindMenu = new Menu(menuOptions);
            List<int> mastermindNums = new List<int>();
            List<int> userGuess = new List<int>();
            List<string> userResults = new List<string>();
            int guessCounter = 0;
            string choice;

            mastermindGame.displayWelcome();

            while (true)
            {
                choice = mastermindMenu.getMenuChoice(menuOptions);
                if (choice.Equals(MenuOptionPlay))
                {
                    mastermindGame.getRandomNums(mastermindNums);
                    Console.Write(System.Environment.NewLine);   
                    Console.Write("Please enter your guess: "); 

                    while (!mastermindGame.isWinner(userResults) && guessCounter < 10)
                    {         
                    userGuess = mastermindGame.guess();
                    userResults = mastermindGame.checkInput(userGuess, mastermindNums);
                    guessCounter += 1;
                    Console.Write(" guess #: " + guessCounter);
                    }

                    if (mastermindGame.isWinner(userResults) == true)
                    {
                        //This should be refactored into a resetGame() method within the Mastermind Class
                        userResults.Clear();
                        mastermindNums.Clear();
                        userGuess.Clear();
                        guessCounter = 0;

                        mastermindGame.displayWinner();
                    } else {
                        userResults.Clear();
                        mastermindNums.Clear();
                        userGuess.Clear();
                        guessCounter = 0;

                        mastermindGame.displayLoser();
                     }

                } else if (choice.Equals(MenuOptionInstructions))
                {
                    mastermindGame.displayInstructions();       
                } else if (choice.Equals(MenuOptionExit))
                {
                    mastermindGame.dispalyExit();
                    Environment.Exit(1);
                }
            }
        }
    }
}