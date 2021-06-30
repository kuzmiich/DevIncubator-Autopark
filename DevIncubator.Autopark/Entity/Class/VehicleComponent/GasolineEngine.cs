using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Base;

namespace DevIncubator.Autopark.Entity.Class.VehicleComponent
{
    public class GasolineEngine : CombustionEngine
    {
        public GasolineEngine(double engineCapacity, double fuelConsumptionPer100) : base("Gasoline", 1.0m)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }

    }
}
