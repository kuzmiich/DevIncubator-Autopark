using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class;

namespace DevIncubator.Autopark.Extension
{
    public static class AutoparkHelper
    {
        public static void PrettyOutput(this Vehicle[] vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
        public static void PrettyOutput(this List<VehicleType> vehicleTypes)
        {
            foreach (var vehicleType in vehicleTypes)
            {
                Console.WriteLine(vehicleType);
            }
        }
    }
}
