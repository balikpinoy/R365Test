using R365Calculator;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class R365UnitTest
    {
        [Theory]
        [InlineData("1,2", ",", "3")]  // max 2 number
        [InlineData("5,ssd", ",", "5")] // invalid char = 0
        [InlineData("5,2,5,5,6", ",", "23")] // More that 2 Numbers
        [InlineData("5\n2,5,5,6", ",", "23")] // Line Break inside string
        [InlineData("5\n2,1002,5,6", ",", "18")] // Ignore > 1000

        public void TestCalculatorAdd(string numbersToProcess, string delimiter, string expectedResult)
        {
            var testAdd = new Calculator();
            string result = testAdd.Add(numbersToProcess, delimiter);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("5,-2,3,-4,2", ",", "-2,-4")]  // return string of negative numbers - assume to use same delimiter

        public void TestCalculatorAddException(string numbersToProcess, string delimiter, string expectedResult)
        {
            var testAdd = new Calculator();
            // string result = testAdd.Add(numbersToProcess, delimiter);
            var result = Assert.Throws<InvalidOperationException>(() => testAdd.Add(numbersToProcess, delimiter));
            //      Assert.Equal("Cannot read temperature before initializing.", ex.Message);
            Assert.Equal(expectedResult, result.Message.ToString());

        }
    }
}
