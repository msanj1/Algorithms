using System;
using System.Linq;

namespace MaxPairwiseSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfItems = int.Parse(Console.ReadLine());
            var items = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

            // 9 8 7 6 5 4 3 2 1
            int term1Index = -1;
            int term2Index = -1;

            var max = -1;

            for (int a = 0; a < numberOfItems; a++)
            {
                if (items[a] > max)
                {
                    max = items[a];
                    term1Index = a;
                }
            }

            max = -1;

            for (int b = 0; b < numberOfItems; b++)
            {
                if (b == term1Index)
                    continue;

                if (items[b] > max)
                {
                    max = items[b];
                    term2Index = b;
                }
            }

            Console.WriteLine(items[term1Index] * (long)items[term2Index]);
        }
    }
}
