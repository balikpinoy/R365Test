﻿using System;
using System.Collections.Generic;
using System.Text;

namespace R365Calculator
{
    public class Calculator: ICalculator
    {
        // use dependency for other future implementations.
        public string Add(string numbersToProcess, string delimiter)
        {
            // replace line breaks with specified delimiter
            numbersToProcess = numbersToProcess.Replace("\n", delimiter);
            // initialize results
            Int32 result = 0;
            // initialize string to hold negative numbers
            StringBuilder negativeNumbers = new StringBuilder();
            
            String[] strNumerals = numbersToProcess.Split(delimiter);
            foreach(string digit in strNumerals)
            {
                // check for invalid number
                if (Int32.TryParse(digit, out Int32 intResult))
                {
                    if (intResult >= 0)
                        result += intResult;
                    else
                        if (negativeNumbers.Length >= 1)
                        negativeNumbers.Append("," + intResult.ToString());
                    else
                        negativeNumbers.Append(intResult.ToString());
                }
            }
            if (negativeNumbers.Length >= 1)
                return negativeNumbers.ToString();
            else
                return result.ToString();

        }


    }
}
