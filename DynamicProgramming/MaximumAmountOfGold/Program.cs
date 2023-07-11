using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAmountOfGold
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine().Split( );
            var input2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            var knapsackSize = int.Parse(input1[0]);
            var numberOfGolBars = int.Parse(input1[1]);

            Console.Write(CalculateMaximumWeight(input2, knapsackSize));
        }

        public static int CalculateMaximumWeight(List<int> barWeights, int knapsackSize)
        {
            var knapsacks = new int[knapsackSize + 1, barWeights.Count + 1]; // knapsack sizes, bars
            for (int i=0; i < knapsacks.GetLength(0); i++)
            {
                knapsacks[i, 0] = 0;
            }

            for (int i = 0; i < knapsacks.GetLength(1); i++)
            {
                knapsacks[0, i] = 0;
            }

            for(int i = 1; i < knapsacks.GetLength(0); i++)
            {
                for (int j = 1; j < knapsacks.GetLength(1); j++)
                {
                    var currentKnapsackSize = i;
                    var barWeight = barWeights[j - 1];
                    var sameKnapsackSizeLessLastBar = knapsacks[i, j - 1]; //size of knapsack content after we exclude the last bar
                    knapsacks[i, j] = sameKnapsackSizeLessLastBar;

                    if (barWeight <= currentKnapsackSize)
                    {
                        var knapsackSizeLessBarLessWeight = knapsacks[i - barWeight, j - 1] + barWeight; //size of knapsack content after we exclude the last bar and reduce the knapsack by the current bar weight
                        knapsacks[i, j] = Math.Max(knapsacks[i, j], knapsackSizeLessBarLessWeight);
                    }
                }
            }

            return knapsacks[knapsackSize, barWeights.Count];
        }
    }
}
