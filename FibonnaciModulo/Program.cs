using System;
using System.Collections.Generic;
using System.Linq;

namespace FibonnaciModulo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToList();
            var pisanoPeriod = CalculatePisanoPeriod(input[0], (int)input[1]); //Pisano periods https://www.geeksforgeeks.org/fibonacci-number-modulo-m-and-pisano-period/

            long nthNumberClass = input[0];
            List<long> numbers = new List<long>();
            if (pisanoPeriod != 0)
            {
                nthNumberClass = nthNumberClass % pisanoPeriod;
                numbers = FibonacciList(nthNumberClass, input[1]);
            }
            else
            {
                numbers = FibonacciList(nthNumberClass, input[1]);
            }

            Console.WriteLine(numbers[(int)nthNumberClass]);
        }

        static List<long> FibonacciList(long nthNumber, long mod)
        {
            var output = new List<long>();
            output.Add(0);
            output.Add(1);

            for (int i = 2; i <= nthNumber; i++)
            {
                var result = (output[i - 2]) + (output[i - 1]);
                output.Add(result % mod);
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
