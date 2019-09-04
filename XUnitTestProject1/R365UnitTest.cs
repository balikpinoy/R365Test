using R365Calculator;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class R365UnitTest
    {
        [Theory]
        [InlineData("1,2",",","3")]  // max 2 number
        [InlineData("5,ssd",",","5")] // invalid char = 0
        [InlineData("5,2,5,5,6", ",", "23")] // More that 2 Numbers
        [InlineData("5\n2,5,5,6", ",", "23")] // Line Break inside string
        [InlineData("5,-2,3,-4,2",",","-2,-4")]  // return string of negative numbers - assume to use same delimiter

        public void TestCalculatorAdd(string numbersToProcess, string delimeter, string expectedResult)
        {
            var testAdd = new Calculator();
            string result = testAdd.Add(numbersToProcess, delimeter);
            Assert.Equal(expectedResult, result);
        }
    }
}
