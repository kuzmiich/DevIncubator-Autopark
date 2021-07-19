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

        #region Vehicle Property

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
        
        #endregion

        public int CompareTo(Vehicle vehicle)
        {
            var vehicleCalcTaxPerMonth = vehicle.GetCalcTaxPerMonth;

            return vehicleCalcTaxPerMonth.CompareTo(GetCalcTaxPerMonth);
        }

        public override bool Equals(object obj)
        { 
            return obj is Vehicle vehicle && (VehicleType == vehicle.VehicleType && ModelName == vehicle.ModelName);
        }

        public override string ToString() => $"{VehicleType}, {VehicleEngine}, Model name - {ModelName}, State number - {RegistrationNumber}, Weight - {Weight}, " +
                   $"Release Year - {ReleaseYear}, Mileage - {Mileage}, Color type - {ColorType}, Tank capacity - {TankCapacity:0.00}, " +
                   $"Sum per month - {GetCalcTaxPerMonth:0.00}";
    }
}
