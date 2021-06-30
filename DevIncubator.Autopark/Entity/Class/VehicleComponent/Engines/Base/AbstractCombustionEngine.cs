using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines.Base
{
    public abstract class AbstractCombustionEngine : AbstractEngine
    {
        protected AbstractCombustionEngine(string typeName, decimal taxCoefficient) : base(typeName, taxCoefficient)
        {
        }

        public double EngineCapacity { get; set; }
        public double FuelConsumptionPer100 { get; set; }

        public override double GetMaxKilometers(double fuelTankCapacity)
        {
            if (fuelTankCapacity < 0.0)
            {
                throw new ArgumentException("Battery size can`t be <0");
            }

            return fuelTankCapacity * 100d / FuelConsumptionPer100;
        }
    }
}
