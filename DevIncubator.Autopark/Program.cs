using DevIncubator.Autopark.Entity.Class;
using System;
using System.Collections.Generic;

namespace DevIncubator.Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicles = new List<VehicleType>()
            {
                new ("Bus", 1.2m),
                new ("Car", 1m),
                new ("Rink", 1.5m),
                new ("Tractor", 1.2m)
            };

            vehicles[^1].TaxCoefficient = 1.3m;

            var maxTaxCoefficient = vehicles[0].TaxCoefficient;
            var sumTaxCoefficient = 0m;
            foreach (var vehicle in vehicles)
            {
                vehicle.Display();
                if (vehicle.TaxCoefficient > maxTaxCoefficient)
                {
                    maxTaxCoefficient = vehicle.TaxCoefficient;
                }

                sumTaxCoefficient += vehicle.TaxCoefficient;
            }

            var averageTaxCoefficient = sumTaxCoefficient / vehicles.Count;

            Console.WriteLine($"Max tax coefficient - {maxTaxCoefficient}");
            Console.WriteLine($"Average tax coefficient - {averageTaxCoefficient}");

            foreach (var vehicleType in vehicles)
            {
                Console.WriteLine(vehicleType);
            }
        }
    }
}