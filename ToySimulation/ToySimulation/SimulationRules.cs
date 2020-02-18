using System;
using System.Collections.Generic;
using System.Text;

/*
 * Description: This script Begins the simulation and outputs the rules to the console.
 * Author: Elisha
 * Date: 17/02/2020
 */

namespace ToySimulation
{
    static class SimulationRules
    {
        #region Private Variables
        const string m_simulationText = @"   PLACE X,Y F - places the robot on the board via x, y and direction via north, east, west, south.
   LEFT   – turns the toy to the left.
   RIGHT  – turns the toy to the right.
   MOVE   – Moves the toy 1 unit forward.
   REPORT – Shows the current position and direction of the robot. 
   EXIT   – Exits Simulator.";
        #endregion

        /// <summary>
        /// Begins the simulation and outputs the rules to the console.
        /// </summary>
        public static void StartSimulation()
        {
            Console.WriteLine("------------Welcome to the Toy Robot Simulation------------\n");

            Console.WriteLine("Control Commands: ");
            Console.WriteLine(m_simulationText);
        }
    }
}
