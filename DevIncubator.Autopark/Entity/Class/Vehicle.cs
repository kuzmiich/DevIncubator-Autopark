using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Base;
using DevIncubator.Autopark.Entity.Enum;

namespace DevIncubator.Autopark.Entity.Class
{
    public class Vehicle : IComparable<Vehicle>
    {
        public Vehicle()
        {
        }
<<<<<<< HEAD
        public Vehicle(VehicleType vehicleType, Engine vehicleEngine, string modelName, string registrationNumber, int weight, int releaseYear, int mileage, ColorType colorType, double tankCapacity = 0d)
=======

        public Vehicle(VehicleType vehicleType,
            string modelName,
            string registrationNumber,
            int weight,
            int releaseYear,
            int mileage,
            ColorType colorType,
            double tankCapacity = 0.0)
>>>>>>> master
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
        public Engine VehicleEngine { get; set; }
        public string ModelName { get; }
        public string RegistrationNumber { get; }
        public int Weight { get; set; }
        public int ReleaseYear { get; }
        public int Mileage { get; set; }
        public ColorType ColorType { get; set; }
        public double TankCapacity { get; private set; }

<<<<<<< HEAD

        public decimal GetCalcTaxPerMonth => (Weight * 0.0013m) + (VehicleEngine.TaxCoefficient * VehicleType.TaxCoefficient * 30m) + 5;

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
=======
        #endregion

        public decimal GetCalcTaxPerMonth => (Weight * 0.0013m) + (VehicleType.TaxCoefficient * 30m) + 5;

        public int CompareTo(Vehicle vehicle)
        {
            if (vehicle is null)
            {
                throw new ArgumentNullException(nameof(vehicle),"Error, argument can`t be null");
            }

            return vehicle.GetCalcTaxPerMonth.CompareTo(GetCalcTaxPerMonth);
        }

        public override string ToString() => $"{VehicleType}, Model name - {ModelName}, State number - {RegistrationNumber}, Weight - {Weight}, " +
                   $"Release Year - {ReleaseYear}, Mileage - {Mileage}, Color type - {ColorType}, Tank capacity - {TankCapacity}, " +
>>>>>>> master
                   $"Sum per month - {GetCalcTaxPerMonth:0.00}";
    }
}
