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
    }
}
