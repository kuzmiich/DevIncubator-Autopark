using DevIncubator.Autopark.Entity.Class;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines.Base;
using DevIncubator.Autopark.Entity.Enum;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace DevIncubator.Autopark.OutputService
{
    public class CsvFileReader : IOutputService
    {
        public CsvFileReader(string path)
        {
            Path = path;
        }
        public string Path { get; }

        public List<Vehicle> ReadVehicles()
        {
            if (File.Exists(Path) == false)
            {
                throw new FileNotFoundException(nameof(Path), $"Path - {Path}");
            }

            var vehicles = new List<Vehicle>();

            using (var parser = new TextFieldParser(Path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();

                    //vehicles.Add(CreateVehicle(fields));
                }
            }

            return vehicles;
        }

        public List<VehicleType> ReadVehicleTypes()
        {
            throw new NotImplementedException();
        }

        public List<Rent> ReadRents()
        {
            throw new NotImplementedException();
        }
    } 
}
