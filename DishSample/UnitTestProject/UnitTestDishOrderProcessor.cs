using DishSample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestDishOrderProcessor
    {
        [TestMethod]
        public void TestDishInputParser_ValidInputString_WithTimeOfTheDay_Morning()
        {
            string inputString = "morning,1,2,3";
            var dishInputParser = new DishInputParser(inputString);
            var validateResult = dishInputParser.Validate();
            dishInputParser.Process();

            var dishOrderProcessor = new DishOrderProcessor(dishInputParser);
            var output = dishOrderProcessor.ProcessDishOrder();
            Assert.AreEqual(output, "eggs,toast,coffee");
        }
    }
}
