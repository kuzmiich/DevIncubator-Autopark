using DevIncubator.Autopark.Entity.Class;
using System;
using System.Collections.Generic;
using DevIncubator.Autopark.Entity.Class.VehicleComponent;
using DevIncubator.Autopark.Entity.Enum;
using DevIncubator.Autopark.Extension;

namespace DevIncubator.Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicleTypes = new List<VehicleType>()
            {
                new ("Bus", 1.2m),
                new ("Car", 1m),
                new ("Rink", 1.5m),
                new ("Tractor", 1.2m)
            };

            vehicleTypes[^1].TaxCoefficient = 1.3m;

            var maxTaxCoefficient = vehicleTypes[0].TaxCoefficient;
            var sumTaxCoefficient = 0m;
            foreach (var vehicleType in vehicleTypes)
            {
                vehicleType.Display();
                if (vehicleType.TaxCoefficient > maxTaxCoefficient)
                {
                    maxTaxCoefficient = vehicleType.TaxCoefficient;
                }

                sumTaxCoefficient += vehicleType.TaxCoefficient;
            }

            var averageTaxCoefficient = sumTaxCoefficient / vehicleTypes.Count;

            Console.WriteLine($"Max tax coefficient - {maxTaxCoefficient}");
            Console.WriteLine($"Average tax coefficient - {averageTaxCoefficient}");

            vehicleTypes.PrettyOutput();
            
            Console.WriteLine(string.Empty.PadLeft(220, '-'));
            //
            var vehicles = new Vehicle[]
            {
                new (vehicleTypes[0], new GasolineEngine(2, 8.1),"Volkswagen Crafter", "5427 AX-7", 2022, 2015, 376000, ColorType.Blue),
                new (vehicleTypes[0], new GasolineEngine(2.18, 8.5),"Volkswagen Crafter", "6427 AA-7", 2500, 2014, 227010, ColorType.White),
                new (vehicleTypes[0], new ElectricalEngine(50),"Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, ColorType.Green),
                new (vehicleTypes[1], new DieselEngine(1.6, 7.2),"Golf 5", "8682 AX-7", 1200, 2006, 230451, ColorType.Gray),
                new (vehicleTypes[1], new ElectricalEngine(25),"Tesla Model S 70D", "E001 AA-7", 2200, 2019, 10454, ColorType.White),
                new (vehicleTypes[2], new DieselEngine(3.2, 25),"Hamm HD 12 VV", null, 3000, 2016, 122, ColorType.Yellow),
                new (vehicleTypes[3], new DieselEngine(4.75, 20.1),"MT3 Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, ColorType.Red),
            };

            vehicles.PrettyOutput();

            Array.Sort(vehicles);

            vehicles.PrettyOutput();

            var max = vehicles[0].Mileage;
            Vehicle maxVehicle = null;
            var min = vehicles[0].Mileage;
            Vehicle minVehicle = null;
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Mileage > max)
                {
                    max = vehicle.Mileage;
                    maxVehicle = vehicle;
                }
                if (vehicle.Mileage < min)
                {
                    min = vehicle.Mileage;
                    minVehicle = vehicle;
                }
            }

            Console.WriteLine("Max mileage vehicle: ");
            Console.WriteLine(maxVehicle);

            Console.WriteLine("Min mileage vehicle: ");
            Console.WriteLine(minVehicle); 
            
            Console.WriteLine(string.Empty.PadLeft(220, '-'));
            //
            Console.WriteLine("Found equal vehicles:");
            var count = 0;
            for (int i = 0; i < vehicles.Length - 1; i++)
            {
                for (int j = 0; j < vehicles.Length - 1; j++)
                {
                    if (vehicles[i].Equals(vehicles[j]))
                    {
                        count++;
                    }
                    if (vehicles[i].Equals(vehicles[j]) && count == 2)
                    {
                        Console.WriteLine($"{vehicles[i]}");
                        Console.WriteLine($"{vehicles[j]}");
                        count = 0;
                    }
                }
            }

            Console.WriteLine(string.Empty.PadLeft(220, '-'));
            //
        }
    }
}