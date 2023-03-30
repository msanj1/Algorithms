using System;
using System.Linq;

namespace MajorityElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfInputs = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

            var inputOrdered = input.OrderBy(x => x).ToList();

            int repeatCount = (int)Math.Floor(numberOfInputs / 2.0);
            int count = 0;
            int previousValue = -1;
            var result = 0;
            for (int i=0; i< inputOrdered.Count; i++)
            {
                if(previousValue != inputOrdered[i])
                {
                    count = 1;
                }
                else
                {
                    count++;
                }

                if(count > repeatCount)
                {
                    result = 1;
                    break;
                }

                previousValue = inputOrdered[i];
            }

            Console.WriteLine(result);
        }
    }
}
