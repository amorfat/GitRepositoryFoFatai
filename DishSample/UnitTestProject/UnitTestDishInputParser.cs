using System;
using DishSample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestDishInputParser
    {
        [TestMethod]
        public void TestDishInputParser_ValidInputString_WithTimeOfTheDay_Morning()
        {
            string inputString = "morning,1,2,3";
            var dishInputParser = new DishInputParser(inputString);
            var validateResult = dishInputParser.Validate();
            Assert.IsTrue(validateResult);

            dishInputParser.Process();
            Assert.IsTrue(dishInputParser.OrderNumbers.Count == 3);
        }

        [TestMethod]
        public void TestDishInputParser_ValidInputString_WithTimeOfTheDay_Night()
        {
            string inputString = "night,1,2,3";
            var dishInputParser = new DishInputParser(inputString);
            var validateResult = dishInputParser.Validate();
            Assert.IsTrue(validateResult);

            dishInputParser.Process();
            Assert.IsTrue(dishInputParser.OrderNumbers.Count == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(DishException))]
        public void TestDishInputParser_Invalid_TimeOfTheDay()
        {
            string inputString = "errrrr,1,2,3";
            var dishInputParser = new DishInputParser(inputString);
            var validateResult = dishInputParser.Validate();
            Assert.IsTrue(validateResult);

            dishInputParser.Process();
            Assert.IsTrue(dishInputParser.OrderNumbers.Count == 3);
        }
    }
}
