using System;
using System.Collections.Generic;

namespace PrimeFactorLib
{
    public class PrimeCalculator
    {
        public static string PrimeFactors(int number)
        {
            if (number < 2)
                return "No prime factors";

            List<int> factors = new List<int>();
            int divisor = 2;

            while (number > 1)
            {
                while (number % divisor == 0)
                {
                    factors.Add(divisor);
                    number /= divisor;
                }
                divisor++;
            }

            return string.Join(" x ", factors);
        }
    }
}
