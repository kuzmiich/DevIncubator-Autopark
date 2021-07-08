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
        
        private static List<string> ParseCsv(string csvData)
        {
            var splitElements = csvData.Split(",");

            var parseElements = new List<string>();
            for(int i = 0; i < splitElements.Length; i++)
            {
                if (splitElements[i].StartsWith('\"'))
                {
                    var field = $"{splitElements[i].TrimStart('\"')},{splitElements[i + 1].TrimEnd('\"')}";
                    i++;
                    parseElements.Add(field);
                }
                else
                {
                    parseElements.Add(splitElements[i]);
                }
            }

            return parseElements;
        }

        public List<List<string>> ReadListListCsvElements()
        {
            if (!File.Exists(Path))
            {
                throw new FileNotFoundException(nameof(Path), $"Path - {Path}");
            }

            using (var reader = new StreamReader(Path))
            {
                var listCsvElements = new List<List<string>>();

                while (!reader.EndOfStream)
                {
                    var listObj = ParseCsv(reader.ReadLine());
                    listCsvElements.Add(listObj);
                }
                return listCsvElements;
            }
        }
    } 
}
