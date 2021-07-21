using System;
using System.Collections.Generic;
using Autopark.Entity.Models;

namespace Autopark.Extension
{
    internal class VehicleComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            if (x is null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            if (y is null)
            {
                throw new ArgumentNullException(nameof(y));
            }

            var firstModelName = x.ModelName;
            var secondModelName = y.ModelName;

            return firstModelName.CompareTo(secondModelName);
        }
    }
}
