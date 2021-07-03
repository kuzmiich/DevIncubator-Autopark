using DevIncubator.Autopark.Entity.Class;
using System;
using System.Collections.Generic;
using DevIncubator.Autopark.Entity.Class.VehicleComponent;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines;
using DevIncubator.Autopark.Entity.Enum;
using DevIncubator.Autopark.Extension;

namespace DevIncubator.Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
			const string directoryPath = "../../../Files/";
            var collections = new Collections($"{directoryPath}types.csv",
                    $"{directoryPath}vehicles.csv",
                    $"{directoryPath}rents.csv");
            collections.Print();
            collections.Insert(1,
                new Vehicle(1,
                    collections.ListVehicleTypes[1],
                    new ElectricalEngine(25),
                    new List<Rent>(),
                    "Tesla Model S",
                    null,
                    2025,
                    2020,
                    100,
                    ColorType.White,
                    150));

            collections.Delete(1);
            collections.Delete(4);

            collections.Print();

            var comparator = new VehicleComparer();

            collections.Sort(comparator);

            collections.Print();
		}
    }
}