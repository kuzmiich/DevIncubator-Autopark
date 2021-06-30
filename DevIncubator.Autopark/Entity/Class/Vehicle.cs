using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Enum;

namespace DevIncubator.Autopark.Entity.Class
{
    public class Vehicle : IComparable<Vehicle>
    {
        public Vehicle()
        {
        }

        public Vehicle(VehicleType vehicleType, string modelName, string registrationNumber, int weight, int releaseYear, int mileage, ColorType colorType, double tankCapacity = 0.0)
        {
            VehicleType = vehicleType;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            ReleaseYear = releaseYear;
            Mileage = mileage;
            ColorType = colorType;
            TankCapacity = tankCapacity;
        }
        public VehicleType VehicleType { get; set; }
        public string ModelName { get; }
        public string RegistrationNumber { get; }
        public int Weight { get; set; }
        public int ReleaseYear { get; }
        public int Mileage { get; set; }
        public ColorType ColorType { get; set; }
        public double TankCapacity { get; private set; }

        public decimal GetCalcTaxPerMonth => (Weight * 0.0013m) + (VehicleType.TaxCoefficient * 30m) + 5;

        public int CompareTo(Vehicle vehicle)
        {
            if (vehicle.Equals(null))
            {
                throw new ArgumentNullException("Error, argument can`t be null");
            }

            var vehicleCalcTaxPerMonth = vehicle.GetCalcTaxPerMonth;

            return vehicleCalcTaxPerMonth.CompareTo(GetCalcTaxPerMonth);
        }

        public override string ToString()
        {
            return $"{VehicleType}, Model name - {ModelName}, State number - {RegistrationNumber}, Weight - {Weight}, " +
                   $"Release Year - {ReleaseYear}, Mileage - {Mileage}, Color type - {ColorType}, Tank capacity - {TankCapacity}, " +
                   $"Sum per month - {GetCalcTaxPerMonth:0.00}";
        }
    }
}
