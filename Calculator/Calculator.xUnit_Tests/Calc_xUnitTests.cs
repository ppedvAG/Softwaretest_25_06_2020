using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.xUnit_Tests
{
    public class Calc_xUnitTests
    {
        [Fact]
        public void Calc_Sum_5_and_12_results_17()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(5, 12);

            //Assert
            Assert.Equal(17, result);
        }

        [Theory]
        [InlineData(13, 5, 18)]
        [InlineData(1, 5, 6)]
        [InlineData(-5, 5, 0)]
        public void Calc_Sum(int a, int b, int c)
        {
            Calc calc = new Calc();
            Assert.Equal(c, calc.Sum(a, b));

        }
    }
}
