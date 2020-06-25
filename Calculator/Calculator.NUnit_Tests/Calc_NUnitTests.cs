using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.NUnit_Tests
{
    [TestFixture]
    public class Calc_NUnitTests
    {
        [Test]
        public void Calc_Sum_5_and_12_results_17()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(5, 12);

            //Assert
            Assert.AreEqual(17, result);
            Assert.That(result, Is.EqualTo(17));
        }

        [Test]
        [TestCase(int.MaxValue, 1)]
        [TestCase(int.MinValue, -1)]
        public void Calc_Sum_OverFlowException(int a, int b)
        {
            Calc calc = new Calc();
            Assert.Throws<OverflowException>(() => calc.Sum(a, b));

        }
    }
}
