using System;
using System.Collections.Generic;
using System.Text;

namespace R365Calculator
{
    public class Calculator: ICalculator
    {
        // use dependency for other future implementations.
        public string Add(string numbersToProcess, string delimiter="") // make delimiter optional
        {
            // check if custom delimiter is present in numbers to process
            // if so, use delimiter "//;\n2;5"
            if(numbersToProcess.StartsWith("//"))
            {
                // parse out delimiter
                delimiter = numbersToProcess.Substring(2, 1);  //zero based
                numbersToProcess = numbersToProcess.Remove(0, 3);
            }

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
                    if (intResult >= 0 && intResult <= 1000)  // ignore over 1000
                        result += intResult;
                    else
                    {
                        if (intResult < 0)
                        {
                            if (negativeNumbers.Length >= 1)
                                negativeNumbers.Append("," + intResult.ToString());
                            else
                                negativeNumbers.Append(intResult.ToString());
                        }
                    }
                }
            }
            if (negativeNumbers.Length >= 1)
                throw new InvalidOperationException(negativeNumbers.ToString());
            else
                return result.ToString();

        }


    }
}
