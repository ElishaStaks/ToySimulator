using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToySimulation;

/*
 * Description: Runs tests based off the PDF Example Outputs
 */

namespace SimulationTest
{
    [TestClass]
    public class PDFTest
    {
        [TestMethod]
        public void Robot_Report_0_0_N()
        {
            Robot robot = new Robot(5, 5);

            //act
            string result = robot.UserCommand("PLACE 0,0,NORTH");
            result = robot.UserCommand("MOVE");
            result = robot.UserCommand("REPORT");
            //assert
            Assert.AreEqual("Output: 0,1,NORTH", result);
        }

        [TestMethod]
        public void Robot_Report_0_1_W()
        {
            Robot robot = new Robot(5, 5);

            //act
            string result = robot.UserCommand("PLACE 0,0,NORTH");
            result = robot.UserCommand("LEFT");
            result = robot.UserCommand("REPORT");
            //assert
            Assert.AreEqual("Output: 0,0,WEST", result);
        }

        [TestMethod]
        public void Robot_Report_3_3_N()
        {
            Robot robot = new Robot(5, 5);

            //act
            string result = robot.UserCommand("PLACE 1,2,EAST");
            result = robot.UserCommand("MOVE");
            result = robot.UserCommand("MOVE");
            result = robot.UserCommand("LEFT");
            result = robot.UserCommand("MOVE");
            result = robot.UserCommand("REPORT");
            //assert
            Assert.AreEqual("Output: 3,3,NORTH", result);
        }
    }
}
