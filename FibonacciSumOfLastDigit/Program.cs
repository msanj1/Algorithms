using System;
using System.Collections.Generic;
using System.Linq;

namespace FibonacciSumOfLastDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nthNumber = long.Parse(Console.ReadLine());
            var pisanoPeriod = CalculatePisanoPeriod(nthNumber, 10);
            List<long> fibList = new List<long>();

            if(pisanoPeriod == 0)
            {
                fibList = FibonacciList(nthNumber, 10);
            }
            else
            {
                fibList = FibonacciList(nthNumber % pisanoPeriod, 10);
            }

            Console.WriteLine(fibList.Sum() % 10);
        }

        static long Fibonacci(int nthNumber, List<long> fibonacciList)
        {
            if (nthNumber <= 1)
                return nthNumber;

            return fibonacciList[nthNumber];
        }

        static List<long> FibonacciList(long nthNumber, int mod)
        {
            var output = new List<long>();
            if(nthNumber >= 0)
                output.Add(0);
            if (nthNumber >= 1)
                output.Add(1);

            for (int i = 2; i <= nthNumber; i++)
            {
                output.Add((output[i - 2] + output[i - 1]) % mod);
            }

            return output;
        }

        static int CalculatePisanoPeriod(long nthNumber, int mod)
        {
            int pisanoPeriod = 0;

            var twoBefore = 0;
            var previous = 1;

            for (int i = 2; i <= nthNumber; i++)
            {
                var current = ((twoBefore) + (previous)) % mod;
                if (current == 1 && previous == 0)
                {
                    pisanoPeriod = i - 1;
                    return pisanoPeriod;
                }

                twoBefore = previous;
                previous = current;
            }

            return pisanoPeriod;

        }
    }
}
