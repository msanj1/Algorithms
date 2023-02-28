using System;
using System.Linq;

namespace GreatestCommonDivisor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToList();
            long a, b;

            a = input[0];
            b = input[1];

            if (input[0] > input[1])
            {
                a = input[1];
                b = input[0];
            }

            var result = CalculateGcd(a, b);
            Console.WriteLine(result);
        }

        static long CalculateGcd(long a, long b)
        {
            if (b == 0)
                return a;

            var remainder = a % b;

            return CalculateGcd(b, remainder);
        }
    }
}
