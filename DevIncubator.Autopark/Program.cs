using DevIncubator.Autopark.Service;
using DevIncubator.Autopark.Service.AutoparkService;
using System;
using System.IO;
using DevIncubator.Autopark.Entity.Class.MyCollections;
using DevIncubator.Autopark.OutputService;

namespace DevIncubator.Autopark
{
    class Program
    {
        private static readonly string DirectoryPath = @$"{Directory.GetCurrentDirectory()}\Files\";

        static void Main(string[] args)
        {
            var collections = new Collections($"{DirectoryPath}types.csv",
                $"{DirectoryPath}vehicles.csv",
                $"{DirectoryPath}rents.csv");

            var listCsvElements = new CsvFileReader($"{DirectoryPath}orders.csv").ReadLineCsvElements();
            IService[] services =
            {
                new AutoparkInfoService(),
                new WashingService(collections),
                new GarageService(collections),
                new RepairService(listCsvElements)
            };

            try
            {
                foreach (var service in services)
                {
                    service.RunService();
                    Console.WriteLine(string.Empty.PadLeft(120, '-'));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}

/* Data for initialize files rents, types, vehicles
    VehicleType[] vehicleTypes =
    { 
        new(1, "Bus", 1.2m), 
        new(2, "Car", 1m),
        new(3, "Rink", 1.5m),
        new(4, "Tractor", 1.2m)

    };

    Vehicle[] vehicles =
    { 
        new(1, vehicleTypes[0], new GasolineEngine(2d,8.1d), "Volkswagen Crafter","5427 AX-7",2022,2015,376000,ColorType.Blue,75),
        new(2, vehicleTypes[0], new GasolineEngine(2.18d,8.5d),"Volkswagen Crafter","6427 AX-7",2500,2014,227010,ColorType.White,75),
        new(3, vehicleTypes[0], new ElectricalEngine(50), "Electric Bus E321","6785 BA-7",12080,2019,20451,ColorType.Green,150),
        new(4, vehicleTypes[1], new DieselEngine(1.6d,7.2d), "Golf 5","8682 AX-7",1200,2006,230451,ColorType.Gray,55),
        new(5, vehicleTypes[1], new ElectricalEngine(25), "Tesla Model","E001 AA-7",2200,2019,10454,ColorType.White,70),
        new(6, vehicleTypes[2], new DieselEngine(3.2d,25d), "Hamm HD 12VV",null,3000,2016,122,ColorType.Yellow,20),
        new(7, vehicleTypes[3], new DieselEngine(4.75d,20.1d), "МТЗ Беларус - 1025.4","1145 AB-7",1200,2020,109,ColorType.Red,135)
    };

    Rent[] rents = 
    {
        new (2, new DateTime(2020, 10, 01), 68),
        new (1, new DateTime(2020, 10, 01), 123.25m),
        new (5, new DateTime(2020, 10, 03), 87),
        new (7, new DateTime(2020, 10, 05), 42),
        new (6, new DateTime(2020, 10, 07), 150),
        new (4, new DateTime(2020, 10, 10), 47),
        new (6, new DateTime(2020, 10, 15), 80),
        new (5, new DateTime(2020, 10, 18), 150),
        new (4, new DateTime(2020, 10, 19), 36),
        new (2, new DateTime(2020, 10, 20), 60.50m),
        new (3, new DateTime(2020, 10, 22), 220.50m)
    };
    IInputService inputService = new CsvFileWriter("../../../Files/vehicles.csv");
    inputService.WriteEnumerable(vehicles);
 */