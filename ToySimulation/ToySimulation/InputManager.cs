using System;
using System.Collections.Generic;
using System.Text;

/*
 * Description: This script declares the inputs of the user.
 * Author: Elisha
 * Date: 17/02/2020
 */

namespace ToySimulation
{
    interface IInputManager
    {
        /// <summary>
        /// This method places the robot onto the board.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string Place(int x, int y, string input);

        /// <summary>
        /// This method moves the robot one unit forward in the direction that they are facing.
        /// </summary>
        /// <returns></returns>
        string Move();

        /// <summary>
        /// This method turns the robot to the left.
        /// </summary>
        void Left();

        /// <summary>
        /// This method turns the robot to the right.
        /// </summary>
        void Right();

        /// <summary>
        /// This method prints out the current status of the robot within the simulation.
        /// </summary>
        /// <returns></returns>
        string Report();

        /// <summary>
        /// This method takes in the users input and check if it contains a ceratin string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string UserCommand(string input);
    }
}
