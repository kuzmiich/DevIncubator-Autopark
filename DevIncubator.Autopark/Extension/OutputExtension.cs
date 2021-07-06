﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class;

namespace DevIncubator.Autopark.Extension
{
    public static class OutputExtension
    {
        public static void PrintEnumerable<T>(this IEnumerable<T> enumerable)
        {
            foreach (var element in enumerable)
            {
                Console.WriteLine(element);
            }
        }
    }
}