using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToySimulation;

/*
 * Description: Tests boundary scenarios such as placing the robot out of bounds 
 *              and moving it out of bounds.

 */

namespace SimulationTest
{
    [TestClass]
    public class BoundaryTest
    {
        [TestMethod]
        public void Robot_Report_Move_Out_Of_Bounds()
        {
            Robot robot = new Robot(5, 5);

            //act
            string result = robot.UserCommand("PLACE 4,4,NORTH");
            result = robot.UserCommand("MOVE");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDS, result);
        }

        [TestMethod]
        public void Robot_Report_Placed_Out_Of_Bound()
        {
            Robot robot = new Robot(5, 5);

            //act
            string result = robot.UserCommand("PLACE 10,10,NORTH");
            //assert
            Assert.AreEqual(Robot.OUT_OF_BOUNDS, result);
        }
    }
}