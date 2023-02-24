using System;
using System.Collections.Generic;

namespace FibonacciLastDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nthNumber = int.Parse(Console.ReadLine());

            var output = FibonacciLastDigit(nthNumber);

            Console.WriteLine(output);
        }

        static long FibonacciLastDigit(int nthNumber)
        {
            var fibList = FibonacciFirst60();
            return fibList[nthNumber % 60] % 10;
        }

        static List<long> FibonacciFirst60()
        {
            var output = new List<long>();
            output.Add(0);
            output.Add(1);

            for (int i = 2; i <= 59; i++)
            {
                output.Add(output[i - 2] + output[i - 1]);
            }

            return output;
        }
    }

}
