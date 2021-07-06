using DevIncubator.Autopark.Entity.Class;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines;
using DevIncubator.Autopark.Entity.Enum;
using DevIncubator.Autopark.Extension;
using System;
using System.Collections.Generic;

namespace DevIncubator.Autopark.Service.AutoparkService
{
    class AutoparkInfoService : IService
    {
        private static readonly List<VehicleType> _vehicleTypes = new()
        {
            new VehicleType(1, "Bus", 1.2m),
            new VehicleType(2, "Car", 1m),
            new VehicleType(3, "Rink", 1.5m),
            new VehicleType(4, "Tractor", 1.2m)
        };
        private readonly Vehicle[] vehicles =
        {
            new(1, _vehicleTypes[0], new GasolineEngine(2d,8.1d), "Volkswagen Crafter","5427 AX-7",2022,2015,376000,ColorType.Blue,75),
            new(2, _vehicleTypes[0], new GasolineEngine(2.18d,8.5d),"Volkswagen Crafter","6427 AX-7",2500,2014,227010,ColorType.White,75),
            new(3, _vehicleTypes[0], new ElectricalEngine(50), "Electric Bus E321","6785 BA-7",12080,2019,20451,ColorType.Green,150),
            new(4, _vehicleTypes[1], new DieselEngine(1.6d,7.2d), "Golf 5","8682 AX-7",1200,2006,230451,ColorType.Gray,55),
            new(5, _vehicleTypes[1], new ElectricalEngine(25), "Tesla Model","E001 AA-7",2200,2019,10454,ColorType.White,70),
            new(6, _vehicleTypes[2], new DieselEngine(3.2d,25d), "Hamm HD 12VV",null,3000,2016,122,ColorType.Yellow,20),
            new(7, _vehicleTypes[3], new DieselEngine(4.75d,20.1d), "МТЗ Беларус - 1025.4","1145 AB-7",1200,2020,109,ColorType.Red,135)
        };

        public void RunService()
        {
            // 1
            _vehicleTypes[^1].TaxCoefficient = 1.3m;

            var maxTaxCoefficient = _vehicleTypes[0].TaxCoefficient;
            var sumTaxCoefficient = 0m;
            foreach (var vehicleType in _vehicleTypes)
            {
                vehicleType.Display();
                if (vehicleType.TaxCoefficient > maxTaxCoefficient)
                {
                    maxTaxCoefficient = vehicleType.TaxCoefficient;
                }

                sumTaxCoefficient += vehicleType.TaxCoefficient;
            }

            var averageTaxCoefficient = sumTaxCoefficient / _vehicleTypes.Count;

            Console.WriteLine($"Max tax coefficient - {maxTaxCoefficient}");
            Console.WriteLine($"Average tax coefficient - {averageTaxCoefficient}");

            _vehicleTypes.PrintEnumerable();

            Console.WriteLine(string.Empty.PadLeft(120, '-'));
            // 2

            vehicles.PrintEnumerable();

            Array.Sort(vehicles);

            vehicles.PrintEnumerable();

            var max = vehicles[0].Mileage;
            Vehicle maxMileageVehicle = null;
            var min = vehicles[0].Mileage;
            Vehicle minMileageVehicle = null;
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Mileage > max)
                {
                    max = vehicle.Mileage;
                    maxMileageVehicle = vehicle;
                }
                if (vehicle.Mileage < min)
                {
                    min = vehicle.Mileage;
                    minMileageVehicle = vehicle;
                }
            }

            Console.WriteLine("Max mileage vehicle: ");
            Console.WriteLine(maxMileageVehicle);

            Console.WriteLine("Min mileage vehicle: ");
            Console.WriteLine(minMileageVehicle);

            Console.WriteLine(string.Empty.PadLeft(120, '-'));
            // 3
            Console.WriteLine("Found equal vehicles:");
            for (int i = 0; i < vehicles.Length - 1; i++)
            {
                var j = i + 1;
                if (vehicles[i].Equals(vehicles[j]))
                {
                    Console.WriteLine($"{vehicles[i]}");
                    Console.WriteLine($"{vehicles[j]}\n");
                }
            }

            Console.WriteLine(string.Empty.PadLeft(120, '-'));
            // 4
            var maxKilometers = 0.0;
            Vehicle maxKilometersVehicle = null;
            foreach (var vehicle in vehicles)
            {
                var fuelTank = vehicle.TankCapacity;
                var vehicleMaxKilometers = vehicle.VehicleEngine.GetMaxKilometers(fuelTank);
                if (vehicleMaxKilometers > maxKilometers)
                {
                    maxKilometers = vehicleMaxKilometers;
                    maxKilometersVehicle = vehicle;
                }
            }

            Console.WriteLine("Vehicle that will travel the maximum distance on a tank/battery:");
            Console.WriteLine(maxKilometersVehicle);
        }
    }
}
