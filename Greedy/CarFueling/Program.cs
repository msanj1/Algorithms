using System;
using System.Linq;

namespace CarFueling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var destination = int.Parse(Console.ReadLine());
            var fuel = int.Parse(Console.ReadLine());
            var numberOfGasStations = int.Parse(Console.ReadLine());
            var gasStationStops = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            // -----|-----|-----|-----|-----0

            var currentFuel = fuel;
            var left = 0;
            int refills = 0;
            var lastGasStationStopped = -1;
            while (left < destination)
            {
                var distanceToCover = left + fuel;

                if (distanceToCover >= destination)
                {
                    left = destination;
                  
                }else
                {
                    int currentGastStationToStop = -1; 
                    for (int i = lastGasStationStopped + 1; i < numberOfGasStations; i++)
                    {
                        if (distanceToCover >= gasStationStops[i])
                        {
                            currentGastStationToStop = i;
                        }
                    }

                    if (currentGastStationToStop == -1)
                    {
                        refills = -1;
                        break;
                    }

                    if (currentGastStationToStop != -1)
                    {
                        lastGasStationStopped = currentGastStationToStop;
                        left = gasStationStops[lastGasStationStopped];
                        refills++;
                    }
                }
            }

            Console.WriteLine(refills);
        }

    }
}
