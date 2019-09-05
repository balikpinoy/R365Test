using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace R365Calculator
{
    public class Calculator: ICalculator
    {
       
        public string ProcessStringToAdd(string numbersToProcess, string defaultDelimiter = ",") // make delimiter optional
        {

            //  check for custom delimiters
            if (numbersToProcess.StartsWith(@"//"))
            {
                if (numbersToProcess.Contains(@"["))
                {
                    // // get the numbers string transformed to just using one delimiter
                    numbersToProcess = NormalizeNumberString(numbersToProcess, defaultDelimiter);
                }
                else
                {
                    // parse out delimiter
                    defaultDelimiter = numbersToProcess.Substring(2, 1);  //zero based
                    numbersToProcess = numbersToProcess.Remove(0, 3);
                }
            }
            
            return Add(numbersToProcess, defaultDelimiter);
        }

        private string Add(string numbersToProcess,string delimiter)
        {
            // replace line breaks with specified delimiter
            numbersToProcess = numbersToProcess.Replace("\n", delimiter);
            // replace literals as well
            numbersToProcess = numbersToProcess.Replace(@"\n", delimiter);

            // initialize results
            Int32 result = 0;
            // initialize string to hold negative numbers
            StringBuilder negativeNumbers = new StringBuilder();

            String[] strNumerals = numbersToProcess.Split(delimiter);
            foreach (string digit in strNumerals)
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
                                negativeNumbers.Append(@"," + intResult.ToString());
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

  
        // replaces any custom delimiter with a default delimiter such as a comma
        private string NormalizeNumberString(string numbersToProcess, string defaultDelimiter)
        {
            string output = "";
            Regex regex = new Regex(@"\[.*?\]");
            MatchCollection matches = regex.Matches(numbersToProcess);
            output = numbersToProcess.Substring(numbersToProcess.IndexOf(@"]") + 1);

            foreach (Match m in matches) //loop thru delimiters
            {
                // get delimiter
                string stringToFind = m.Value.Replace(@"[","").Replace(@"]","");

                // replace the custom delimiter with just a comma
                output = output.Replace(stringToFind, defaultDelimiter);

            }

            return output;
        }

    }
}
