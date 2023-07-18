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

        static bool Partition(List<int> inputs, int n, int partitionA, int partitionB, int partitionC)
        {
            if (memo.ContainsKey($"{partitionA}-{partitionB}-{partitionC}-{n}"))
            {
                return memo[$"{partitionA}-{partitionB}-{partitionC}-{n}"];
            }
            if (partitionA == 0 && partitionB == 0 && partitionC == 0)
                return true;

            if (n < 0)
                return false;

            var currentValue = inputs[n];
            var statusA = false;
            var statusB = statusA;
            var statusC = statusB;
            if (partitionA - currentValue >= 0)
            {
                partitionA = partitionA - currentValue;
                statusA = Partition(inputs, n - 1, partitionA, partitionB, partitionC);
            }

            if (partitionB - currentValue >= 0)
            {
                partitionB = partitionB - currentValue;
                statusB = Partition(inputs, n - 1, partitionA, partitionB, partitionC);
            }

            if (partitionC - currentValue >= 0)
            {
                partitionC = partitionC - currentValue;
                statusC = Partition(inputs, n - 1, partitionA, partitionB, partitionC);
            }

            memo[$"{partitionA}-{partitionB}-{partitionC}-{n}"] = statusA || statusB || statusC;

            return statusA || statusB || statusC;
        }

        private static Dictionary<string, bool> memo = new Dictionary<string, bool>();
    }
}
