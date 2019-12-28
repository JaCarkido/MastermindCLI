using System;
using System.Collections.Generic;

namespace MastermindCLI
{
    class Menu
    {
        //Vars
        string[] menuOptions;
        int recursionCounter = 0;

        //CTOR
        public Menu(string[] menuOptions)
        {
            this.menuOptions = menuOptions;
        }

        //Methods
        public string getMenuChoice (string[] menuOption)
        {
            int userSelection;
            
            for (int i = 0; i < menuOption.Length; i++)
            {
                Console.WriteLine((i + 1) + ") " + menuOption[i]);
            }
            
            // exception handling makes sure the character entered can be parsed to an int
            try
            {
                userSelection = int.Parse(Console.ReadLine()) - 1;
                
                //checks to make sure userSelection is a valid int selection
                if (userSelection > menuOption.Length)
                {
                    retry();
                    Console.Write("\nPlease make a valid selection 1 - "+ menuOption.Length + "\n");
                    return getMenuChoice(menuOption);
                }

                return menuOption[userSelection];
            }
            catch (System.FormatException) 
            {
                retry();                
                Console.Write("\nPlease make a valid selection 1 - "+ menuOption.Length + "\n");
                return getMenuChoice(menuOption);
            }
        }

        //After the 3 attempts the program exits to prevent a recursive loop
        public void retry()
        {
            recursionCounter += 1;

            if(recursionCounter > 2)
            {
                Console.WriteLine("You seem to be stuck. Closing application for you.");
                Environment.Exit(1);
            } 
        }  
    }
}