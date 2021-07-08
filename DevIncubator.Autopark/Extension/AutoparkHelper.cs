using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class;
using DevIncubator.Autopark.Entity.Enums;

namespace DevIncubator.Autopark.Extension
{
    internal static class AutoparkHelper
    {
        public static T? ToEnum<T>(this string value) where T : struct
        {
            return Enum.TryParse(typeof(T), value, true, out var result) ? (T?)result : default;
        }

        public static ColorType ToEnum(this string value)
        {
            return Enum.TryParse(value, out ColorType result) ? result : default;
        }
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
        public static void PrettyOutput<T>(this IEnumerable<T> enumerable)
        {
            foreach (var value in enumerable)
            {
                Console.WriteLine(value);
            }
        }
    }
}
