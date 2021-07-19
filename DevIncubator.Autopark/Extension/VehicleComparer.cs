using DevIncubator.Autopark.Entity.Class;
using System;
using System.Collections.Generic;

namespace DevIncubator.Autopark.Extension
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
