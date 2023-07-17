using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreePartition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfInputs = int.Parse(Console.ReadLine());
            var inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Console.WriteLine(Partition(inputs) ? 1 : 0);
        }

        static bool Partition(List<int> inputs)
        {
            var sum = inputs.Sum();
            if(inputs.Count < 3 || sum % 3 != 0)
                return false;

            return Partition(inputs, inputs.Count - 1, sum / 3, sum / 3, sum / 3);
        }

        private static Dictionary<string, bool> memo = new Dictionary<string, bool>();
        public static bool Partition(List<int> inputs, int currentCount, int partitionA, int partitionB, int partitionC)
        {
            // return true if the subset is found
            if (memo.ContainsKey($"{partitionA}-{partitionB}-{partitionC}-{currentCount}"))
            {
                return memo[$"{partitionA}-{partitionB}-{partitionC}-{currentCount}"];
            }

            if (partitionA == 0 && partitionB == 0 && partitionC == 0)
            {
                return true;
            }

            // base case: no items left
            if (currentCount < 0)
            {
                return false;
            }

            // Case 1. The current item becomes part of the first subset
            var A = false;
            if (partitionA - inputs[currentCount] >= 0)
            {
                A = Partition(inputs, currentCount - 1, partitionA - inputs[currentCount], partitionB, partitionC);
            }

            // Case 2. The current item becomes part of the second subset
            var B = false;
            if (!A && (partitionB - inputs[currentCount] >= 0))
            {
                B = Partition(inputs, currentCount - 1, partitionA, partitionB - inputs[currentCount], partitionC);
            }

            // Case 3. The current item becomes part of the third subset
            var C = false;
            if ((!A && !B) && (partitionC - inputs[currentCount] >= 0))
            {
                C = Partition(inputs, currentCount - 1, partitionA, partitionB, partitionC - inputs[currentCount]);
            }

            // return true if we get a solution
            memo[$"{partitionA}-{partitionB}-{partitionC}-{currentCount}"] = A || B || C;
            return A || B || C;
        }
    }
}
