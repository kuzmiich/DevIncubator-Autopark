using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines.Base;

namespace DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines
{
    public class DieselEngine : AbstractCombustionEngine
    {
        public DieselEngine(double engineCapacity, double fuelConsumptionPer100) : base("Diesel", 1.2m)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }

        public override string ToString()
        {
            return $"{TypeName}," +
                   $"{TaxCoefficient:0.00}," +
                   $"{EngineCapacity:0.00}," +
                   $"{FuelConsumptionPer100:0.00}";
        }
    }
}
