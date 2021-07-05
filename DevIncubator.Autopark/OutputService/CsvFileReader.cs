using DevIncubator.Autopark.Entity.Class;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines.Base;
using DevIncubator.Autopark.Entity.Enum;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevIncubator.Autopark.Extension;

namespace DevIncubator.Autopark.OutputService
{
    public class CsvFileReader : IOutputService
    {
        public CsvFileReader(string path)
        {
            Path = path;
        }
        public string Path { get; }
        
        private static List<string> ParseCsv(string csvData)
        {
            var splitFields = csvData.Split(",");
            var parseFields = new List<string>();
            for(int i = 0; i < splitFields.Length; i++)
            {
                if (splitFields[i].StartsWith('\"'))
                {
                    var field = $"{splitFields[i].TrimStart('\"')},{splitFields[i + 1].TrimEnd('\"')}";
                    i++;
                    parseFields.Add(field);
                }
                else
                {
                    parseFields.Add(splitFields[i]);
                }
            }

            return parseFields;
        }

        public List<List<string>> ReadVehicles()
        {
            if (File.Exists(Path) == false)
            {
                throw new FileNotFoundException(nameof(Path), $"Path - {Path}");
            }
            
            using (var reader = new StreamReader(Path))
            {
                var vehicles = new List<List<string>>();

                while (!reader.EndOfStream)
                {
                    var vehicleFields = ParseCsv(reader.ReadLine());
                    vehicles.Add(vehicleFields);
                }
                return vehicles;
            }
        }
        
        private static VehicleType CreateType(int id, string typeName, decimal taxCoefficient) =>
            new(id, typeName, taxCoefficient);

        public List<VehicleType> ReadVehicleTypes()
        {
            if (File.Exists(Path) == false)
            {
                throw new FileNotFoundException(nameof(Path), $"Path - {Path}");
            }

            using (var reader = new StreamReader(Path))
            {
                var vehicleTypes = new List<VehicleType>();

                while (!reader.EndOfStream)
                {
                    var vehicleTypeFields = ParseCsv(reader.ReadLine());

                    var vehicleType = CreateType(Convert.ToInt32(vehicleTypeFields[0]), vehicleTypeFields[1], Convert.ToDecimal(vehicleTypeFields[2]));
                    vehicleTypes.Add(vehicleType);
                }

                return vehicleTypes;
            }
        }


        public List<List<string>> ReadRents()
        {
            if (File.Exists(Path) == false)
            {
                throw new FileNotFoundException(nameof(Path), $"Path - {Path}");
            }

            using (var reader = new StreamReader(Path))
            {
                var rents = new List<List<string>>();

                while (!reader.EndOfStream)
                {
                    var rentFields = ParseCsv(reader.ReadLine());

                    rents.Add(rentFields);
                }

                return rents;
            }
        }
    } 
}
