using System;
using System.Collections.Generic;
using System.Text;

namespace R365Calculator
{
    public class Calculator: ICalculator
    {
        // use dependency for other future implementations.
        public Int32 Add(string input1)
        {
            // initialize result
            Int32 result = 0;
            // split as comma delimited
            string delimiter = ",";
            String[] strNumerals = input1.Split(delimiter);
            foreach(string digit in strNumerals)
            {
                // check for invalid number
                if (Int32.TryParse(digit, out Int32 intResult))
                  result += intResult;
            }
            return result;

        }


    }
}
