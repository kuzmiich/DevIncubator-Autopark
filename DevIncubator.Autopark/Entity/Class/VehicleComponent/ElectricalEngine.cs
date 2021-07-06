using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Base;

namespace DevIncubator.Autopark.Entity.Class.VehicleComponent
{
    public class ElectricalEngine : Engine
    {
        public ElectricalEngine(double electricityConsumption) : base("Electrical", 0.1m)
        {
            ElectricityConsumption = electricityConsumption;
        }
        public double ElectricityConsumption { get; }

        public double GetMaxKilometers(double batterySize)
        {
            if (batterySize <= 0)
            {
                throw new ArgumentException("Battery size can`t be <=0");
            }

            return batterySize / ElectricityConsumption;
        }
    }
}
