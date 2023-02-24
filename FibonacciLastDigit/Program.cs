using System;
using System.Collections.Generic;
using System.Numerics;

namespace FibonacciLastDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nthNumber = int.Parse(Console.ReadLine());

            var output = Fibonacci(nthNumber);

            Console.WriteLine(output % 10);
        }

        static BigInteger Fibonacci(int nthNumber)
        {
            var fibList = FibonacciList(nthNumber);

            return fibList[nthNumber];
        }

        static List<BigInteger> FibonacciList(int nthNumber)
        {
            var output = new List<BigInteger>();
            output.Add(0);
            output.Add(1);

            for (int i = 2; i <= nthNumber; i++)
            {
                output.Add(output[i - 2] + output[i - 1]);
            }

            return output;
        }
    }

}
