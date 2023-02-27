using System;
using System.Collections.Generic;
using System.Linq;

namespace FibonaciPartialSumLastDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToList();
            var pisanoPeriod = CalculatePisanoPeriod(input[1], 10);
            List<long> fibList = new List<long>();

            if (pisanoPeriod == 0)
            {
                fibList = FibonacciList(input[0], input[1], 10);
            }
            else
            {
                var from = input[0] % pisanoPeriod;
                var to = input[1] % pisanoPeriod;

                if (to < from)
                {
                    to = to + pisanoPeriod; //https://www.geeksforgeeks.org/last-digit-of-sum-of-numbers-in-the-given-range-in-the-fibonacci-series/
                }
                fibList = FibonacciList(from, to, 10);
            }

            Console.WriteLine(fibList.Sum() % 10);
        }

        static List<long> FibonacciList(long from, long to, int mod)
        {
            var output = new List<long>();
            if(from <= 1)
            {
                output.Add(0);
            }
            if(from <= 1 && to >= 1)
            {
                output.Add(1);
            }

            var twoBefore = 0;
            var previous = 1;

            for (int i = 2; i <= to; i++)
            {
                var current = ((twoBefore) + (previous)) % mod;
                if(i >= from)
                {
                    output.Add(current);
                }

                twoBefore = previous;
                previous = current;
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
