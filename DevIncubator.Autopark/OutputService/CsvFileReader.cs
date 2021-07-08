using DevIncubator.Autopark.Entity.Class;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines.Base;
using DevIncubator.Autopark.Entity.Enums;
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

        public List<List<string>> ReadListListCsvElements()
        {
            if (!File.Exists(Path))
            {
                throw new FileNotFoundException(nameof(Path), $"Path - {Path}");
            }

            using (var reader = new StreamReader(Path))
            {
                var listEnumerableFields = new List<List<string>>();

                while (!reader.EndOfStream)
                {
                    var vehicleFields = ParseCsv(reader.ReadLine());
                    listEnumerableFields.Add(vehicleFields);
                }
                return listEnumerableFields;
            }
        }
    } 
}
