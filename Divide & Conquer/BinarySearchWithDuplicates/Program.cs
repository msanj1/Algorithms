using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearchWithDuplicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfCount1 = int.Parse(Console.ReadLine());
            var input1 = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

            var numberOfCount2 = int.Parse(Console.ReadLine());
            var input2 = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < input2.Count; i++)
            {
                var value = input2[i];
                var result = BinarySearch(input1, value);
                if (builder.Length > 0)
                    builder.Append(" ");
                builder.Append(result);
            }

            Console.WriteLine(builder.ToString());
        }

        static int BinarySearch(List<int> input, int value)
        {
            var left = 0;
            var right = input.Count - 1;
            var output = -1;

            while (left <= right)
            {
                var mid = (int)Math.Floor(left + ((right - left) / 2.0));
                var currentValue = input[mid];
                if (currentValue >= value)
                {
                    output = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            if (output != -1 && input[output] != value)
                return -1;

            return output;
        }
    }
}
