using R365Calculator;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class R365UnitTest
    {
        [Theory]
        [InlineData("1,2",3)]
        [InlineData("5,ssd",5)]

        public void TestCalculatorAdd(string input, Int32 expectedResult)
        {
            var testAdd = new Calculator();
            Int32 result = testAdd.Add(input);
            Assert.Equal(expectedResult, result);
        }
    }
}
