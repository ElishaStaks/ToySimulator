using System;
using System.Collections.Generic;
using System.Text;

/*
 * Description: This Script handles the robots direction, position and initialises 
 *              the board within the simulation.
 * Author: Elisha
 * Date: 17/02/2020
 */

namespace ToySimulation
{
    public class Robot : IInputManager
    {
        #region Private Variables
        private Board m_board { get; set; }
        private string m_direction = string.Empty;

        private const string NORTH = "NORTH";
        private const string EAST = "EAST";
        private const string SOUTH = "SOUTH";
        private const string WEST = "WEST";

        private bool robotPlaced = false;
        #endregion

        #region Public Variables
        public int X = 0;
        public int Y = 0;
        public const string OUT_OF_BOUNDS = "Invalid input, out of the boards bounds.";
        public const string ROBOT_NOT_PLACED = "Must give the robot a position and direction first.";
        public const string UNRECOGNISED_INPUT = "Input unrecognised.";
        public const string COMMAND_PROMPT = "\nValid Commands: \nPLACE X, Y, F \nMOVE \nLEFT \nRIGHT \nREPORT";
        #endregion

        /// <summary>
        /// Default constuctor that sizes the board to 5x5 units
        /// </summary>
        public Robot()
        {
            m_board = new Board(5, 5);
        }

        /// <summary>
        /// Customisable board that takes in a x and y value to set the size of the board.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Robot(int x, int y)
        {
            m_board = new Board(x, y);
        }

        /// <summary>
        /// This method places the robot onto the board.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Place(int x, int y, string input)
        {
            string result = string.Empty;

            // Checks if the players x and y coord is within the boundaries of the board.
            if (!m_board.ValidBoardPosition(this))
            {
                result = OUT_OF_BOUNDS;
            }
            else
            {
                robotPlaced = true;
            }

            // returns the users final input.
            return result;
        }

        /// <summary>
        /// This method moves the robot one unit forward in the direction that they are facing.
        /// </summary>
        /// <returns></returns>
        public string Move()
        {
            string result = string.Empty;

            // store robots original positions
            var xOrig = X;
            var yOrig = Y;

            // Checks what direction the robot is facing
            switch (m_direction)
            {
                case NORTH:
                    Y += 1;
                    break;

                case EAST:
                    X += 1;
                    break;

                case WEST:
                    X -= 1;
                    break;

                case SOUTH:
                    Y -= 1;
                    break;
            }

            // Checks if the robot can move within the boundaries of the board
            if (!m_board.ValidBoardPosition(this))
            {
                // if input is out of bounds, set robots x and y coord back to their original positions.
                X = xOrig;
                Y = yOrig;
                // exception handling
                result = OUT_OF_BOUNDS;
            }

            return result;
        }

                /// <summary>
        /// This method takes in the users input and check if it contains a ceratin string.
        /// If it does then it enters the correct function that either places, moves 
        /// or reports the robot.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string UserCommand(string input)
        {
            string result = string.Empty;
            // Converts input to upper case
            string command = input.ToUpper();

            // handling of exceptions due to coding errors during program execution
            // Try block is where exceptons occur
            try
            {
                // Checks if the users input contains any of the key words
                if (command.Contains("PLACE"))
                {
                    //input = input.Substring(6);
                    // Split the input string so we can parse in the x and y
                    string[] inputs = input.Split(',', ' ');

                    // Converts number to represent a string value
                    // We then give the order of which index of the sub string
                    X = Int32.Parse(inputs[1]);
                    Y = Int32.Parse(inputs[2]);
                    m_direction = inputs[3];

                    result = Place(X, Y, input);
                }
                else if (!robotPlaced)
                {
                    result = ROBOT_NOT_PLACED;
                }
                else if (command.Contains("MOVE"))
                {
                    result = Move();
                }
                else if (command.Contains("LEFT"))
                {
                    Left();
                }
                else if (command.Contains("RIGHT"))
                {
                    Right();
                }
                else if (command.Contains("REPORT"))
                {
                    result = Report();
                }
                else
                {
                    result = UNRECOGNISED_INPUT + COMMAND_PROMPT; 
                }

            }
            // Catch block catches and handles errors within the try block.
            catch (Exception e)
            {
                // Prints out the current exception.
                result = e.Message;
            }

            return result;
        }

        /// <summary>
        /// This method turns the robot to the left.
        /// </summary>
        public void Left()
        {
            // Checks what direction the robot is currently in.
            switch (m_direction)
            {
                case NORTH:
                    m_direction = WEST;
                    break;

                case EAST:
                    m_direction = NORTH;
                    break;

                case SOUTH:
                    m_direction = EAST;
                    break;

                case WEST:
                    m_direction = SOUTH;
                    break;
            }
        }

        /// <summary>
        /// This method turns the robot to the right.
        /// </summary>
        public void Right()
        {
            // Checks what direction the robot is currently in.
            switch (m_direction)
            {
                case NORTH:
                    m_direction = EAST;
                    break;

                case EAST:
                    m_direction = SOUTH;
                    break;

                case SOUTH:
                    m_direction = WEST;
                    break;

                case WEST:
                    m_direction = NORTH;
                    break;
            }
        }

        /// <summary>
        /// This method prints out the current status of the robot within the simulation.
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            return "Output: " + X + "," + Y + "," + m_direction;
        }
    }
}
