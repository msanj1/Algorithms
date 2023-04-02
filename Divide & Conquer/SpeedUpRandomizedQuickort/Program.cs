﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedUpRandomizedQuickort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfInput = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            QuickSort(input);

            Console.WriteLine(string.Join(' ',input));
        }

        static void QuickSort(List<int> input)
        {
            Sort(input, 0, input.Count - 1);
        }

        static void Sort(List<int> input, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            var m = PartitionRandomisedPivot(input, left, right);
            Sort(input, left, m - 1);
            Sort(input, m + 1, right);
        }

        static int PartitionStandard(List<int> input, int left, int right)
        {
            var pivot = left;

            int j = left;

            for(int i = left + 1; i <= right; i++)
            {
                var value = input[i];
                if(value <= input[pivot])
                {
                    j++;
                    Swap(input, i, j);
                }
            }

            Swap(input, pivot, j);

            return j;
        }

        static int PartitionRandomisedPivot(List<int> input, int left, int right)
        {
            var rand = new Random();
            var pivot = rand.Next(left, right);
            Swap(input, pivot, left);
            pivot = left;

            int j = left;

            for (int i = left + 1; i <= right; i++)
            {
                var value = input[i];
                if (value <= input[pivot])
                {
                    j++;
                    Swap(input, i, j);
                }
            }

            Swap(input, pivot, j);

            return j;
        }

        static void Swap(List<int> input, int from, int to)
        {
            var temp = input[from];
            input[from] = input[to];
            input[to] = temp;
        }
    }
}
