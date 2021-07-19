using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines.Base;

namespace DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines
{
    public class ElectricalEngine : AbstractEngine
    {
        public ElectricalEngine(double electricityConsumption) : base("Electrical", 0.1m)
        {
            ElectricityConsumption = electricityConsumption;
        }
        public double ElectricityConsumption { get; }

        public override double GetMaxKilometers(double batterySize)
        {
            if (batterySize < 0.0)
            {
                throw new ArgumentException("Battery size can`t be (< 0)");
            }

            return batterySize / ElectricityConsumption;
        }
        public override string ToString()
        {
            return $"{TypeName}," +
                   $"{TaxCoefficient:0.00}," +
                   $"{ElectricityConsumption:0.00}";
        }
    }
}
