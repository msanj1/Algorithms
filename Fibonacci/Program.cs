using System;
using System.Collections.Generic;

namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nthNumber = int.Parse(Console.ReadLine());

            var fibList = FibonacciList(nthNumber);

            Console.WriteLine(Fibonacci(nthNumber, fibList));
        }

        static long Fibonacci(int nthNumber, List<long> fibonacciList)
        {
            if (nthNumber <= 1)
                return nthNumber;

            return fibonacciList[nthNumber];
        }

        static List<long> FibonacciList(int nthNumber)
        {
            var output = new List<long>();
            output.Add(0);
            output.Add(1);

            for(int i = 2; i <= nthNumber; i++)
            {
                output.Add(output[i - 2] + output[i - 1]);
            }

            return output;
        }
    }
}
