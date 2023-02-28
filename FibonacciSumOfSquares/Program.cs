using System;
using System.Collections.Generic;
using System.Linq;

namespace FibonacciSumOfSquares
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = long.Parse(Console.ReadLine());
            var pisanoPeriod = CalculatePisanoPeriod(input, 10);
            long output = -1;

            if(pisanoPeriod > 0)
            {
                var list = FibonacciSquared(input % pisanoPeriod, 10);
                output = list.Sum() % 10;
            }
            else
            {
                var list = FibonacciSquared(input, 10);
                output = list.Sum() % 10;
            }

            Console.WriteLine(output);
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

        static List<long> FibonacciSquared(long to)
        {
            var twoBefore = 0;
            var before = 1;

            var output = new List<long>();

            if (to >= 0)
            {
                output.Add(0);
            }
            if (to >= 1)
            {
                output.Add(1);
            }

            for (int i = 2; i <= to; i++)
            {
                var current = ((twoBefore) + (before));
                output.Add(current * current);

                twoBefore = before;
                before = current;
            }

            return output;
        }

        static List<long> FibonacciSquared(long to, long m)
        {
            long twoBefore = 0;
            long before = 1;

            var output = new List<long>();

            if (to >= 0)
            {
                output.Add(0);
            }
            if (to >= 1)
            {
                output.Add(1);
            }

            for (int i = 2; i <= to; i++)
            {
                var current = ((twoBefore) + (before)) % m;

                output.Add((current * current) % m);

                twoBefore = before;
                before = current;
            }

            return output;
        }
    }
}
