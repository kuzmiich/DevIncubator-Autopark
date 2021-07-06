using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class;

namespace DevIncubator.Autopark.Extension
{
    internal static class AutoparkHelper
    {
        public static void PrintEnumerable<T>(this IEnumerable<T> enumerable)
        {
            foreach (var obj in enumerable)
            {
                Console.WriteLine(obj);
            }
        }
    }
}
