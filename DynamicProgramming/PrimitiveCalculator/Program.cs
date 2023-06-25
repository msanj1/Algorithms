using System;
using System.Collections.Generic;

namespace PrimitiveCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var t = PrimitiveCalculatorPreCalculate(input);
            Console.WriteLine(t[t.Length - 1].Operation);
            Console.WriteLine(String.Join(" ",t[t.Length - 1].Values));
        }

        static Node[] PrimitiveCalculatorPreCalculate(int currentValue)
        {
            var operations = new Node[Math.Max(currentValue + 1, 2) ];
            operations[1] = new Node() { Operation = 0, Values = new List<int>() { 1 } };

            for (int i = 2; i <= currentValue; i++)
            {
                int minimumOperations = int.MaxValue;
                var candidateValues = new List<int>();
                if (i % 3 == 0)
                {
                    var existingOperation = operations[i / 3];
                    if (existingOperation.Operation < minimumOperations)
                    {
                        minimumOperations = existingOperation.Operation;
                        candidateValues = existingOperation.Values;
                    }
                }
                if (i % 2 == 0)
                {
                    var existingOperation = operations[i / 2];
                    if (existingOperation.Operation < minimumOperations)
                    {
                        minimumOperations = existingOperation.Operation;
                        candidateValues = existingOperation.Values;
                    }
                }
                var existingSingleOperation = operations[i - 1];
                if (existingSingleOperation.Operation < minimumOperations)
                {
                    minimumOperations = existingSingleOperation.Operation;
                    candidateValues = existingSingleOperation.Values;
                }

                operations[i] = new Node() { Operation = minimumOperations + 1, Values = new List<int>(candidateValues) };
                operations[i].Values.Add(i);
            }

            return operations;
        }
    }

    public class Node
    {
        public int Operation { get; set; }
        public List<int> Values { get; set; } = new List<int>();
    }
}
