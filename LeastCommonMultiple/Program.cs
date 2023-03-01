using System;
using System.Linq;

namespace LeastCommonMultiple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToList();
            var result = CalculateLeastMultiple(input[0], input[1]);

            Console.WriteLine(result);
        }

        static long CalculateLeastMultiple(long a , long b) //https://www.mathsisfun.com/least-common-multiple.html
        {
            int aCounter = 1;
            int bCounter = 1;

            while (true)
            {
                var resultA = a * aCounter;
                var resultB = b * bCounter;

                if (resultA == resultB)
                    return resultA;
                if (resultA > resultB)
                    bCounter++;
                if (resultB > resultA)
                    aCounter++;
            }
        }
    }
}
