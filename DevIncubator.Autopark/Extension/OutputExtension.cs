using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class;

namespace DevIncubator.Autopark.Extension
{
    internal static class OutputExtension
    {
        public static void PrettyOutput<T>(this IEnumerable<T> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
