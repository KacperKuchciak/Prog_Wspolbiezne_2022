using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kalkulator_Testy
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMethodTest()
        {
            Kalkulator.Calculator calculator = new Kalkulator.Calculator();
            double x = calculator.Add(7, 4);
            Assert.AreEqual(x, 11);
        }

        [TestMethod]
        public void SubtractMethodTest()
        {
            Kalkulator.Calculator calculator = new Kalkulator.Calculator();
            double x = calculator.Subtract(7, 4);
            Assert.AreEqual(x, 3);
        }

        [TestMethod]
        public void MultiplyMethodTest()
        {
            Kalkulator.Calculator calculator = new Kalkulator.Calculator();
            double x = calculator.Multiply(7, 4);
            Assert.AreEqual(x, 28);
        }

        [TestMethod]
        public void DivideMethodTest()
        {
            Kalkulator.Calculator calculator = new Kalkulator.Calculator();
            double x = calculator.Divide(7, 4);
            Assert.AreEqual(x, 1.75);
        }

        [TestMethod]
        public void OperationCounterTest()
        {
            Kalkulator.Calculator calculator = new Kalkulator.Calculator();
            calculator.Divide(7, 4);
            calculator.Multiply(7, 4);
            calculator.Divide(7, 4);
            double x = calculator.Add(7, 4);
            Assert.AreEqual(calculator.GetCounter(), 4);
        }
    }
}