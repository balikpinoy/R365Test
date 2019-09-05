using R365Calculator;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class R365UnitTest
    {
        [Theory]
        [InlineData("2",",","2")]  // max 2 number
        [InlineData("1,2",",", "3")]  // max 2 number
        [InlineData("5,ssd", ",", "5")] // invalid char = 0
        [InlineData("5,2,5,5,6", ",", "23")] // More that 2 Numbers
        [InlineData("1\n2,3", ",", "6")] // Line Break inside string
        [InlineData("5\n2,1002,5,6", ",", "18")] // Ignore > 1000
        [InlineData("//;\n2;5",",","7")] // custom 1 character delimiter signified by //
        [InlineData("//[***]\n11***22***33",",","66")] //custom multiple character delimiter
        [InlineData("//[*][!!][rrr]\n11rrr22*33!!44",",","110")]

        public void TestCalculatorAdd(string numbersToProcess, string delimiter, string expectedResult)
        {
            var testAdd = new Calculator();
            string result = testAdd.ProcessStringToAdd(numbersToProcess, delimiter);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("5,-2,3,-4,2", ",", "-2,-4")]  // return string of negative numbers - assume to use same delimiter

        public void TestCalculatorAddException(string numbersToProcess, string delimiter, string expectedResult)
        {
            var testAdd = new Calculator();
            // string result = testAdd.Add(numbersToProcess, delimiter);
            var result = Assert.Throws<InvalidOperationException>(() => testAdd.ProcessStringToAdd(numbersToProcess, delimiter));
            //      Assert.Equal("Cannot read temperature before initializing.", ex.Message);
            Assert.Equal(expectedResult, result.Message.ToString());

        }
    }
}
