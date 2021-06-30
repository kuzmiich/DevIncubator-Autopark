using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines.Base;
using DevIncubator.Autopark.Entity.Enum;

namespace DevIncubator.Autopark.Entity.Class
{
    public class Vehicle : IComparable<Vehicle>
    {
        public Vehicle()
        {
        }
        public Vehicle(VehicleType vehicleType, AbstractEngine vehicleEngine, string modelName, string registrationNumber, int weight, int releaseYear, int mileage, ColorType colorType, double tankCapacity = 0d)
        {
            VehicleType = vehicleType;
            VehicleEngine = vehicleEngine;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            ReleaseYear = releaseYear;
            Mileage = mileage;
            ColorType = colorType;
            TankCapacity = tankCapacity;
        }
        public VehicleType VehicleType { get; set; }
        public AbstractEngine VehicleEngine { get; set; }
        public string ModelName { get; }
        public string RegistrationNumber { get; }
        public int Weight { get; set; }
        public int ReleaseYear { get; }
        public int Mileage { get; set; }
        public ColorType ColorType { get; set; }
        public double TankCapacity { get; private set; }


        public decimal GetCalcTaxPerMonth => (Weight * 0.0013m) + (VehicleEngine.TaxCoefficient * VehicleType.TaxCoefficient * 30m) + 5;

        public int CompareTo(Vehicle vehicle)
        {
            if (vehicle.Equals(null))
            {
                throw new ArgumentNullException("Vehicle can`t be null");
            }

            int compareValue = default;
            if (GetCalcTaxPerMonth < vehicle.GetCalcTaxPerMonth)
            {
                compareValue = - 1;
            }
            else if (GetCalcTaxPerMonth == vehicle.GetCalcTaxPerMonth)
            {
                compareValue = 0;
            }
            else if (GetCalcTaxPerMonth > vehicle.GetCalcTaxPerMonth)
            {
                compareValue = 1;
            }

            return compareValue;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vehicle vehicle)
            {
                return VehicleType == vehicle.VehicleType && ModelName == vehicle.ModelName;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{VehicleType}, {VehicleEngine}, Model - {ModelName}, Registration number - {RegistrationNumber}, Weight - {Weight}, " +
                   $"Release Year - {ReleaseYear}, Mileage - {Mileage}, Color Type - {ColorType}, Tank capacity - {TankCapacity:0.00}, " +
                   $"Tax per month - {GetCalcTaxPerMonth:0.00}";
        }
    }
}
