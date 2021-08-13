using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autopark.Engines.Base;

namespace Autopark.Engines
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
            if (batterySize < 0d)
            {
                throw new ArgumentException("Battery size can`t be (< 0)");
            }

            return batterySize / ElectricityConsumption;
        }
        public override string ToString() =>
            $"{TypeName}," +
            $"{ElectricityConsumption:0.00}";
    }
}
