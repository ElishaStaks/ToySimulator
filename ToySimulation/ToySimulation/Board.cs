using System;
using System.Collections.Generic;
using System.Text;

/*
 * Description: This script Creates and handles the size of the board within the simulation. It also has a method that checks 
 *              if the position of the robot is within the bounds of the board.
 * Author: Elisha
 * Date: 17/02/2020
 */

namespace ToySimulation
{
    class Board
    {
        #region Public Variables
        public int m_width = 0;
        public int m_height = 0;
        #endregion

        /// <summary>
        /// Constructor which takes in the width and height of the board.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Board(int x, int y)
        {
            m_width = x;
            m_height = y;
        }

        /// <summary>
        /// This method checks if the robot is within the boundaries of the boards width and height. 
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool ValidBoardPosition(Robot position)
        {
            return position.X < m_width && position.X >= 0 &&
                position.Y < m_height && position.Y >= 0;
        }
    }
}
