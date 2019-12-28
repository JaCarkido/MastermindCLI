using System;
using System.Collections.Generic;

namespace MastermindCLI
{
    class Mastermind
    {
        //Vars
        int recursionCounter = 0;

        //Methods
        public void getRandomNums(List<int> mastermindNums)
        {
            // this clears the list for a new game
            mastermindNums.Clear();
            for (int i = 0; i < 4; i++) 
            {
                int randomNum;
                Random rnd = new Random();
                randomNum = rnd.Next(1,6);
                mastermindNums.Add(randomNum); 
            }
        }

        public List<string> checkInput (List<int> userGuess, List<int> mastermindNums)
        {
            List<string> userResults = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                if (mastermindNums.Contains(userGuess[i]))
                {
                    if (mastermindNums[i] == userGuess[i])
                    {
                        userResults.Add("+");
                    } else {
                    userResults.Add("-");
                    }
                } else {
                    userResults.Add(" ");
                }
                Console.Write(userResults[i]);
            }
            return userResults;
        }

        public void dispalyExit()
        {
            Console.WriteLine("\nThanks for playing! ...Goodbye");
        }
        public void displayInstructions()
        {
            Console.WriteLine("-------------");
            Console.WriteLine("Instructions:");
            Console.WriteLine("-------------");
            Console.WriteLine("Can you guess the four digit code? You have 10 chances to unlock the combination. Enter four digits. Each digit must be a whole number between 1 and 6."
            + "\n ----------------------------------------------------------------"
            + "\n|- will be displayed for a correct guess in the wrong position   |"
            + "\n|+ will be displayed for a correct guess in the correct position | "
            + "\n|  nothing will be displayhed for incorrect guesses.             |"
            + "\n ----------------------------------------------------------------\n"
            + "\nGood Luck!\n-----------");
        }
        
        public void displayLoser()
        {
            Console.WriteLine("\n -------------------------------------\n| Sorry you LOSE, please try again :( |\n -------------------------------------");
        }

        public void displayWelcome()
        {
            Console.WriteLine(" ------------------------------------------------\n| Welcome to Mastermind! Please make a selection |\n ------------------------------------------------");
        }

        public void displayWinner()
        {
            Console.WriteLine("\n ----------------------------\n| Congratulations you WIN!!! |\n ----------------------------");    
        }

        public bool isWinner (List<string> userResults)
        {
            if (userResults.Count < 4)
            {
                return false;
            }

            for (int i = 0; i < 4; i++)
            {
                if (!userResults[i].Contains("+"))
                {
                    return false;
                }
            }
            return true;
        }

        public List<int> guess()
        {
            List<int> userGuess = new List<int>();
            string userInput;

            Console.Write(System.Environment.NewLine);  // allows guess to be typed under results
            userInput = Console.ReadLine();
            
            if (userInput.ToLower().Contains("x"))
            {
                Console.WriteLine("\nClosing application, thanks for playing!");
                Environment.Exit(1);
            }

            // Checks to make sure the user enters enough digits.  
            if (userInput.Length != 4){
                retry();
                return guess();
            }

            for (int i = 0; i < userInput.Length; i++)
            {
                // exception handling for non-integers entered by the user.  Allows the user to reguess or exit via recursion
                //The user has three attempts before the applicaiton is automatically exited (this is to avoid an infinate loop via recurison)
                try 
                {
                    userGuess.Add(int.Parse(userInput[i].ToString()));
                    if (userGuess[i] < 1 || userGuess[i] > 6)
                    {
                        retry();
                        return guess();
                    }
                }
                catch (System.FormatException) 
                {
                    retry();
                    return guess();
                }
            }

            return userGuess;
        } 

        // Allows the user to reguess or exit. After the 3 attempts the program exits to prevent a recursive loop
        public void retry()
        {
            recursionCounter += 1;
            if(recursionCounter > 2)
            {
                Console.WriteLine("You seem to be stuck. Closing application for you.");
                Environment.Exit(1);
            } 
            Console.Write("\nTry again! This time please be sure to enter four(4) numbers, or X to exit the application: ");
        }   

    }
}