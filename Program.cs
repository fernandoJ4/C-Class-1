using System;
using PrimeFactorLib;

namespace PrimeFactorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new PrimeCalculator();

            Console.Write("Enter a number between 2 and 1000: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                try
                {
                    string result = calc.PrimeFactors(number);
                    Console.WriteLine($"Prime factors of {number}: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
