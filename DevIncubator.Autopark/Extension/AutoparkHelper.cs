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
        public static T? ToEnum<T>(this string value) where T : struct => 
            Enum.TryParse(value, out T valueResult) ? valueResult : default;

        public static decimal SumElement<T>(this IEnumerable<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            var sum = 0m;
            foreach (var item in source)
            {
                sum += selector(item);
            }

            return sum;
        }

        public static void PrintEnumerable<T>(this IEnumerable<T> enumerable)
        {
            foreach (var obj in enumerable)
            {
                Console.WriteLine(obj);
            }
        }
    }
}
