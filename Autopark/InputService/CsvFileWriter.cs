using System;
using System.Collections.Generic;
using System.IO;

namespace Autopark.InputService
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
                    if (obj is not null)
                    {
                        var line = obj.ToString();
                        streamWriter.WriteLine(line);
                    }
                }
            }
        }
    }
}
