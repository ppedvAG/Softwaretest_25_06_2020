using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_3_and_4_results_7()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(3, 4);

            //Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Calc_Sum_0_and_0_results_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Calc_Sum_MAX_and_1__throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }

        [TestMethod]
        public void Calc_Sum_n6_and_9_results_3()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(-6, 9);

            //Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [DataRow(1, 4, 5)]
        [DataRow(-8, -5, -13)]
        [DataRow(10, -14, -4)]
        [DataRow(-4, 12, 8)]
        public void Calc_Sum(int x, int y, int expected)
        {
            var calc = new Calc();

            Assert.AreEqual(expected, calc.Sum(x, y));
        }

    }
}
