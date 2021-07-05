using System;
using System.Collections.Generic;
using System.IO;
using DevIncubator.Autopark.Entity.Class;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines;
using DevIncubator.Autopark.Entity.Enum;

namespace DevIncubator.Autopark.InputService
{
    public class CsvFileWriter : IInputService
    {
        public CsvFileWriter(string path)
        {
            Path = path;
        }
        public string Path { get; }

        public void WriteEnumerable<T>(IEnumerable<T> enumerable)
        {
            using (var streamWriter = new StreamWriter(Path))
            {
                foreach (var obj in enumerable)
                {
                    var line = obj?.ToString();
                    streamWriter.WriteLine(line);
                }
            }
        }
    }
}
