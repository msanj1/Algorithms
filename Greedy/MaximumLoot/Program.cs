using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumLoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var backpackWeight = input[1];
            var compounds = new List<Compound>();
            double totalValue = 0;
            for(int i=0; i< input[0]; i++)
            {
                var compoundInput = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

                compounds.Add(new Compound()
                {
                    Cost = compoundInput[0],
                    Weight = compoundInput[1]
                });
            }

            compounds = compounds.OrderByDescending(x => x.CostPerUnit).ToList();

            for (int i=0; i< compounds.Count; i++)
            {
                var compound = compounds[i];

                var weightToTake = Math.Min(backpackWeight, compound.Weight);

                totalValue += weightToTake * compound.CostPerUnit;

                compound.Weight -= weightToTake;
                backpackWeight = backpackWeight - weightToTake;
            }

            Console.WriteLine($"{Math.Round(totalValue, 4):0.0000}");
        }

        static Compound FindCompound(List<Compound> compounds)
        {
            var maxCostPerUnit = double.MinValue;
            Compound compound = null;

            for (int i = 0; i < compounds.Count; i++)
            {
                if (compounds[i].Weight > 0 && compounds[i].CostPerUnit > maxCostPerUnit)
                {
                    maxCostPerUnit = compounds[i].CostPerUnit;
                    compound = compounds[i];
                }
            }

            return compound;
        }
    }

    public class Compound
    {
        public int Cost { get; set; }
        public int Weight { get; set; }
        public double CostPerUnit { 
            get {
                return Cost / (double)Weight; 
            } 
        }
    }
}
