using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines.Base;
using DevIncubator.Autopark.Entity.Enum;
using DevIncubator.Autopark.Extension;

namespace DevIncubator.Autopark.Entity.Class
{
    public class Vehicle : IComparable<Vehicle>
    {
        public Vehicle()
        {
        }

        public Vehicle(int id,
            VehicleType vehicleType,
            AbstractEngine vehicleEngine,
            List<Rent> listRent,
            string modelName,
            string registrationNumber,
            int weight,
            int releaseYear,
            int mileage,
            ColorType colorType,
            double tankCapacity)
        {
            Id = id;
            VehicleType = vehicleType;
            VehicleEngine = vehicleEngine;
            ListRent = listRent;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            ReleaseYear = releaseYear;
            Mileage = mileage;
            ColorType = colorType;
            TankCapacity = tankCapacity;
        }

        #region Vehicle Property

        public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public AbstractEngine VehicleEngine { get; set; }
        public List<Rent> ListRent { get; set; }
        public string ModelName { get; }
        public string RegistrationNumber { get; }
        public int Weight { get; set; }
        public int ReleaseYear { get; }
        public int Mileage { get; set; }
        public ColorType ColorType { get; set; }
        public double TankCapacity { get; private set; }

        #endregion

        public decimal GetCalcTaxPerMonth => (Weight * 0.0013m) + (VehicleType.TaxCoefficient * 30m) + 5;

        public decimal GetTotalIncome => ListRent.SumElement(rent => rent.RentCost);

        public decimal GetTotalProfit => GetTotalIncome - GetCalcTaxPerMonth;

        public int CompareTo(Vehicle vehicle)
        {
            if (vehicle is null)
            {
                throw new ArgumentNullException(nameof(vehicle), "Error, argument can`t be null");
            }

            return vehicle.GetCalcTaxPerMonth.CompareTo(GetCalcTaxPerMonth);
        }
        public override string ToString() =>
                   $"{Id},{VehicleType},{VehicleEngine},{ModelName},{RegistrationNumber},{Weight}," +
                   $"{ReleaseYear},{Mileage},{ColorType},{TankCapacity}";
    }
}
