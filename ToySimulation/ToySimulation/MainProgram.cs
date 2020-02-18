using System;

/*
 * Description: This is the main program that initialises the programs objects.
 * Author: Elisha
 * Date: 17/02/2020
 */

namespace ToySimulation
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            #region Object Initialisation
            Robot robot = new Robot(5, 5);
            #endregion

            #region Variable Initialisation 
            string m_userInput = string.Empty;
            #endregion

            // static class that outputs rules to the console.
            SimulationRules.StartSimulation();

            do
            {
                Console.WriteLine("\nInput: ");
                m_userInput = Console.ReadLine();

                // Checks if the user inputs the word EXIT 
                if (m_userInput.ToUpper().Contains("EXIT"))
                {
                    // Will exit the loop and stop the program.
                    break;
                }

                Console.WriteLine(robot.UserCommand(m_userInput.ToUpper()));


            } while (true); // exit controlled loop
        }
    }
}
