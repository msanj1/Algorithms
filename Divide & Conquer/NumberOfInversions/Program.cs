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
            var inversionCount = MergeSort(input, 0, input.Count - 1);

            Console.WriteLine(inversionCount);
        }

        static int MergeSort(List<long> input, int left, int right, int investionCount = 0)
        {
            if (left >= right)
            {
                return investionCount;
            }

            var mid = left + (int)Math.Floor((right - left) / 2.0);

            investionCount = MergeSort(input, left, mid, investionCount);
            investionCount = MergeSort(input, mid+1, right, investionCount);
            return Merge(input, left, mid, right, investionCount);
        }

        static int Merge(List<long> input, int left, int mid, int right, int inversionCount)
        {
            var temp = new List<long>();
            int i = left;
            int j = mid + 1;

            for (int d = left; d <= mid; d++)
            {
                var closest = BinarySearch(input, input[d], j, right);
                if (closest != -1)
                {
                    inversionCount += 1 + (closest - j);
                }
            }

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

            return inversionCount;
        }

        static int BinarySearch(List<long> input, long value, int left, int right)
        {
            var output = -1;

            while (left <= right)
            {
                var mid = left + (int)Math.Floor((right - left) / 2.0);

                if (value > input[mid])
                {
                    output = mid;
                    left = mid + 1;
                }
                else
                {
                
                    right = mid - 1;
                }
            }

            return output;
        }
    }
}
