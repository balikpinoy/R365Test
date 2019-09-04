using R365Calculator;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class R365UnitTest
    {
        [Theory]
        [InlineData("1,2",",",3)]  // max 2 number
        [InlineData("5,ssd",",",5)] // invalid char = 0
        [InlineData("5,2,5,5,6", ",", 23)] // More that 2 Numbers

        public void TestCalculatorAdd(string numbersToProcess, string delimeter, Int32 expectedResult)
        {
            var testAdd = new Calculator();
            Int32 result = testAdd.Add(numbersToProcess, delimeter);
            Assert.Equal(expectedResult, result);
        }
    }
}
