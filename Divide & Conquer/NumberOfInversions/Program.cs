using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberOfInversions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfInput = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToList();
            MergeSort(input, 0, input.Count - 1);

            Console.WriteLine(string.Join(" ", input));
        }

        static void MergeSort(List<long> input, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            var mid = left + (int)Math.Floor((right - left) / 2.0);

            MergeSort(input, left, mid);
            MergeSort(input, mid+1, right);
            Merge(input, left, mid, right);
        }

        static void Merge(List<long> input, int left, int mid, int right)
        {
            var temp = new List<long>();
            int i = left;
            int j = mid + 1;

            while (i <= mid && j <= right)
            {
                if(input[i] <= input[j])
                {
                    temp.Add(input[i]);
                    i++;
                }else
                {
                    temp.Add(input[j]);
                    j++;
                }
            }

            while (i <= mid)
            {
                temp.Add(input[i]);
                i++;
            }

            while (j <= right)
            {
                temp.Add(input[j]);
                j++;
            }

            for(int c=0; c< temp.Count; c++)
            {
                input[left] = temp[c];
                left++;
            }
        }
    }
}
