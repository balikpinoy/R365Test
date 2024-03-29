﻿using System;
using System.Collections.Generic;
using System.Text;

namespace R365Calculator
{
    /// <summary>
    ///  interface for calculator where we can add operations for now and for future needs
    ///  Initial requirement is for an Add component
    /// </summary>
    public interface ICalculator
    {
        string ProcessStringToAdd(string numbersToProcess, string delimiter);
    }
}
