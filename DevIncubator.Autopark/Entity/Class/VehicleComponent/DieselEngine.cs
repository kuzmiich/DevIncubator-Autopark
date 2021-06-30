using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Base;

namespace DevIncubator.Autopark.Entity.Class.VehicleComponent
{
    public class DieselEngine : CombustionEngine
    {
        public DieselEngine(double engineCapacity, double fuelConsumptionPer100) : base("Diesel", 1.2m)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }
    }
}
