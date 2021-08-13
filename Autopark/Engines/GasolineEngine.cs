using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autopark.Engines.Base;

namespace Autopark.Engines
{
    public class GasolineEngine : AbstractCombustionEngine
    {
        public GasolineEngine(double engineCapacity, double fuelConsumptionPer100) : base("Gasoline", 1.0m)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }
        public override string ToString() =>
            $"{TypeName}," +
            $"{EngineCapacity:0.00}," +
            $"{FuelConsumptionPer100:0.00}";
    }
}
